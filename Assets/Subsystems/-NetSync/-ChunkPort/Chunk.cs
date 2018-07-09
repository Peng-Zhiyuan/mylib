using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public struct Chunk
{
    public UInt16 id;
    public byte[] data;

    public static void WriteToStream(Chunk chunk, Stream stream)
    {
        var writer = new BinaryWriter(stream);
        writer.Write(chunk.id);
        var dataSize = (UInt16)chunk.data.Length;
        writer.Write(dataSize);
        writer.Write(chunk.data);
 
    }

    public static Chunk ReadFromStream(Stream stream)
    {
        var ret = new Chunk();
        var reader = new BinaryReader(stream);
        ret.id = reader.ReadUInt16();
        var datasize = reader.ReadUInt16();
        ret.data = reader.ReadBytes(datasize);
        return ret;
    }
}