using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using Zenmoney.Errors;

namespace Zenmoney.Serializer
{
    public class NewtonsoftSerializer : ISerializer
    {
        private readonly JsonSerializerSettings RequestSerializeSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
            Formatting = Formatting.None
        };

        public SyncResult DeserializeSyncResult(string json)
        {
            return JsonConvert.DeserializeObject<SyncResult>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });
        }

        public ValidationError DeserializeValidationError(string json)
        {
            return JToken.Parse(json)
                .SelectToken("error")
                .ToObject<ValidationError>();
        }

        public string SerializeRequest(Request request)
        {
            return JsonConvert.SerializeObject(request, RequestSerializeSettings);
        }
    }
}
