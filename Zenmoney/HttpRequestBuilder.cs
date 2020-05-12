using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

[assembly: InternalsVisibleTo("Zenmoney.Tests")]

namespace Zenmoney
{
    internal class HttpRequestBuilder
    {
        private string authToken;
        private string url;
        private string body;

        private HttpRequestBuilder(string url)
        {
            this.url = url;
        }

        public HttpRequestBuilder SetAuthToken(string token)
        {
            this.authToken = token;

            return this;
        }

        public HttpRequestBuilder SetBody(string json)
        {
            this.body = json;

            return this;
        }

        public HttpRequestMessage Build()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, this.url);

            if (this.authToken != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.authToken);

            if (this.body != null)
                request.Content = new StringContent(this.body, Encoding.UTF8, "application/json");

            return request;
        }

        public static HttpRequestBuilder Create(string url)
        {
            return new HttpRequestBuilder(url);
        }
    }
}