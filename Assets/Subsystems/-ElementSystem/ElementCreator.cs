using UnityEngine;
using System.Collections; 
using System;

namespace ElementSystem
{
    public class ElementCreator : MonoBehaviour 
    {

        public string elementName;
        public int depth;
        public SlowStringDictionary param;
        private Element instance;


        // Use this for initialization
        void Awake () 
        {
            if (transform.parent.name != "<PrototypeRoot>")
            {
                Create(Root.Runtime);
                ApplyParam(instance);

            }
        }

        public T Get<T>() where T : Element
        {
            return instance as T;
        }


        [ContextMenu("Preview")]
        public void Preview()
        {
            Create(Root.Preview);
            if (PreviewElement != null)
            {
                var list = ElementUtils.GetComponentsInChildrenNoRescure<ElementCreator>(PreviewElement.transform);
                foreach (var creator in list)
                {
                    creator.Preview();
                }
            }
            ApplyParam(PreviewElement);
        }


        private void Create(Root root)
        {
            RemvoePreview();
            Transform parent = null;
            switch (root)
            {
                case Root.Preview:
                    parent = PreviewRoot;
                    break;
                case Root.Runtime:
                    parent = RuntimeRoot;
                    break;
            }

            var designer = GetComponentInParent<ElementDesigner>();
            var extraProtptypeRoot = designer != null ? designer.ProtptypeRoot : null;
            instance = ElementManager.CreateElement(elementName, parent, extraProtptypeRoot);
            ShiftDepth(instance, depth);
            instance.gameObject.SetActive(true);
        }

        private void ShiftDepth(Element element, int delta)
        {
            if (delta == 0)
            {
                return;
            }
            var list = element.GetComponentsInChildren<UIWidget>(true);
            foreach (var w in list)
            {
                w.depth += delta;
            }
        }

        private void ApplyParam(Element element)
        {
            var type = element.GetType();
            var list = type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            foreach (var p in list)
            {
                if (!p.IsDefined(typeof(CreatorWriteAttribute), true))
                {
                    continue;
                }
                var key = p.Name;
                var value = param.Get(key);
                if (value == null)
                {
                    continue;
                }
                object changedValue = null;
                var needType = p.PropertyType;
                try
                {
                    if (needType == typeof(bool))
                    {
                        changedValue = bool.Parse(value);
                    }
                    else if (needType == typeof(string))
                    {
                        changedValue = value;   
                    }
                    else if (needType == typeof(int))
                    {
                        changedValue = int.Parse(value);
                    }
                    else if (needType == typeof(float))
                    {
                        changedValue = float.Parse(value);
                    }
                    else if(needType == typeof(Vector2))
                    {
                        var parts = value.Split(',');
                        var x = float.Parse(parts[0]);
                        var y = float.Parse(parts[1]);
                        changedValue = new Vector2(x, y);
                    }
                }
                catch(Exception e)
                {
                    //Debug.LogWarning(e);
                    continue;
                }
                p.SetValue(element, changedValue, null);
            }
        }

        [ContextMenu("RemovePreview")]
        public void RemvoePreview()
        {
            PreviewRoot.DestroyChildren();
        }

        enum Root
        {
            Preview,
            Runtime,
        }

        private Transform _runtimeRoot;
        private Transform RuntimeRoot
        {
            get
            {
                if (_runtimeRoot != null)
                {
                    return _runtimeRoot;
                }

                _runtimeRoot = this.transform.Find("<runtimeRoot>");
                if (_runtimeRoot != null)
                {
                    return _runtimeRoot;
                }


                var go = new GameObject();
                go.name = "<runtimeRoot>";
                var t = go.transform;
                t.parent = this.transform;
                t.localScale = Vector3.one;
                t.localPosition = Vector3.zero;
                t.localEulerAngles = Vector3.zero;
                _runtimeRoot = t;
                return _runtimeRoot;
            }
        }

        private Transform _previewRoot;
        private Transform PreviewRoot
        {
            get
            {
                if (_previewRoot != null)
                {
                    return _previewRoot;
                }
                    
                _previewRoot = this.transform.Find("<previewRoot>");
                if (_previewRoot != null)
                {
                    return _previewRoot;
                }


                var go = new GameObject();
                go.name = "<previewRoot>";
                var t = go.transform;
                t.parent = this.transform;
                t.localScale = Vector3.one;
                t.localPosition = Vector3.zero;
                t.localEulerAngles = Vector3.zero;
                _previewRoot = t;
                return _previewRoot;
            }
        }

        public bool HasPreview
        {
            get
            {
                return PreviewRoot.transform.childCount > 0;
            }
        }

        public Element PreviewElement
        {
            get
            {
                var root = PreviewRoot;
                if (root.transform.childCount == 0)
                {
                    return null;
                }
                Transform go = root.transform.GetChild(0);
                var element = go.GetComponent<Element>();
                return element;
            }
        }
    }

}
