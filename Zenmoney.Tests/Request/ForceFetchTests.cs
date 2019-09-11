using Newtonsoft.Json;
using Xunit;

namespace Zenmoney.Tests
{
    public class ForceFetchTests
    {
        [Fact]
        public void TestSerializeForceFetch()
        {
            var request = new Request("token", 100, 200);

            request.ForceFetch.Add(Entities.Type.Account);

            var json = JsonConvert.SerializeObject(request, ZenmoneyJsonSettings.ZenmoneyRequestJsonSerializeSetting);

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

            var json = JsonConvert.SerializeObject(request, ZenmoneyJsonSettings.ZenmoneyRequestJsonSerializeSetting);
            
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