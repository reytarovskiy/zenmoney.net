using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zenmoney.Entities
{
    public class Budget
    {
        public int User { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Changed { get; set; }
        public string Date { get; set; }
        public string Tag { get; set; }
        public double Income { get; set; }
        public double Outcome { get; set; }
        public bool IncomeLock { get; set; }
        public bool OutcomeLock { get; set; }
    }
}