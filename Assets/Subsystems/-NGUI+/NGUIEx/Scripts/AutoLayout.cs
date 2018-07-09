using UnityEngine;
using System.Collections.Generic;
public class AutoLayout : MonoBehaviour {
	public UIWidget[] widgets;
	public int space = 0;
	public bool ignoeInactive;
	public void Reposition()
	{
		if(widgets==null)
		{
			widgets = GetComponentsInChildren<UIWidget>();
		}
		int width = 0;
		for(int i=0; i< widgets.Length; i++)
		{
			if(ignoeInactive && !widgets[i].gameObject.activeSelf)continue;
			Vector3 pos =	widgets[i].transform.localPosition ;
			widgets[i].transform.localPosition = new Vector3(width,pos.y,0);
			width = width+widgets[i].width;
//			Debug.LogError(width);
			if(space>0&& i <widgets.Length-1)width+=space;
		}
		transform.localPosition = new Vector3(-width/2,	transform.localPosition .y,	transform.localPosition .z);
	}

}
