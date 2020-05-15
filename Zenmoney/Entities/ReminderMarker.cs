using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Zenmoney.Entities
{
    public class ReminderMarker
    {
        public enum ReminderState
        {
            [EnumMember(Value = "planned")]
            Planned,
            [EnumMember(Value = "processed")]
            Processed,
            [EnumMember(Value = "deleted")]
            Deleted,
        }

        public Guid Id { get; set; }
        public int User { get; set; }
        public DateTime Date { get; set; }
        public double Income { get; set; }
        public double Outcome { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Changed { get; set; }
        public int IncomeInstrument { get; set; }
        public int OutcomeInstrument { get; set; }
        public ReminderState State { get; set; }
        public Guid Reminder { get; set; }
        public Guid IncomeAccount { get; set; }
        public Guid OutcomeAccount { get; set; }
        public string Comment { get; set; }
        public string Payee { get; set; }
        public Guid? Merchant { get; set; }
        public bool Notify { get; set; }
        public List<Guid> Tag { get; } = new List<Guid>();
    }
}
