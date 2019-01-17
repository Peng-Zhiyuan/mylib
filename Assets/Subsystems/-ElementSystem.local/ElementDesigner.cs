using UnityEngine;
using System.Collections;
using ElementSystem;
using System.Collections.Generic;
using System.Text;

[ExecuteInEditMode]
public class ElementDesigner : MonoBehaviour 
{
    private ElementDesigner _parentDesigner;
    public ElementDesigner ParentDesigner
    {
        get
        {
            if(Application.isPlaying)
            {
                if(_parentDesigner == null)
                {
                    _parentDesigner = transform.parent?.GetComponentInParent<ElementDesigner>();
                }
                return _parentDesigner;
            }
            else
            {
                return transform.parent?.GetComponentInParent<ElementDesigner>();

            }

        }
    }

    public string GetClassName()
    {
        var thisName = this.name;
        thisName = thisName.Trim('$');
        thisName = BigFirstChar(thisName);
        var parentDesigner = ParentDesigner;
        if (parentDesigner != null)
        {
            return parentDesigner.GetClassName() + "_" + thisName;
        }
        else
        {
            return thisName;
        }  
    }

    private string BigFirstChar(string name)
    {
         return name.Substring(0,1).ToUpper() + name.Substring(1);
    }
  

}

