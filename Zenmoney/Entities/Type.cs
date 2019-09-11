using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zenmoney.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Type
    {
        [EnumMember(Value = "user")]
        User = 1,
        [EnumMember(Value = "account")]
        Account,
        [EnumMember(Value = "budget")]
        Budget,
        [EnumMember(Value = "company")]
        Company,
        [EnumMember(Value = "instrument")]
        Instrument,
        [EnumMember(Value = "merchant")]
        Merchant,
        [EnumMember(Value = "tag")]
        Tag,
        [EnumMember(Value = "transaction")]
        Transaction
    }
}