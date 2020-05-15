using System.Collections.Generic;
using Newtonsoft.Json;
using Zenmoney.Entities;

namespace Zenmoney
{
    public class Request
    {
        [JsonIgnore]
        public string AuthToken { get; }

        public int CurrentClientTimestamp { get; }

        public int LastServerTimestamp { get; }

        public List<Type> ForceFetch { get; } = new List<Entities.Type>();

        public List<Account> Account { get; } = new List<Account>();

        public List<Budget> Budget { get; } = new List<Budget>();

        public List<Merchant> Merchant { get; } = new List<Merchant>();

        public List<Tag> Tag { get; } = new List<Tag>();

        public List<Transaction> Transaction { get; } = new List<Transaction>();

        public List<Deletion> Deletion { get; } = new List<Deletion>();

        public List<Reminder> Reminder { get; } = new List<Reminder>();

        public List<ReminderMarker> ReminderMarker { get; } = new List<ReminderMarker>();

        public Request() { }

        public Request(string authToken, int currentTimestamp, int lastServerTimestamp)
        {
            AuthToken = authToken;
            CurrentClientTimestamp = currentTimestamp;
            LastServerTimestamp = lastServerTimestamp;
        }

        public bool ShouldSerializeForceFetch() => ForceFetch.Count > 0;

        public bool ShouldSerializeAccount() => Account.Count > 0;

        public bool ShouldSerializeBudget() => Budget.Count > 0;

        public bool ShouldSerializeMerchant() => Merchant.Count > 0;

        public bool ShouldSerializeTag() => Tag.Count > 0;

        public bool ShouldSerializeTransaction() => Transaction.Count > 0;

        public bool ShouldSerializeDeletion() => Deletion.Count > 0;

        public bool ShouldSerializeReminder() => Reminder.Count > 0;

        public bool ShouldSerializeReminderMarker() => ReminderMarker.Count > 0;
    }
}