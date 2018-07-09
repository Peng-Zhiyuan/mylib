using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public partial class ChunkPort
{
    public class ObjectComponent
    {
        ChunkPort chunkPort;

        private Dictionary<Type, UInt16> typeToCode = new Dictionary<Type, UInt16>();
        private Dictionary<UInt16, Type> codeToType = new Dictionary<UInt16, Type>();

        public event Action<object> Arrival;

        public ObjectComponent(ChunkPort chunkPort)
        {
            this.chunkPort = chunkPort;
        }

        public void RegisterType(UInt16 id, Type type)
        {
            codeToType[id] = type;
            typeToCode[type] = id;
        }

        private UInt16 GetTypeCode(Type type)
        {
            UInt16 code;
            typeToCode.TryGetValue(type, out code);
            if (code == 0)
            {
                throw new Exception(string.Format("[ChunkPort] type of {0} not registered",type.Name));
            }
            return code;
        }

        private Type GetType(UInt16 code)
        {
            Type type;
            codeToType.TryGetValue(code, out type);
            if (type == null)
            {
                throw new Exception(string.Format("[ChunkPort] type code {0} not registered",type.Name));
            }
            return type;
        }

        public void Send(object obj)
        {
            var chunk = new Chunk();
            var type = obj.GetType();
            var typeCode = GetTypeCode(type);
            chunk.id = typeCode;
            chunk.data = ObjectToData(obj);
            chunkPort.OnComponentSendChunk(chunk);
        }

        public void OnChunkArrival(Chunk chunk)
        {
            var id = chunk.id;
            var data = chunk.data;
            var type = GetType(id);
            var obj = DataToObject(data, type);
            if(Arrival != null) Arrival.Invoke(obj);
        }

        private byte[] ObjectToData(object obj)
        {
            var chunable = obj as IChunkable;
            if (chunable != null)
            {
                var stream = new MemoryStream();
                var writer = new BinaryWriter(stream);
                chunable.Write(writer);
                var data = stream.ToArray();
                stream.Dispose();
                return data;
            }
            else
            {
                throw new Exception(string.Format("[ObjectComponent] obj of type: {0} can't translate to byte[]",obj.GetType()));
            }
        }

        private object DataToObject(byte[] data, Type type)
        {
            var obj = Activator.CreateInstance(type);
            var chunable = obj as IChunkable;
            if(chunable != null)
            {
                var stream = new MemoryStream(data);
                var reader = new BinaryReader(stream);
                chunable.Read(reader);
                stream.Dispose();
                return obj;
            }
            else
            {
                throw new Exception(string.Format("[ObjectComponent] obj of type: {0} can't read from to byte[]",obj.GetType()));
            }
        }
    }
}
