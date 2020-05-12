using Newtonsoft.Json;
using Xunit;
using Zenmoney.Serializer;

namespace Zenmoney.Tests
{
    public class ForceFetchTests
    {
        [Fact]
        public void TestSerializeForceFetch()
        {
            var request = new Request("token", 100, 200);

            request.ForceFetch.Add(Entities.Type.Account);

            var serializer = new NewtonsoftSerializer();

            var json = serializer.SerializeRequest(request);

            var expectedObject = new
            {
                currentClientTimestamp = 100,
                lastServerTimestamp = 200,
                forceFetch = new string[] { "account" }
            };
            string expectedJson = JsonConvert.SerializeObject(expectedObject, Formatting.None);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void TestEmptyForceFetchNotSerializible()
        {
            var request = new Request("token", 100, 200);

            var serializer = new NewtonsoftSerializer();

            var json = serializer.SerializeRequest(request);
            
            var expectedObject = new
            {
                currentClientTimestamp = 100,
                lastServerTimestamp = 200,
            };
            string expectedJson = JsonConvert.SerializeObject(expectedObject, Formatting.None);

            Assert.Equal(expectedJson, json);
        }
    }
}