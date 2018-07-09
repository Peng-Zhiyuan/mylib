using UnityEngine;
using System.Collections.Generic;

public class CustomPopUpList : UIPopupList {
	List<EventDelegate> onClose = new List<EventDelegate>(); 
	public override void CloseSelf()
	{
		base.CloseSelf();
		if(onClose.Count>0)
		{
			if (EventDelegate.IsValid(onClose))
			{
				EventDelegate.Execute(onClose);
			}
		}

	}
}
