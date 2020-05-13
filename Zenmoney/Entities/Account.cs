using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zenmoney.Entities
{
    public class Account
    {
        public string Id { get; set; }
        public int? User { get; set; }
        public int? Instrument { get; set; }
        public string Type { get; set; }
        public int? Role { get; set; }
        public bool Private { get; set; }
        public bool? Savings { get; set; }
        public string Title { get; set; }
        public bool InBalance { get; set; }
        public double? CreditLimit { get; set; }
        public double? StartBalance { get; set; }
        public double? Balance { get; set; }
        public int? Company { get; set; }
        public bool Archive { get; set; }
        public bool EnableCorrection { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? Capitalization { get; set; }
        public double? Percent { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Changed { get; set; }
        public List<string> SyncID { get; }
        public bool EnableSMS { get; set; }
        public int? EndDateOffset { get; set; }
        public string EndDateOffsetInterval { get; set; }
        public int? PayoffStep { get; set; }
        public string PayoffInterval { get; set; }
    }
}