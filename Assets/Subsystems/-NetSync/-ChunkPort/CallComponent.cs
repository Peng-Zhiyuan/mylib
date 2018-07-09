using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public partial class ChunkPort
{
    public class CallComponent
    {
        ChunkPort chunkPort;
        private Dictionary<UInt16, Action<object[]>> methodDic = new Dictionary<ushort, Action<object[]>>();

        private Dictionary<Type, byte> typeToCode = new Dictionary<Type, byte>();
        private Dictionary<byte, Type> codeToType = new Dictionary<byte, Type>();

        public CallComponent(ChunkPort chunkPort)
        {
            this.chunkPort = chunkPort;

            RegisterType(typeof(int));
            RegisterType(typeof(short));
            RegisterType(typeof(byte));
            RegisterType(typeof(float));
            RegisterType(typeof(double));
            RegisterType(typeof(bool));
            RegisterType(typeof(string));
            RegisterType(typeof(Vector2));
            RegisterType(typeof(Vector3));
        }

        private byte nextCode = 0;
        public void RegisterType(Type type)
        {
            if (codeToType.Count == byte.MaxValue)
            {
                throw new Exception(string.Format("[ChunkPort] type register table has rached max count {0}",byte.MaxValue));
            }
            nextCode++;
            codeToType[nextCode] = type;
            typeToCode[type] = nextCode;
        }


        public void RegisterMethod(UInt16 id, Action<object[]> method)
        {
            methodDic[id] = method;
        }

        private byte GetTypeCode(Type type)
        {
            byte code;
            typeToCode.TryGetValue(type, out code);
            if (code == 0)
            {
                throw new Exception(string.Format("[ChunkPort] type of {} not registered",type.Name));
            }
            return code;
        }

        private Type GetType(byte code)
        {
            Type type;
            codeToType.TryGetValue(code, out type);
            if (type == null)
            {
                throw new Exception(string.Format("[ChunkPort] type code {0} not registered",code));
            }
            return type;
        }

        public void Send(UInt16 id, params object[] args)
        {
            var chunk = new Chunk();
            chunk.id = id;
            chunk.data = CallParamToData(args);
            chunkPort.OnComponentSendChunk(chunk);
        }

        private byte[] CallParamToData(object[] args)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                var argCount = args.Length;
                if (argCount > 255)
                {
                    throw new Exception("[ChunkPort] args count count more than 255");
                }
                stream.WriteByte((byte)argCount);
                foreach (var a in args)
                {
                    var type = a.GetType();
                    var typeCode = GetTypeCode(type);
                    stream.WriteByte(typeCode);
                    if (type == typeof(int))
                    {
                        writer.Write((int)a);
                    }
                    else if (type == typeof(float))
                    {
                        writer.Write((float)a);
                    }
                    else if (type == typeof(double))
                    {
                        writer.Write((double)a);
                    }
                    else if (type == typeof(string))
                    {
                        writer.Write((string)a);
                    }
                    else if (type == typeof(bool))
                    {
                        writer.Write((bool)a);
                    }
                    else if (type == typeof(Vector2))
                    {
                        var vector2 = (Vector2)a;
                        writer.Write(vector2.x);
                        writer.Write(vector2.y);
                    }
                    else if (type == typeof(Vector3))
                    {
                        var vector3 = (Vector3)a;
                        writer.Write(vector3.x);
                        writer.Write(vector3.y);
                        writer.Write(vector3.z);
                    }
                    else if (a is IChunkable)
                    {
                        ((IChunkable)a).Write(writer);
                    }
                    else
                    {
                        throw new Exception(string.Format("[ChunkPort] type {0} not support yet",a.GetType()));
                    }
                }
                var data = stream.ToArray();
                return data;
            }
        }

        private object[] DataToCallParam(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                var reader = new BinaryReader(stream);
                var argCount = reader.ReadByte();
                var args = new object[argCount];
                for (int i = 0; i < argCount; i++)
                {
                    var typeCode = reader.ReadByte();
                    var type = GetType(typeCode);
                    object value;
                    if (type == typeof(int))
                    {
                        value = reader.ReadInt32();
                    }
                    else if (type == typeof(short))
                    {
                        value = reader.ReadInt16();
                    }
                    else if (type == typeof(byte))
                    {
                        value = reader.ReadByte();
                    }
                    else if (type == typeof(float))
                    {
                        value = reader.ReadSingle();
                    }
                    else if (type == typeof(double))
                    {
                        value = reader.ReadDouble();
                    }
                    else if (type == typeof(string))
                    {
                        value = reader.ReadString();
                    }
                    else if (type == typeof(bool))
                    {
                        value = reader.ReadBoolean();
                    }
                    else if (type == typeof(Vector2))
                    {
                        var vector2 = new Vector2();
                        var x = reader.ReadSingle();
                        var y = reader.ReadSingle();
                        vector2.x = x;
                        vector2.y = y;
                        value = vector2;
                    }
                    else if (type == typeof(Vector3))
                    {
                        var vector3 = new Vector3();
                        var x = reader.ReadSingle();
                        var y = reader.ReadSingle();
                        var z = reader.ReadSingle();
                        vector3.x = x;
                        vector3.y = y;
                        vector3.z = z;
                        value = vector3;
                    }
                    else if (typeof(IChunkable).IsAssignableFrom(type))
                    {
                        var instance = Activator.CreateInstance(type);
                        var chunable = (IChunkable)instance;
                        chunable.Read(reader);
                        value = instance;
                    }
                    else
                    {
                        throw new Exception(string.Format("[ChunkPort] type {0} reader not support yet.",typeCode));
                    }
                    args[i] = value;
                }
                return args;
            }
        }

        public bool OnChunkArrival(Chunk chunk)
        {
            var id = chunk.id;
            var data = chunk.data;
            Action<object[]> method;
            methodDic.TryGetValue(id, out method);
            if (method != null)
            {
                var args = DataToCallParam(data);
                method(args);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Action<object[]> TryGetEventHandler(UInt16 id)
        {
            Action<object[]> handler;
            methodDic.TryGetValue(id, out handler);
            return handler;
        }
    }

}
