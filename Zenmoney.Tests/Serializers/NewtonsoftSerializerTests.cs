using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Zenmoney.Serializer;

namespace Zenmoney.Tests.Serializers
{
    public class NewtonsoftSerializerTests
    {
        [Fact]
        public void TestDeserializeValidationError()
        {
            var json = @"{
                'error': {
                    'code': 'validationError',
                    'message': 'Wrong format of currentClientTimestamp' 
                }
            }";

            var serializer = new NewtonsoftSerializer();
            var error = serializer.DeserializeValidationError(json);

            Assert.Equal("validationError", error.Code);
            Assert.Equal("Wrong format of currentClientTimestamp", error.Message);
        }
    }
}
