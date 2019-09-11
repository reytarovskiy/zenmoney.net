using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zenmoney
{
    public class Client
    {
        private string url;
        private HttpClient httpClient;

        public Client(string url = "http://api.zenmoney.ru/v8/diff/")
        {
            this.url = url;

            this.httpClient = new HttpClient();
        }

        public async Task<SyncResult> Sync(Request request)
        {
            var httpRequest = HttpRequestBuilder.CreateFromRequest(this.url, request);

            var response = await this.httpClient.SendAsync(httpRequest);

            var content = await response.Content.ReadAsStringAsync();

            var syncResult = JsonConvert.DeserializeObject<SyncResult>(content, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });

            return syncResult;
        }
    }
}