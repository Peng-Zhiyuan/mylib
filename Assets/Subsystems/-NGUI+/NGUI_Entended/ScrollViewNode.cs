using UnityEngine;
using System.Collections;
using System;
public class ScrollViewNode : MonoBehaviour {


	[NonSerialized]public int NodeIndex;
	[NonSerialized]public UIScrollViewHelper viewHelper;

	public virtual void SetInfo(object data)
	{
		
	}

	public bool Selected
	{
		get
		{
			return  viewHelper.SelectIndex == NodeIndex;
		}
	}
}
