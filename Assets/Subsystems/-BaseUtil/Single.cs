using UnityEngine;
using System.Collections;

public class Single<T> where T : new()
{
	private static T mInstance;
	public static T Instance {
			get {
				if (mInstance == null) {
					mInstance = new T ();
				}
				return mInstance;
			}
//				set
//				{
//					mInstance = value;
//				}
		}
	public static void Release()
	{
		mInstance = default(T);
	}

}


