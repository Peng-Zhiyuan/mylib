using UnityEngine;
using System.Collections;

// 导航的最小单元
public class Page : View
{
    // 告诉UI管理器是否是一个全屏窗口(完全遮挡之前的任何窗口)
    public bool Overlay;

	// 当被导航到这个窗口时发生
	public virtual void OnNavigatedTo(){}
	// 当从这个窗口导航到别的窗口时发生
	public virtual void OnNavigatedFrom(){}

    public virtual void OnResult(object result){}

    public virtual void OnPush(){}

    public virtual void OnPop(){}


}

