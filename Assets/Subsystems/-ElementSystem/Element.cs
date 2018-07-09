using UnityEngine;
using System.Collections;
using System;

namespace ElementSystem
{
    [RequireComponent(typeof(ElementDesigner))]
    public class Element : MonoBehaviour 
    {
        [ReadOnly]
        public Element prototype;

        private ElementDesigner _parentDesigner;
        public ElementDesigner ParentDesigner
        {
            get
            {
                if (Application.isPlaying)
                {
                    if (_parentDesigner == null)
                    {
                        _parentDesigner = transform.parent.GetComponentInParent<ElementDesigner>();
                    }
                    return _parentDesigner;
                }
                else
                {
                    return transform.parent.GetComponentInParent<ElementDesigner>();
                }
            }
        }

        [NonSerialized]
        public bool isCreated;
        [NonSerialized]
        public int listIndex;
        public virtual void OnCreate()
        {
            
        }

        public bool Active
        {
            get
            {
                return gameObject.activeSelf;
            }
            set
            {
                gameObject.SetActive(value);
            }
        }
    }

}

