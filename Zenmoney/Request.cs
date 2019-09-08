using System;
using Newtonsoft.Json;

namespace Zenmoney 
{
    public class Request
    {
        [JsonIgnore]
        public string AuthToken { get; set; }
        public Int32 CurrentClientTimestamp { get; set; }
        public Int32 LastServerTimestamp { get; set; }

        public Request() { }

        public Request(string authToken, Int32 currentTimestamp, Int32 lastServerTimestamp)
        {
            this.AuthToken = authToken;
            this.CurrentClientTimestamp = currentTimestamp;
            this.LastServerTimestamp = lastServerTimestamp;
        }
    }
}