using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Zenmoney
{
    public class HttpRequestBuilder
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

        public static HttpRequestMessage CreateFromRequest(string url, Request request)
        {
            var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
            var jsonSettings = new JsonSerializerSettings{ 
                ContractResolver = contractResolver,
                Formatting = Formatting.None
            };
            var body = JsonConvert.SerializeObject(request, jsonSettings);

            var httpRequest = HttpRequestBuilder.Create(url)
                .SetAuthToken(request.AuthToken)
                .SetBody(body)
                .Build();

            return httpRequest;
        }
    }
}