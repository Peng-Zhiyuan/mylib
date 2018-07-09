using UnityEngine;
public abstract partial class UITweener : MonoBehaviour
{
	// add by zhaolei
	public void ResetToOriginer ()
	{
		mStarted = false;
		mFactor = 0f;
		Sample(mFactor, false);
	}

	public void ResetToEnd ()
	{
		mStarted = false;
		mFactor = 1f;
		Sample(mFactor, false);
	}

	public bool isFinished
	{
		get
		{
			return 	mFactor==1;
		}
	}

	
}