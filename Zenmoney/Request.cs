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

        public Request() { }

        public Request(string authToken, int currentTimestamp, int lastServerTimestamp)
        {
            AuthToken = authToken;
            CurrentClientTimestamp = currentTimestamp;
            LastServerTimestamp = lastServerTimestamp;
        }

        public bool ShouldSerializeForceFetch()
        {
            return ForceFetch.Count != 0;
        }

        public bool ShouldSerializeAccount()
        {
            return Account.Count != 0;
        }

        public bool ShouldSerializeBudget()
        {
            return Budget.Count != 0;
        }

        public bool ShouldSerializeMerchant()
        {
            return Merchant.Count != 0;
        }

        public bool ShouldSerializeTag()
        {
            return Tag.Count != 0;
        }

        public bool ShouldSerializeTransaction()
        {
            return Transaction.Count != 0;
        }

        public bool ShouldSerializeDeletion()
        {
            return Deletion.Count != 0;
        }
    }
}