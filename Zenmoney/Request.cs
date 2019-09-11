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
    }
}