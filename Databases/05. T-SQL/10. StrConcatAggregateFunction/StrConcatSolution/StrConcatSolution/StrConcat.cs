using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.UserDefined,
    MaxByteSize = 8000)]
public struct StrConcat : IBinarySerialize
{
    private const string Delimiter = ", ";
    private string concatenatedString;

    public void Init()
    {
        this.concatenatedString = string.Empty;
    }

    public void Accumulate(SqlString Value)
    {
        if (Value.IsNull)
        {
            return;
        }

        this.concatenatedString += Value.Value + Delimiter;
    }

    public void Merge (StrConcat Group)
    {
        this.concatenatedString += Group.concatenatedString;
    }

    public SqlString Terminate ()
    {
        int concatenatedStringLength = this.concatenatedString.Length;
        string output = this.concatenatedString.Substring(0, concatenatedStringLength - 2);
        return new SqlString(output);
    }

    public void Read(System.IO.BinaryReader r)
    {
        this.concatenatedString = r.ReadString();
    }

    public void Write(System.IO.BinaryWriter w)
    {
        w.Write(this.concatenatedString);
    }
}
