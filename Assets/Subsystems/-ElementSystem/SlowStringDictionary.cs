using UnityEngine;
using System.Collections.Generic;

/// Usage:
/// 
/// [System.Serializable]
/// class MyDictionary : SerializableDictionary<int, GameObject> {}
/// public MyDictionary dic;
///
[System.Serializable]
public class SlowStringDictionary
{
    // We save the keys and values in two lists because Unity does understand those.
    [SerializeField]
    private List<string> _keys;
    [SerializeField]
    private List<string> _values;

    public string Get(string key)
    {
        var index = _keys.IndexOf(key);
        if (index == -1)
        {
            return null;
        }
        else
        {
            if (index < _values.Count)
            {
                return _values[index];
            }
            else
            {
                return null;
            }
        }
    }

    public void Set(string key, string value)
    {
        var index = _keys.IndexOf(key);
        if (index == -1)
        {
            _keys.Add(key);
            _values.Add(value);
        }
        else
        {
            _values[index] = value;
        }
    }

    public List<string> Keys
    {
        get
        {
            var keys = new List<string>();
            keys.AddRange(_keys);
            return keys;
        }
    }

    public void Remove(string key)
    {
        var index = _keys.IndexOf(key);
        if(index == -1) return;
        _keys.RemoveAt(index);
        _values.RemoveAt(index);
    }
}