using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zenmoney.Entities 
{
    public class Merchant
    {
        public string Id { get; set; }
        public int User { get; set; }
        public string Title { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Changed { get; set; }
    }
}
