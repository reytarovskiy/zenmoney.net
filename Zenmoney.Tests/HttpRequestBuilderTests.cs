using System.IO;
using System.Linq;
using System.Net.Http;
using Xunit;
using Zenmoney;

namespace Zenmoney.Tests 
{
    public class HttpRequestBuilderTests
    {
        [Fact]
        public void TestUrlIsSet()
        {
            var url = "http://test.url/";
            var request = HttpRequestBuilder.Create(url)
                .Build();
            
            Assert.Equal(url, request.RequestUri.ToString());
        }

        [Fact]
        public void TestMethodIsSet()
        {
            var request = HttpRequestBuilder.Create("http://test.url/")
                .Build();

            Assert.Equal(HttpMethod.Post, request.Method);
        }
        
        [Fact]
        public void TestContentTypeIsSet()
        {
            var request = HttpRequestBuilder.Create("http://test.url/")
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
            
            var request = HttpRequestBuilder.Create("http://test.url/")
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

            var request = HttpRequestBuilder.Create("http://test.url/")
                .SetBody(json)
                .Build();
            
            var body = request.Content.ReadAsStringAsync().Result;

            Assert.Equal(json, body);
        }
    }
}