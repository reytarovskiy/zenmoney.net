using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zenmoney.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int Country { get; set; }
        public string Login { get; set; }
        
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Changed { get; set; }
        public int Currency { get; set; }
        public long PaidTill { get; set; }
        public int? Parent { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string Subscription { get; set; }
    }
}