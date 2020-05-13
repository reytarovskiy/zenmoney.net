using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Zenmoney.Tests")]

namespace Zenmoney
{
    internal class HttpRequestBuilder
    {
        private string authToken;
        private readonly Uri url;
        private string body;

        private HttpRequestBuilder(Uri url)
        {
            this.url = url;
        }

        public HttpRequestBuilder SetAuthToken(string token)
        {
            authToken = token;

            return this;
        }

        public HttpRequestBuilder SetBody(string json)
        {
            body = json;

            return this;
        }

        public HttpRequestMessage Build()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (authToken != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

            if (body != null)
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");

            return request;
        }

        public static HttpRequestBuilder Create(Uri url)
        {
            return new HttpRequestBuilder(url);
        }
    }
}