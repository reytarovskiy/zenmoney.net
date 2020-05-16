using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Zenmoney.Entities;
using Zenmoney.Serializer;

namespace Zenmoney.Tests.Serializers.Newtonsoft.Accounts
{
    public class SerializationTests
    {
        [Fact]
        public void TestSerializeId()
        {
            var serializer = new NewtonsoftSerializer();
            var id = Guid.NewGuid().ToString();

            var account = new Account { Id = id };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].id").ToObject<string>();
            
            Assert.Equal(id, result);
        }

        [Fact]
        public void TestSerializeUser()
        {
            var serializer = new NewtonsoftSerializer();
            var user = 12345;

            var account = new Account { User = user };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].user").ToObject<int>();

            Assert.Equal(user, result);
        }

        [Fact]
        public void TestSerializeInstrument()
        {
            var serializer = new NewtonsoftSerializer();
            var instrument = 4;

            var account = new Account { Instrument = instrument };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].instrument").ToObject<int>();

            Assert.Equal(instrument, result);
        }

        [Fact]
        public void TestSerializeInstrumentNullable()
        {
            var serializer = new NewtonsoftSerializer();
            int? instrument = null;

            var account = new Account { Instrument = instrument };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].instrument").ToObject<int?>();

            Assert.Equal(instrument, result);
        }

        public static IEnumerable<object[]> SerializeTypeData()
        {
            foreach (Account.AccountType type in Enum.GetValues(typeof(Account.AccountType)))
            {
                yield return new object[] { type, type.ToString().ToLower() };
            }
        }

        [Theory]
        [MemberData(nameof(SerializeTypeData))]
        public void TestSerializeType(Account.AccountType type, string expected)
        {
            var serializer = new NewtonsoftSerializer();

            var account = new Account { Type = type };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].type").ToObject<string>();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestSerializeRole()
        {
            var serializer = new NewtonsoftSerializer();
            var role = 123456;

            var account = new Account { Role = role };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].role").ToObject<int>();

            Assert.Equal(role, result);
        }

        [Fact]
        public void TestSerializeRoleNullable()
        {
            var serializer = new NewtonsoftSerializer();
            int? role = null;

            var account = new Account { Instrument = role };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].role").ToObject<int?>();

            Assert.Equal(role, result);
        }

        [Fact]
        public void TestSerializeChanged()
        {
            var serializer = new NewtonsoftSerializer();
            var time = DateTime.UtcNow;
            var changed = ((DateTimeOffset)time).ToUnixTimeSeconds();

            var account = new Account { Changed = time };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].changed").ToObject<int>();

            Assert.Equal(changed, result);
        }

        [Fact]
        public void TestSerializeCompany()
        {
            var serializer = new NewtonsoftSerializer();
            var company = 123456;

            var account = new Account { Company = company };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].company").ToObject<int>();

            Assert.Equal(company, result);
        }

        [Fact]
        public void TestSerializeTitle()
        {
            var serializer = new NewtonsoftSerializer();
            var title = "test account";

            var account = new Account { Title = title };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].title").ToObject<string>();

            Assert.Equal(title, result);
        }

        [Fact]
        public void TestSerializeSyncId()
        {
            var serializer = new NewtonsoftSerializer();
            var syncId = new List<string> { "test1", "test2" };

            var account = new Account() 
            { 
                SyncID = syncId
            };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].syncID").ToObject<List<string>>();

            Assert.Equal(syncId, result);
        }

        [Fact]
        public void TestSerializeSyncIdNullable()
        {
            var serializer = new NewtonsoftSerializer();
            List<string> syncId = null;

            var account = new Account()
            {
                SyncID = syncId
            };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].syncID").ToObject<List<string>>();

            Assert.Equal(syncId, result);
        }

        [Fact]
        public void TestSerializeBalance()
        {
            var serializer = new NewtonsoftSerializer();
            var balance = 500.500;

            var account = new Account { Balance = balance };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].balance").ToObject<double>();

            Assert.Equal(balance, result);
        }

        [Fact]
        public void TestSerializeBalanceNullable()
        {
            var serializer = new NewtonsoftSerializer();
            double? balance = null;

            var account = new Account { Balance = balance };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].balance").ToObject<double?>();

            Assert.Equal(balance, result);
        }

        [Fact]
        public void TestSerializeStartBalance()
        {
            var serializer = new NewtonsoftSerializer();
            var startBalance = 500.500;

            var account = new Account { StartBalance = startBalance };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].startBalance").ToObject<double>();

            Assert.Equal(startBalance, result);
        }

        [Fact]
        public void TestSerializeStartBalanceNullable()
        {
            var serializer = new NewtonsoftSerializer();
            double? startBalance = null;

            var account = new Account { StartBalance = startBalance };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].startBalance").ToObject<double?>();

            Assert.Equal(startBalance, result);
        }

        [Fact]
        public void TestSerializeCreditLimit()
        {
            var serializer = new NewtonsoftSerializer();
            var creditLimit = 500.500;

            var account = new Account { CreditLimit = creditLimit };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].creditLimit").ToObject<double>();

            Assert.Equal(creditLimit, result);
        }

        [Fact]
        public void TestSerializeCreditLimitNullable()
        {
            var serializer = new NewtonsoftSerializer();
            double? creditLimit = null;

            var account = new Account { CreditLimit = creditLimit };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].creditLimit").ToObject<double?>();

            Assert.Equal(creditLimit, result);
        }

        [Fact]
        public void TestSerializeInBalance()
        {
            var serializer = new NewtonsoftSerializer();
            var inBalance = false;

            var account = new Account { InBalance = inBalance };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].inBalance").ToObject<bool>();

            Assert.Equal(inBalance, result);
        }

        [Fact]
        public void TestSerializeSavings()
        {
            var serializer = new NewtonsoftSerializer();
            var savings = false;

            var account = new Account { Savings = savings };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].savings").ToObject<bool>();

            Assert.Equal(savings, result);
        }

        [Fact]
        public void TestSerializeSavingsNullable()
        {
            var serializer = new NewtonsoftSerializer();
            bool? savings = null;

            var account = new Account { Savings = savings };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].savings").ToObject<bool?>();

            Assert.Equal(savings, result);
        }

        [Fact]
        public void TestSerializeEnableCorrection()
        {
            var serializer = new NewtonsoftSerializer();
            var enableCorrection = false;

            var account = new Account { Savings = enableCorrection };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].enableCorrection").ToObject<bool>();

            Assert.Equal(enableCorrection, result);
        }

        [Fact]
        public void TestSerializeEnableSMS()
        {
            var serializer = new NewtonsoftSerializer();
            var enableSMS = false;

            var account = new Account { EnableSMS = enableSMS };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].enableSMS").ToObject<bool>();

            Assert.Equal(enableSMS, result);
        }

        [Fact]
        public void TestSerializeArchive()
        {
            var serializer = new NewtonsoftSerializer();
            var archive = false;

            var account = new Account { Archive = archive };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].archive").ToObject<bool>();

            Assert.Equal(archive, result);
        }

        [Fact]
        public void TestSerializeCapitalization()
        {
            var serializer = new NewtonsoftSerializer();
            var capitalization = false;

            var account = new Account { Capitalization = capitalization };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].capitalization").ToObject<bool>();

            Assert.Equal(capitalization, result);
        }

        [Fact]
        public void TestSerializePercent()
        {
            var serializer = new NewtonsoftSerializer();
            var percent = 50.55;

            var account = new Account { Percent = percent };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].percent").ToObject<double>();

            Assert.Equal(percent, result);
        }

        [Fact]
        public void TestSerializePercentNullable()
        {
            var serializer = new NewtonsoftSerializer();
            double? percent = null;

            var account = new Account { Percent = percent };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].percent").ToObject<double?>();

            Assert.Equal(percent, result);
        }

        [Fact]
        public void TestSerializeStartDate()
        {
            var serializer = new NewtonsoftSerializer();
            var date = DateTime.Now;

            var account = new Account { StartDate = date };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].startDate").ToObject<string>();

            Assert.Equal(date.ToString("yyyy-MM-dd"), result);
        }

        [Fact]
        public void TestSerializeEndDateOffset()
        {
            var serializer = new NewtonsoftSerializer();
            var offset = 3;

            var account = new Account { EndDateOffset = offset };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].endDateOffset").ToObject<int>();

            Assert.Equal(offset, result);
        }

        public static IEnumerable<object[]> SerializeOffsetIntervalData()
        {
            foreach (Account.OffsetInterval type in Enum.GetValues(typeof(Account.OffsetInterval)))
            {
                yield return new object[] { type, type.ToString().ToLower() };
            }
        }

        [Theory]
        [MemberData(nameof(SerializeOffsetIntervalData))]
        public void TestSerializeOffsetInterval(Account.OffsetInterval interval, string expected)
        {
            var serializer = new NewtonsoftSerializer();

            var account = new Account { EndDateOffsetInterval = interval };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].endDateOffsetInterval").ToObject<string>();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestSerializePayOffStep()
        {
            var serializer = new NewtonsoftSerializer();
            var step = 3;

            var account = new Account { PayoffStep = step };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].payoffStep").ToObject<int>();

            Assert.Equal(step, result);
        }

        public static IEnumerable<object[]> SerializePayOffInterval()
        {
            foreach (Account.PayInterval type in Enum.GetValues(typeof(Account.PayInterval)))
            {
                yield return new object[] { type, type.ToString().ToLower() };
            }
            yield return new object[] { null, "null" };
        }

        [Theory]
        [MemberData(nameof(SerializePayOffInterval))]
        public void TestSerializePayOffInterval(Account.PayInterval interval, string expected)
        {
            var serializer = new NewtonsoftSerializer();

            var account = new Account { PayoffInterval = interval };
            var request = new Request();
            request.Account.Add(account);

            var json = serializer.SerializeRequest(request);
            var result = JToken.Parse(json).SelectToken("account[0].payoffInterval").ToObject<string>();

            Assert.Equal(expected, result);
        }
    }
}
