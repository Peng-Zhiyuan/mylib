using UnityEngine;
using System.Collections;
using CustomLitJson;
using UnityEngine.Assertions;

public static class GameManifestManager {
    
    public static JsonData _manifest;
    public static JsonData _coreManifest;
    public static JsonData Manifest
    {
        get
        {
            if (_manifest == null)
            {
                string jsonString = null;
                jsonString = NativeBridge.SyncCall("NativeGameManifestManager", "GetManifest");

                Debug.Log("[GameManifestManager] manifest: " + jsonString);
                if(!string.IsNullOrEmpty(jsonString))
                {
                    _manifest = JsonMapper.Instance.ToObject(jsonString);
                }
                else
                {
                    _manifest = new JsonData();
                }
            }
            return _manifest;
        }
    }

    public static JsonData CoreManifest
    {
        get
        {
            if (_coreManifest == null)
            {
                var textAsset = Resources.Load<TextAsset>("game-manifest/game-manifest");
                var jsonString = textAsset.text;
                Debug.Log("[GameManifestManager] core-manifest: " + jsonString);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    _coreManifest = JsonMapper.Instance.ToObject(jsonString);
                }
                else
                {
                    _coreManifest = new JsonData();
                }
            }
            return _coreManifest;
        }
    }

    public static string Get(string key, string defaultValue = "")
    {
        Assert.IsTrue(Application.isPlaying, "GameManifestManager can't running on editor script, use GameManifestEditor instead.");

        var conf = Manifest;
        if (((IDictionary)conf).Contains(key))
        {
            return conf[key].ToString();
        }

        var coreConf = CoreManifest;
        if (((IDictionary)coreConf).Contains(key))
        {
            return coreConf[key].ToString();
        }

        return defaultValue;
    }

}
