using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

// TODO: 底层改成playerpref
/// <summary>
/// 持久化系统提供任意数量的数据表用于记录数据
/// 使用 GetTable() 获得某一张数据表
/// 使用 Read() 从硬盘上加载数据到内存
/// 使用 Write() 从内存写数据到硬盘
/// </summary>
public static class PersistenceManager
{

    static Dictionary<string, Table> tables = new Dictionary<string, Table>();

	// 获得表，如果不存在则创建
	public static Table GetTable(string name)
	{
		if(tables.ContainsKey(name)) return tables[name];
		var table = new Table();
		tables[name] = table;
		return table;
	}

	public static void Write()
	{
		var path = Path.Combine(Application.persistentDataPath, "data");
		Debug.Log("[PersistenceService]: path: " + path);
		var stream = File.OpenWrite(path);
		var writer = new BinaryWriter(stream);
		// table count
		var count = tables.Count;
		writer.Write(count);
		foreach(var kv in tables)
		{
			// name, table
			var name = kv.Key;
			var table = kv.Value;
			writer.Write(name);
			WriteTable(table, writer);
		}
		writer.Close();
	}

	public static void Read()
	{
		tables.Clear();
        try
        {
            var path = Path.Combine(Application.persistentDataPath, "data");
            Debug.Log("[PersistenceService]: path: " + path);
            var stream = File.OpenRead(path);
            var reader = new BinaryReader(stream);
            // table count
            var count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                // name, table
                var name = reader.ReadString();
                var table = new Table();
                ReadTable(table, reader);
                tables[name] = table;
            }
            reader.Close();
        }
        catch(Exception e)
        {
            tables.Clear();
        }
	}

    private static void WriteTable(Table table, BinaryWriter writer)
    {
        // table size
        var size = table.Count;
        writer.Write(size);
        foreach (var kv in table)
        {
            // key name
            writer.Write(kv.Key);
            // key type
            object value = kv.Value;
            if (value is string)
            {
                writer.Write((byte)1);
                writer.Write((string)value);
            }
            else if (value is int)
            {
                writer.Write((byte)2);
                writer.Write((double)value);
            }
            else if (value is float)
            {
                writer.Write((byte)3);
                writer.Write((float)value);
            }
        }
    }

    public static void ReadTable(Table table, BinaryReader reader)
    {
        var size = reader.ReadInt32();
        for (int i = 0; i < size; i++)
        {
            var key = reader.ReadString();
            var type = reader.ReadByte();
            object value = null;
            switch (type)
            {
                case 1:
                    value = reader.ReadString();
                    break;
                case 2:
                    value = reader.ReadInt32();
                    break;
                case 3:
                    value = reader.ReadSingle();
                    break;
            }
            table[key] = value;
        }
    }

}

public class Table : Dictionary<string, object>
{
	public object Get(string key, object _defaul = null)
	{
		object ret; 
		var has = this.TryGetValue(key, out ret);
		if(has) return ret;
		return _defaul;
	}

    new public object this[string key]
    {
        get
        {
            return Get(key);
        }
        set
        {
            Set(key, value);
        }
    }

	public void Set(string key, object value)
	{
        var type = value.GetType();
        
        if(type != typeof(float) && type != typeof(string) && type != typeof(int))
        {
            throw new Exception("Table 不支持" + type.Name + "类型的数据");
        }
        base[key] = value;
	}




	
}
