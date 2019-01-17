using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace ElementSystem
{
    public static class ElementManager
    {

        static string RES_LOAD_PATH = "Element/";

        public static Dictionary<string, GameObject> cache = new Dictionary<string, GameObject>();

        public static Element CreateElement(string name, Transform parent, Transform extraPrototypeRoot = null)
        {
            GameObject prefab = null;
            if (extraPrototypeRoot != null)
            {
                var t = extraPrototypeRoot.Find(name);
                if (t != null)
                {
                    prefab = t.gameObject;
                }
            }
            if(prefab == null)
            {
                prefab = GetPrefab(name);
            }
            if (prefab == null)
            {
                return null;
            }
            var go = GameObject.Instantiate(prefab);
            go.transform.parent = parent;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
            go.transform.localScale = Vector3.one;
            var element = go.GetComponent<Element>();
            element.prototype = prefab.GetComponent<Element>();
            if (element == null)
            {
                throw new Exception("behavior Elemnt not found on element: " + name);
            }
            element.isCreated = true;
            element.OnCreate();
            return element;
        }
            

        private static GameObject GetPrefab(string name)
        {
            // 尝试从换从中寻找
            GameObject prefab;
            cache.TryGetValue(name, out prefab);
            if (prefab != null)
            {
                return prefab;
            }
            // 尝试新加载
            prefab = LoadPrefab(name);
            if (prefab == null)
            {
                Debug.LogError("[ElementManager] element: " + name + " not found");
                return null;
            }
            cache[name] = prefab;
            return prefab;
        }

        private static GameObject LoadPrefab(string name)
        {
            var go = Resources.Load<GameObject> (RES_LOAD_PATH + name);
            return go;
        }
    }

}

