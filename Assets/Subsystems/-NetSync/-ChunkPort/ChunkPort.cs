using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public partial class ChunkPort
{
    public CallComponent call;
    public ObjectComponent obj;

    public event Action<byte[]>  SendBinaryData;

    public ChunkPort()
    {
        call = new CallComponent(this);
        obj = new ObjectComponent(this);
    }

    private void OnComponentSendChunk(Chunk chunk)
    {
        var stream = new MemoryStream();
        Chunk.WriteToStream(chunk, stream);
        var data = stream.ToArray();
        stream.Dispose();
        if(SendBinaryData != null) SendBinaryData.Invoke(data);
    }

    public void OnBinaryDataArrival(byte[] data)
    {
        var stream = new MemoryStream(data);
        var chunk = Chunk.ReadFromStream(stream);
        stream.Dispose();

        var dealed = call.OnChunkArrival(chunk);
        if(!dealed)
        {
            obj.OnChunkArrival(chunk);
        }
    }

}
