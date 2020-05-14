using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zenmoney.Entities
{
    public class Deletion
    {
        public Type Object { get; set; }

        public int User { get; set; }

        public string Id { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Stamp { get; set; }
    }
}
