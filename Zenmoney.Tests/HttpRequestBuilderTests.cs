using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;
using Zenmoney;

namespace Zenmoney.Tests
{
    public class HttpRequestBuilderTests
    {
        [Fact]
        public void TestUrlIsSet()
        {
            var url = new Uri("http://test.url/");
            var request = HttpRequestBuilder.Create(url)
                .Build();

            Assert.Equal(url.ToString(), request.RequestUri.ToString());
        }

        [Fact]
        public void TestMethodIsSet()
        {
            var url = new Uri("http://test.url/");
            var request = HttpRequestBuilder.Create(url)
                .Build();

            Assert.Equal(HttpMethod.Post, request.Method);
        }

        [Fact]
        public void TestContentTypeIsSet()
        {
            var url = new Uri("http://test.url/");
            var request = HttpRequestBuilder.Create(url)
                .SetBody("content")
                .Build();

            Assert.True(request.Content.Headers.Contains("Content-Type"));

            var header = request.Content.Headers.GetValues("Content-Type").First();
            Assert.Equal("application/json; charset=utf-8", header);
        }

        [Fact]
        public void TestTokenIsSet()
        {
            var token = "my-test-token";

            var url = new Uri("http://test.url/");
            var request = HttpRequestBuilder.Create(url)
                .SetAuthToken(token)
                .Build();

            Assert.Equal(token, request.Headers.Authorization.Parameter);
        }

        [Fact]
        public void TestBodyIsSet()
        {
            string json = @"{
                'CurrentClientTemestamp': 1567541309,
                'LastServerTimestamp': 1567541309
            }";

            var url = new Uri("http://test.url/");
            var request = HttpRequestBuilder.Create(url)
                .SetBody(json)
                .Build();

            var body = request.Content.ReadAsStringAsync().Result;

            Assert.Equal(json, body);
        }
    }
}