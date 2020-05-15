using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Zenmoney.Entities
{
    public class Reminder
    {
        public Guid Id { get; set; }
        public int User { get; set; }
        public double Income { get; set; }
        public double Outcome { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Changed { get; set; }
        public int IncomeInstrument { get; set; }
        public int OutcomeInstrument { get; set; }
        public Guid IncomeAccount { get; set; }
        public Guid OutcomeAccount { get; set; }
        public string Comment { get; set; }
        public string Payee { get; set; }
        public string Merchant { get; set; }
        public bool Notify { get; set; }
        public List<Guid> Tag { get; } = new List<Guid>();
        public List<int> Points { get; } = new List<int>();
        public string Interval { get; set; }
        public int? Step { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
