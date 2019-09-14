using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Zenmoney.Entities;

namespace Zenmoney
{
    public class Request
    {
        [JsonIgnore]
        public string AuthToken { get; set; }

        public Int32 CurrentClientTimestamp { get; set; }

        public Int32 LastServerTimestamp { get; set; }

        public List<Entities.Type> ForceFetch { get; set; } = new List<Entities.Type>();

        public List<Account> Account { get; set; } = new List<Account>();

        public List<Budget> Budget { get; set; } = new List<Budget>();

        public List<Merchant> Merchant { get; set; } = new List<Merchant>();

        public List<Tag> Tag { get; set; } = new List<Tag>();

        public List<Transaction> Transaction { get; set; } = new List<Transaction>(); 

        public Request() { }

        public Request(string authToken, Int32 currentTimestamp, Int32 lastServerTimestamp)
        {
            this.AuthToken = authToken;
            this.CurrentClientTimestamp = currentTimestamp;
            this.LastServerTimestamp = lastServerTimestamp;
        }

        public bool ShouldSerializeForceFetch()
        {
            return this.ForceFetch.Count != 0;
        }

        public bool ShouldSerializeAccount()
        {
            return this.Account.Count != 0;
        }

        public bool ShouldSerializeBudget()
        {
            return this.Budget.Count != 0;
        }

        public bool ShouldSerializeMerchant()
        {
            return this.Merchant.Count != 0;
        }

        public bool ShouldSerializeTag()
        {
            return this.Tag.Count != 0;
        }

        public bool ShouldSerializeTransaction()
        {
            return this.Transaction.Count != 0;
        }
    }
}