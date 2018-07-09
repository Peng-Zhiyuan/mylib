using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomLitJson;
using System;
using System.Text;
using System.Reflection;


public static class PathMover
{
    private static List<string> nowPath = new List<string>();
    private static XChangeLog changeLog;

    public static XChangeLog Update(object root, string path, string value)
    {
        nowPath.Clear();
        changeLog = null;
        var pathParts = path.Split('.');
        var obj = root;
        for (int i = 0; i < pathParts.Length; i++)
        {
            var part = pathParts[i];
            if (i != pathParts.Length - 1)
            {
                // enter
                var dic = obj as IDictionary;
                if (dic != null)
                {
                    var key = part;
                    obj = GotoDicChild(dic, key);
                    continue;
                }
                var list = obj as IList;
                if (list != null)
                {
                    var index = part;
                    obj = GotoListChild(list, index);
                    continue;
                }
                var regularObj = obj;
                if (regularObj != null)
                {
                    var feild = part;
                    obj = GotoRegularObjChild(regularObj, feild);
                    continue;
                }
                throw new Exception("path: " + PathToString() + " type is " + obj.GetType().Name + ", but access " + value);
            }
            else
            {
                // set
                var dic = obj as IDictionary;
                if (dic != null)
                {
                    var key = part;
                    SetDic(dic, key, value);
                    continue;
                }
                var list = obj as IList;
                if (list != null)
                {
                    var index = part;
                    SetList(list, index, value);
                    continue;
                }
                var regularObj = obj;
                if (regularObj != null)
                {
                    var feild = part;
                    SetRegularObj(regularObj, feild, value);
                    continue;
                }
                throw new Exception("path: " + PathToString() + " type is " + obj.GetType().Name + ", but set " + value);
            }

        }
        return changeLog;
    }

    private static void SetList(IList list, string index, string valueString)
    {
        int indexInt;
        {
            var success = int.TryParse(index, out indexInt);
            if (!success)
            {
                throw new Exception(PathToString() + " is list, but got index: " + valueString);
            }
        }
        var type = list.GetType();
        var valueType = type.GetGenericArguments()[0];
        var value = Parse(valueType, valueString, () => PathToString() + "." + index);
        var before = list[indexInt];
        list[indexInt] = value;
        var path = PathToString() + "." + index;
        CreateChangeLog(path, valueType, before, value);
    }

    private static void SetDic(IDictionary dic, string key, string valueString)
    {
        var type = dic.GetType();
        var valueType = type.GetGenericArguments()[1];
        var value = Parse(valueType, valueString, () => PathToString() + "." + key);
        var before = dic.Contains(key) ? dic[key] : null;
        dic[key] = value;
        var path = PathToString() + "." + key;
        CreateChangeLog(path, valueType, before, value);
    }

    private static void SetRegularObj(object obj, string field, string valueString)
    {
        var fieldInfo = GetObjFeildInfo(obj, field, true, PathToString);
        if (fieldInfo == null)
        {
            // user may do not want to save this field
            return;
        }
        var valueType = fieldInfo.FieldType;
        var value = Parse(valueType, valueString, () => PathToString() + "." + field);
        var before = fieldInfo.GetValue(obj);
        fieldInfo.SetValue(obj, value);
        var path = PathToString() + "." + field;
        CreateChangeLog(path, valueType, before, value);
    }

    private static FieldInfo GetObjFeildInfo(object obj, string field, bool canNull, Func<string> errorPath)
    {
        var type = obj.GetType();
        var fieldInfo = type.GetField(field, BindingFlags.Public | BindingFlags.Instance);
        if (!canNull && fieldInfo == null)
        {
            throw new Exception("path: " + errorPath?.Invoke() + " is a regular object of type " + type.Name + ", which not defines a public instance field " + field);
        }
        return fieldInfo;
    }

    private static string PathToString()
    {
        var sb = new StringBuilder();
        var first = true;
        foreach (var p in nowPath)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                sb.Append(".");
            }
            sb.Append(p);
        }
        return sb.ToString();
    }

    private static object GotoDicChild(IDictionary dic, string key)
    {
        object ret;
        if (dic.Contains(key))
        {
            ret = dic[key];
        }
        else
        {
            var dicType = dic.GetType();
            var genericType = dicType.GetGenericTypeDefinition();
            if (genericType != typeof(Dictionary<,>))
            {
                throw new Exception("path: " + PathToString() + "." + key + " should be directly closed by generac type Dictionary<,>");
            }

            var keyType = dicType.GetGenericArguments()[0];
            if (keyType != typeof(string))
            {
                throw new Exception("path: " + PathToString() + "." + key + " is a dic, but key type is not string");
            }

            var valueType = dicType.GetGenericArguments()[1];
            var obj = Activator.CreateInstance(valueType);
            dic[key] = obj;
            ret = obj;
        }
        nowPath.Add(key);
        return ret;
    }

    private static object GotoListChild(IList list, string index)
    {
        object ret;
        int indexInt;
        var success = int.TryParse(index, out indexInt);
        if (!success)
        {
            throw new Exception("path: " + PathToString() + " is list, but got index: " + index);
        }
        if (indexInt < list.Count && indexInt >= 0)
        {
            ret = list[indexInt];
        }
        else
        {
            throw new Exception("path: " + PathToString() + " is list, now count is " + list.Count + ", but got index: " + indexInt);
        }
        nowPath.Add(index);
        return ret;
    }

    private static object GotoRegularObjChild(object obj, string field)
    {
        var type = obj.GetType();
        var fieldInfo = type.GetField(field, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        if (fieldInfo == null)
        {
            throw new Exception("path: " + PathToString() + " is a regular object of type " + type.Name + ", which not defines a public instance field " + field);
        }
        var ret = fieldInfo.GetValue(obj);
        if (ret == null)
        {
            var childType = fieldInfo.FieldType;
            var child = Activator.CreateInstance(childType);
            fieldInfo.SetValue(obj, child);
            ret = child;
        }
        nowPath.Add(field);
        return ret;
    }

    private static object Parse(Type type, string valueString, Func<string> errorPath)
    {
        if (type == typeof(int))
        {
            int intValue;
            var success = int.TryParse(valueString, out intValue);
            if (!success)
            {
                throw new Exception(errorPath?.Invoke() + " type is int, but get value: " + valueString);
            }
            return intValue;
        }
        else if (type == typeof(string))
        {
            var stringValue = valueString;
            return stringValue;
        }
        else if (type == typeof(float))
        {
            float floatValue;
            var success = float.TryParse(valueString, out floatValue);
            if (!success)
            {
                throw new Exception(errorPath?.Invoke() + " type is float, but get value: " + valueString);
            }
            return floatValue;
        }
        else if (type == typeof(double))
        {
            double doubleValue;
            var success = double.TryParse(valueString, out doubleValue);
            if (!success)
            {
                throw new Exception(errorPath?.Invoke() + " type is double, but get value: " + valueString);
            }
            return doubleValue;
        }
        else if (type.IsGenericTypeDefinition)
        {

        
            if (type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                return JsonMapper.Instance.ToObject(type, valueString);
            }
            else if (type.GetGenericTypeDefinition() == typeof(List<>))
            {
                return JsonMapper.Instance.ToObject(type, valueString);
            }
        }
        else if (!(type.IsSubclassOf(typeof(ValueType))))
        {
            return JsonMapper.Instance.ToObject(type, valueString);
        }
        return null;
    }

    private static void CreateChangeLog(string path, Type type, object before, object after)
    {
        var log = XChangeLogBank.Take();
        log.before = before;
        log.after = after;
        log.path = path;
        log.delta = 0;
        log.type = type;
        if (type == typeof(int))
        {
            var b = (int)before;
            var a = (int)after;
            var delta = a - b;
            log.delta = delta;
        }
        else if (type == typeof(float))
        {
            var b = (float)before;
            var a = (float)after;
            var delta = a - b;
            log.delta = delta;
        }
        else if (type == typeof(double))
        {
            var b = (double)before;
            var a = (double)after;
            var delta = a - b;
            log.delta = delta;
        }
        changeLog = log;
    }


}
