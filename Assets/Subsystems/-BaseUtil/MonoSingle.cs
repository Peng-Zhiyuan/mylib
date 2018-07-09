using UnityEngine;
using System.Collections;

public class MonoSingle<T> : MonoBehaviour where T: MonoSingle<T>
{
	static T instance;

	public static T Instance {
		get {
			if (instance == null)
				instance = (T)GameObject.FindObjectOfType (typeof(T));
			return instance;
		}
	}

//	protected virtual void Awake ()
//	{
//		if (instance != null && instance != (T)this) {
//			GameObject.Destroy (this);
//		} else {
//			instance = (T)this;
//		}
//	}
//
//	protected virtual void Awake(bool replace){
//		instance = (T)this;
//	}

	protected virtual void Destroy ()
	{
		instance = null;
	}
}

