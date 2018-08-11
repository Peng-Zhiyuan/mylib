using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformUtil
{
	public static void DestroyAllChildren(Transform t)
	{
		for(int i = t.childCount - 1; i >= 0; i--)
		{
			var child = t.GetChild(i);
			GameObject.Destroy(child.gameObject);
		}
	}
}
