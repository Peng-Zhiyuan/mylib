using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// UI 最小逻辑单元
public class View : MonoBehaviour
{
	[ReadOnly]
	public string param;

    private bool _active;
    public bool Active
    {
        get
        {
            return _active;
        }
        set
        {
            if (_active == value) return;
            _active = value;
            gameObject.SetActive(value);
            if (value)
            {
                this.OnActive();
            }
            else
            {
                this.OnInactive();
            }
        }
    }

    private int _depth;
    public int Depth
    {
        get
        {
            return _depth;
        }
        set
        {
            _depth = value;
            var z = -_depth * 10;

            
 
  
            var p = this.transform.localPosition;
            p.z = z;
            this.transform.localPosition = p; 
        }
    }

    // 当被(UIService)创建时调用
    public virtual void OnCreate() { }

    public virtual void OnFrameUpdate() { }

    protected virtual void OnActive() {}

    protected virtual void OnInactive() {}
}