using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zenmoney.Entities
{
    public class Account
    {
        public enum AccountType
        {
            [EnumMember(Value = "cash")]
            Cash = 1,
            [EnumMember(Value = "ccard")]
            Ccard,
            [EnumMember(Value = "checking")]
            Checking,
            [EnumMember(Value = "loan")]
            Loan,
            [EnumMember(Value = "deposit")]
            Deposit,
            [EnumMember(Value = "emoney")]
            Emoney,
            [EnumMember(Value = "debt")]
            Debt
        }

        public enum OffsetInterval
        {
            [EnumMember(Value = "day")]
            Day,
            [EnumMember(Value = "week")]
            Week,
            [EnumMember(Value = "month")]
            Month,
            [EnumMember(Value = "year")]
            Year,
        }

        public enum PayInterval
        {
            [EnumMember(Value = "month")]
            Month,
            [EnumMember(Value = "year")]
            Year,
        }

        public string Id { get; set; }
        public int User { get; set; }
        public int? Instrument { get; set; }
        public AccountType Type { get; set; }
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
        public DateTime? Changed { get; set; }
        public List<string> SyncID { get; set; }
        public bool EnableSMS { get; set; }
        public int? EndDateOffset { get; set; }
        public OffsetInterval? EndDateOffsetInterval { get; set; }
        public int? PayoffStep { get; set; }
        public PayInterval? PayoffInterval { get; set; }
    }
}