using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class GameObjectUtil
{
    public static T TryGetComponent<T>(GameObject a) where T: Component
    {
        var c = a.GetComponent<T>();
        if(c != null)
        {
            return c;
        }
        return a.AddComponent<T>();
    }
}