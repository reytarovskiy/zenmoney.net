using System;
using System.Collections.Generic;
using System.Text;

namespace Zenmoney.Serializer
{
    public interface ISerializer
    {
        string SerializeRequest(Request request);

        SyncResult DeserializeSyncResult(string json);
    }
}
