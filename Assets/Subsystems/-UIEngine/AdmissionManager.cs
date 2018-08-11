using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AdmissionManager
{
	static Proxy _proxy;
	static Proxy proxy
	{
		get
		{
			if(_proxy == null)
			{
				_proxy = new Proxy();
			}
			return _proxy;
		}
	}
	static Admission current;
	public static bool busing;

	public static void Play(Admission admission, Page oldPage, Page newPage)
	{
		busing = true;
		current = admission;
		current.Play(oldPage, newPage);
		UpdateManager.Add(proxy);
	}

	public static void Remove()
	{
		current = null;
		busing = false;
		UpdateManager.Remove(proxy);
	}

	private static void OnFinished()
	{
		current = null;
		busing = false;
	}

	class Proxy: IUpdatable
	{
		public void Update()
		{
			if(current == null)
			{
				UpdateManager.Remove(this);
				return;
			}
			current.Update();
			if(current.finished)
			{
				UpdateManager.Remove(this);
				OnFinished();
			}
		}
	}
}


