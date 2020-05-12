using System;
using System.Collections.Generic;
using System.Text;
using Zenmoney.Errors;

namespace Zenmoney.Serializer
{
    public interface ISerializer
    {
        string SerializeRequest(Request request);

        SyncResult DeserializeSyncResult(string json);

        ValidationError DeserializeValidationError(string json);
    }
}
