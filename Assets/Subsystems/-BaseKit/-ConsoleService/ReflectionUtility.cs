using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Reflection;

public static class ReflectionHelper
{

    /*
	public static List<Type> GetSubClasses<T>()
	{
		var subTypeQuery = from t in typeof(ServiceManager).Assembly.GetTypes()
				where IsSubClassOf(t, typeof(T))
			select t;
		return subTypeQuery.ToList();
	}*/

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

    public static bool HasAttribute<T>(MethodInfo methodIndo)
    {
        return methodIndo.GetCustomAttributes(typeof(T), false).Length != 0;
    }
}
