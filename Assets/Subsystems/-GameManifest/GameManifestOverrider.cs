using UnityEngine;
using System.Collections;
using System;

public class GameManifestOverrider : MonoBehaviour {

    public static event Action<string> Changed;

    public static void Set(string key, string value)
    {
        PlayerPrefs.SetString("manifest-" + key, value);
        PlayerPrefs.Save();
        if (Changed != null)
        {
            Changed(key);
        }
    }

    public static string Get(string key, string _default = "")
    {
        return PlayerPrefs.GetString("manifest-" + key, _default);
    }

    public static void Delete(string key)
    {
        PlayerPrefs.DeleteKey("manifest-" + key);
        PlayerPrefs.Save();
        if (Changed != null)
        {
            Changed(key);
        }
    }

}
