using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Zenmoney.Exceptions;
using Zenmoney.Serializer;

namespace Zenmoney
{
    public sealed class Client : IDisposable
    {
        private readonly ISerializer serializer;

        private readonly Uri url = new Uri("http://api.zenmoney.ru/v8/diff/");
        
        private readonly HttpClient httpClient;

        public Client(HttpClient httpClient, ISerializer serializer)
        {
            this.serializer = serializer;
            this.httpClient = httpClient;
        }

        public async Task<SyncResult> Sync(Request request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var httpRequestBuilder = HttpRequestBuilder.Create(url)
                .SetAuthToken(request.AuthToken)
                .SetBody(serializer.SerializeRequest(request));

            using var httpRequest = httpRequestBuilder.Build();
            var response = await httpClient.SendAsync(httpRequest).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                await HandleError(response).ConfigureAwait(true);

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return serializer.DeserializeSyncResult(json);
        }

        private async Task HandleError(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new ValidationException(serializer.DeserializeValidationError(content));

            throw new UndefinedException(content);
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}