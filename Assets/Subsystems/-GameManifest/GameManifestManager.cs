using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edroity;
using CustomLitJson;
using System;

public static class GameManifestManager
{
    private static JsonData manifest; 
    private static string EDITOR_MANIFEST_RESOURCES_PATH = "Config/game-manifest";

    private static string GetRawString()
    {
        if (Application.isEditor)
        {
            return GetRowStringFromEditor();
        }
        else
        {
            return NativeBridge.SyncCall("GameManifestBridge", "GetRawString");
        }
    }

    private static string GetRowStringFromEditor()
    {
        var textAsset = Resources.Load<TextAsset>(EDITOR_MANIFEST_RESOURCES_PATH);
        if (textAsset == null)
        {
            Debug.LogException(new Exception("Resources : " + EDITOR_MANIFEST_RESOURCES_PATH + " not found"));
        }
        return textAsset.text;
    }

    public static string Get(string key, string defaultValue)
    {
        if(manifest == null)
        {
            var raw = GetRawString();
            var jd = JsonMapper.Instance.ToObject(raw);
            if (jd.IsObject)
            {
                manifest = jd;
            }
            else
            {
                throw new Exception("game-manifest is not a valid json!, raw: " + raw);
            }
        }
        return manifest.TryGet<string>(key, defaultValue);
    }
}
