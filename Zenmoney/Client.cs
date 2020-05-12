using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Zenmoney.Exceptions;
using Zenmoney.Serializer;

namespace Zenmoney
{
    public class Client
    {
        private readonly ISerializer serializer;
        private readonly string url;
        private readonly HttpClient httpClient;

        public Client(ISerializer serializer, string url = "http://api.zenmoney.ru/v8/diff/")
        {
            this.serializer = serializer;
            this.url = url;

            this.httpClient = new HttpClient();
        }

        public async Task<SyncResult> Sync(Request request)
        {
            var httpRequest = HttpRequestBuilder.Create(url)
                .SetAuthToken(request.AuthToken)
                .SetBody(serializer.SerializeRequest(request))
                .Build();

            var response = await httpClient.SendAsync(httpRequest);

            if (!response.IsSuccessStatusCode)
                HandleError(response);

            var json = await response.Content.ReadAsStringAsync();

            return serializer.DeserializeSyncResult(json);
        }

        private void HandleError(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();

            throw new UndefinedException();
        }
    }
}