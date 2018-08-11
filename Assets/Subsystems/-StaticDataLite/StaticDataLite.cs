using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomLitJson;

public static class StaticDataLite
{
	static JsonData data;

	public static void Init()
	{
		var textAsset = Resources.Load<TextAsset>("static-data-lite/etu");
		var json = textAsset.text;
		var jo = JsonMapper.Instance.ToObject(json);
		data = jo;
	}

	public static JsonData GetSheet(string names)
	{
		return data.TryGet<JsonData>(names, null);
	}

	public static JsonData GetRow(string name, string id)
	{
		var sheet = GetSheet(name);
		if(sheet == null)
		{
			return null;
		}
		return sheet.TryGet<JsonData>(id, null);
	}

	public static T GetCell<T>(string sheetName, string id, string fieldName)
	{
		var row = GetRow(sheetName, id);
		if(row == null)
		{
			return default(T);
		}
		return row.TryGet<T>(fieldName, default(T));
	}
}
