using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class MonoUtil
{
    public static Transform FindRecursively(this Transform transform, string name)
    {
        if (transform == null)
        {
            throw new System.ArgumentNullException("transform");
        }
        return _FindRecursively(transform, name);
    }
	public static Transform FindByPath(this Transform tran,string path)
	{
		string[] nodes = path.Split('/');
		int index = 0;
		Transform tarTran = tran;
		while(index < nodes.Length)
		{
			string node =nodes[index];
			tarTran = tarTran.Find(node);
			if(tarTran == null)break;
			index++;
		}
		return tarTran;
	}
    public static Transform FindByPathIncludeRoot(this Transform tran, string path)
    {
        string[] nodes = path.Split('/');
        int index = 0;
        Transform tarTran = null;
        while(index < nodes.Length)
        {
            string node =nodes[index];
            if (index == 0)
            {
                if (node != tran.name)
                {
                    return null;
                }
                else
                {
                    tarTran = tran;
                }
            }
            else
            {
                tarTran = tarTran.Find(node);
                if (tarTran == null)
                    break;
            }
            index++;
        }
        return tarTran;
    }

	public static string GetPath(GameObject go,Transform root)
	{
		string path = go.name;
		Transform tran = go.transform;
		while (tran.parent != null && tran.name!=root.name)
		{
			tran = tran.parent;
			path = tran.name +"/"+ path;
		}
		return path;
	}

	public static Transform FindByPath(string path,Transform root)
	{
		string[] nodes = path.Split('/');
		Transform tran = root;
		int index = 1;
		while(index < nodes.Length)
		{
			string node =nodes[index];
			tran = tran.Find(node);
			if(tran == null)break;
			index++;
		}
		return tran;
	}

    private static Transform _FindRecursively(Transform transform, string name)
    {
        if (transform.name == name)
        {
            return transform;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTrans = transform.GetChild(i);
            Transform childRet = _FindRecursively(childTrans, name);
            if (childRet != null)
            {
                return childRet;
            }
        }
        return null;
    }

    public static void SetChildCount(this Transform transform, int count, Transform childPrefab = null)
    {
        count = Mathf.Max(0, count);
        int childCount = transform.childCount;
        if (childCount == count)
        {
            return;
        }
        if (childCount > count)
        {
            for (int i = childCount - 1; i >= count; i--)
            {
                GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
        else
        {
            if (childPrefab == null)
            {
                if (childCount > 0)
                {
                    childPrefab = transform.GetChild(0);
                }
                else
                {
                    throw new System.ArgumentNullException("childPrefab");
                }
            }
            for (int i = childCount; i < count; i++)
            {
                Transform newChildTrans = Object.Instantiate(childPrefab) as Transform;
                newChildTrans.gameObject.name = childPrefab.gameObject.name;
                newChildTrans.parent = transform;
                newChildTrans.localPosition = childPrefab.localPosition;
                newChildTrans.localRotation = childPrefab.localRotation;
                newChildTrans.localScale = childPrefab.localScale;
            }
        }
    }

	public static T[] GetComponentsInImmediateChildren<T>(this GameObject go, bool activeOnly = false, int index = 0) where T : Component
    {
		return go.transform.GetComponentsInImmediateChildren<T>(activeOnly, index);
    }

	public static T[] GetComponentsInImmediateChildren<T>(this Transform transform, bool activeOnly = false, int index = 0) where T : Component
    {
        List<T> retList = new List<T>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childTrans = transform.GetChild(i);
            if (activeOnly && !childTrans.gameObject.activeSelf) continue;
            var comps = childTrans.GetComponents<T>();
			if (comps != null && comps.Length > index)
            {
				retList.Add(comps [index]);
            }
        }
        return retList.ToArray();
    }

    public static GameObject[] GetChildren(this GameObject go, bool activeOnly = false)
    {
        List<GameObject> childList = new List<GameObject>();
        Transform trans = go.transform;
		foreach(Transform _tr in trans.GetComponentsInChildren<Transform>(true))
		{
			if (activeOnly && !_tr.gameObject.activeSelf) continue;
			childList.Add(_tr.gameObject);
		}
        return childList.ToArray();
    }

	public static GameObject[] GetImmediateChildren(this GameObject go, bool activeOnly = false)
	{
		List<GameObject> childList = new List<GameObject>();
		Transform trans = go.transform;
		foreach(Transform _tr in trans)
		{
			if (activeOnly && !_tr.gameObject.activeSelf) continue;
			childList.Add(_tr.gameObject);
		}
		return childList.ToArray();
	}

    public static Transform CreatePrefab(GameObject go, string objectName, Transform parentTrans)
    {
        GameObject newGO = Object.Instantiate(go) as GameObject;
        newGO.name = objectName;
        if (parentTrans != null)
        {
            NGUITools.SetLayer(newGO, parentTrans.gameObject.layer);
        }
        Transform t = newGO.transform;
        t.parent = parentTrans;
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        return t;
    }

    public static Transform CreatePrefab(GameObject go, string objectName, Transform parentTrans, Vector3 localPos)
    {
        GameObject newGO = Object.Instantiate(go) as GameObject;
        newGO.name = objectName;
        if (parentTrans != null)
        {
            NGUITools.SetLayer(newGO, parentTrans.gameObject.layer);
        }
        Transform t = newGO.transform;
        t.parent = parentTrans;
        t.localPosition = localPos;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        return t;
    }

    public static T CreateBehaviour<T>(string objectName, Transform parentTrans) where T : MonoBehaviour
    {
        GameObject go = new GameObject(objectName);
        go.name = objectName;
        Transform t = go.transform;
        t.parent = parentTrans;
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        return go.AddComponent<T>();
    }

    public static Component CreateBehaviour(System.Type type, Transform parentTrans)
    {
        GameObject go = new GameObject(type.Name);
        //go.name = objectName;
        Transform t = go.transform;
        t.parent = parentTrans;
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
        return go.AddComponent(type);
    }

    public static float[] Vector3ToArray(Vector3[] vecArr)
    {
        if (vecArr == null) return new float[0];
        float[] arr = new float[vecArr.Length * 3];
        for (int i = 0; i < vecArr.Length; i++)
        {
            arr[i * 3] = vecArr[i].x;
            arr[i * 3 + 1] = vecArr[i].y;
            arr[i * 3 + 2] = vecArr[i].z;
        }
        return arr;
    }

    public static Vector3[] ArrayToVector3(float[] arr)
    {
        if (arr == null || arr.Length == 0 || arr.Length % 3 != 0) return null;
        Vector3[] vecArr = new Vector3[arr.Length / 3];
        for (int i = 0; i < vecArr.Length; i++)
        {
            vecArr[i].x = arr[i * 3];
            vecArr[i].y = arr[i * 3 + 1];
            vecArr[i].z = arr[i * 3 + 2];
        }
        return vecArr;
    }

    public static string ColorToString(Color c)
    {
        return Mathf.FloorToInt(c.r * 255).ToString("x2")
            + Mathf.FloorToInt(c.g * 255).ToString("x2")
            + Mathf.FloorToInt(c.b * 255).ToString("x2");
    }

    public static Color StringToColor(string str)
    {
        if (str.Length != 6) return Color.white;
        try
        {
            return new Color(int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255f,
                int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 255f,
                int.Parse(str.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 255f,
                1f);
        }
        catch
        {
            return Color.white;
        }
    }
}
