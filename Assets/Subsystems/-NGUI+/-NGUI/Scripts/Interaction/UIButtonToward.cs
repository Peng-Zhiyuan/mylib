//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Simple example script of how a button can be scaled visibly when the mouse hovers over it or it gets pressed.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Button Scale")]
public class UIButtonToward : MonoBehaviour
{
	public Transform target;
	public Vector3 hover = Vector3.zero;
	public Vector3 pressed = new Vector3(0,0,180);
	void Start()
	{
		transform.localRotation = Quaternion.Euler(Vector3.zero);
	}
	void OnPress (bool isPressed)
	{
		if (enabled)
		{
			//Vector3 p = target.localPosition;
			//Debug.Log("p>>>>>>>:"+p);
//			if(isPressed)
//			{
//				if(SoundMgr.GetSingle()!=null )
//				{
//					SoundMgr.GetSingle().play_se("ui_button");
//				}
//			}
			target.localRotation = Quaternion.Euler(isPressed? pressed: Vector3.zero);
			//target.localPosition = new Vector3(-p.x,-p.y,p.z);

		}
	}
	
	void OnHover (bool isOver)
	{
		if (enabled)
		{
			//Vector3 p = target.localPosition;
			target.localRotation = Quaternion.Euler(isOver? hover: Vector3.zero);
			//target.localPosition = -p;
		}
	}
	
	void OnSelect (bool isSelected)
	{
		if (enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
			OnHover(isSelected);
	}
}
