using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;


public static class NativeBridgeUtil
{

    public static bool IsSubClassOf(Type type, Type baseType)
    {
        var b = type.BaseType;
        while (b != null)
        {
            if (b.Equals(baseType))
            {
                return true;
            }
            b = b.BaseType;
        }
        return false;
    }

    public static bool HasAttribute<T>(Type type)
    {
        return type.GetCustomAttributes(typeof(T), false).Length != 0;
    }

    public static bool HasAttribute(MethodInfo methodIndo, params Type[] attributes)
    {
        bool has = false;
        foreach (var a in attributes)
        {
            has = methodIndo.GetCustomAttributes(a, false).Length != 0;
            if (has)
            {
                break;
            }
        }
        return has; 
    }
}


