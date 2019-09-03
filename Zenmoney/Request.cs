using System;

namespace Zenmoney 
{
    public class Request
    {
        public string AuthToken { get; set; }
        public Int32 CurrentClientTimestamp { get; set; }
        public Int32 LastServerTimestamp { get; set; }
    }
}