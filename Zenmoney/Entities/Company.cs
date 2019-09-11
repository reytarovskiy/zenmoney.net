using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zenmoney.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Www { get; set; }
        public int? Country { get; set; }
        public object FullTitle { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Changed { get; set; }
        public bool Deleted { get; set; }
        public string CountryCode { get; set; }
    }
}