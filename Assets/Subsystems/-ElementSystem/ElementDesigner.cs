using UnityEngine;
using System.Collections;
using ElementSystem;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ElementDesigner : MonoBehaviour 
{
    void Awake()
    {
        if (!Application.isPlaying)
        {
            if (ProtptypeRoot == null)
            {
                var root = new GameObject();
                root.name = "<PrototypeRoot>";
                root.transform.parent = this.transform;
                root.transform.localPosition = Vector3.zero;
                root.transform.localScale = Vector3.one;
            }
        }
        else
        {
            ProtptypeRoot.gameObject.SetActive(false);
        }
    }

   
    public void Preview()
    {
        var list = ElementUtils.GetComponentsInChildrenNoRescure<ElementCreator>(this.transform);
        foreach (var creator in list)
        {
            creator.Preview();
        }
    }

    public void RemovePreview()
    {
        var list = ElementUtils.GetComponentsInChildrenNoRescure<ElementCreator>(this.transform);
        foreach (var creator in list)
        {
            creator.RemvoePreview();
        }
    }

    private bool _serchedPrototypeRoot;
    private Transform _prototypeRoot;
    public Transform ProtptypeRoot
    {
        get
        {
            if (Application.isPlaying)
            {
                if (!_serchedPrototypeRoot)
                {
                    _serchedPrototypeRoot = true;
                    _prototypeRoot = transform.Find("<PrototypeRoot>");
                }
                return _prototypeRoot;
            }
            else
            {
                return transform.Find("<PrototypeRoot>");
            }
        }

    }

}

