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
        public string StartDate { get; set; }
        public bool? Capitalization { get; set; }
        public double? Percent { get; set; }
        public int Changed { get; set; }
        public string[] SyncID { get; set; }
        public bool EnableSMS { get; set; }
        public int? EndDateOffset { get; set; }
        public string EndDateOffsetInterval { get; set; }
        public int? PayoffStep { get; set; }
        public string PayoffInterval { get; set; }
    }
}