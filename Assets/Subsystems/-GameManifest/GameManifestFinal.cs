using UnityEngine;
using System.Collections;

public static class GameManifestFinal 
 {

    public static string Get(string key, string _default = "")
    {
        #if RELEASE
        return GameManifestManager.Get(key, _default);
        #else

        var overrideValue = GameManifestOverrider.Get(key);
        if (string.IsNullOrEmpty(overrideValue))
        {
            return GameManifestManager.Get(key, _default);
        }
        else
        {
            return overrideValue;
        }

        #endif
    }


}
