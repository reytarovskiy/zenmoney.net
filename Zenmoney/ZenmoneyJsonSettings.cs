using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Zenmoney
{
    public static class ZenmoneyJsonSettings
    {
        private static JsonSerializerSettings requestSettings;

        public static JsonSerializerSettings ZenmoneyRequestJsonSerializeSetting
        {
            get
            {
                if (ZenmoneyJsonSettings.requestSettings == null)
                {
                    var contractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() };
                    var jsonSettings = new JsonSerializerSettings
                    {
                        ContractResolver = contractResolver,
                        Formatting = Formatting.None
                    };

                    ZenmoneyJsonSettings.requestSettings = jsonSettings;
                }


                return ZenmoneyJsonSettings.requestSettings;
            }
        }
    }
}