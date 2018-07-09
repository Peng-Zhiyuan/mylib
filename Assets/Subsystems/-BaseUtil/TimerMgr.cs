using UnityEngine;
using System.Collections.Generic;
using System;
//public delegate void TimerCallback();
public enum WAITTYPE
{
	NORMAL,
	GLOBAL,
	STATIC,
}
public class TimerEvent
{
	public string name;
	public Action mCallback;
	public float triggerTime;
	public float delay;
	public bool loop;
	public WAITTYPE waittype;
	public bool idle;
	public bool dirty;
	public void Reset(float t)
	{
		triggerTime = triggerTime + delay;
	}
}
public class TimerMgr:Single<TimerMgr>,IProcess
{
	//public static TimerMgr Instance = new TimerMgr();
	private float time = 0;
	private List<TimerEvent>  timeEvents = new List<TimerEvent>();
	public Queue<TimerEvent> EmptyPool =  new Queue<TimerEvent>();

	
	public void Wait(float delay, Action callback)
	{
		Wait(delay, callback, false, "", WAITTYPE.NORMAL);
	}

	public void Wait(string name, float delay, Action callback)
	{
		Wait(delay, callback, false, name, WAITTYPE.NORMAL);
	}

	public void GlobalWait(float delay,Action callback)
	{
		Wait(delay, callback, false, "GlobalWait", WAITTYPE.GLOBAL);
	}

	public void GlobalWait(string name,float delay,Action callback)
	{
		Wait(delay, callback, false, name, WAITTYPE.GLOBAL);
	}

	public void StaticWait(float delay,Action callback)
	{
		Wait(delay, callback, false, "StaticWait", WAITTYPE.STATIC);
	}

	public void StaticWait(string name,float delay,Action callback)
	{
		Wait(delay, callback, false, name, WAITTYPE.STATIC);
	}

	public override string ToString()
	{
		string log = "";
		foreach(TimerEvent tm in timeEvents)
		{
			log+=tm.name+"-"+tm.dirty+"  ";
		}
		return log;
	}
	public void Loop(string name,float delay, Action callback)
	{
		Wait(delay, callback, true, name, WAITTYPE.NORMAL);
	}

	public void GlobalLoop(string name,float delay, Action callback)
	{
		Wait(delay, callback, true, name, WAITTYPE.GLOBAL);
	}

	public bool IsFinished()
	{
		return timeEvents.Count == 0;
	}
	public void Start()
	{
		
	}
	public void End()
	{
		
	}

//		public void LuaWait(float delay, LuaFunction callback)
//		{
//			Wait(delay, () => {
//				callback.Call ();
//			});
//		}


//		
//		public void Wait(float delay, TimerCallback callback,bool loop)
//		{
//			Wait(delay, callback, loop, "", false);
//		}
//		
//		public void Wait(float delay, TimerCallback callback,bool loop, string name)
//		{
//			Wait(delay, callback, loop, name, false);
//		}
//
//		public void Wait(float delay, TimerCallback callback,bool loop, bool global)
//		{
//			Wait(delay, callback, loop, "", global);
//		}

	private void Wait(float delay, Action callback,bool loop, string name, WAITTYPE waittype)
	{
		if(delay < 0 || callback == null)return;
		TimerEvent tEvent;
		if(EmptyPool.Count > 0)
		{
			 tEvent = EmptyPool.Dequeue();
		}
		else tEvent =  new TimerEvent();
		tEvent.name = name;
		tEvent.mCallback = callback;
		tEvent.triggerTime = Time.realtimeSinceStartup + delay;
		tEvent.delay = delay;
		tEvent.loop = loop;
		tEvent.dirty = false;
		tEvent.idle = false;
		tEvent.waittype = waittype;
		if(loop)callback();
		timeEvents.Add(tEvent);
		ProcessManager.Add(Instance);
	}
	
	
	public void ResetTime(float delay,string name)
	{
		for(int i =  timeEvents.Count - 1; i>=0; i--)
		{
			if(timeEvents[i].name.Equals(name))
			{
				timeEvents[i].delay = delay;
				timeEvents[i].triggerTime = Time.realtimeSinceStartup + delay;
			}
			
		}
	}
	
	public void ClearAll()
	{
		for(int i =  timeEvents.Count - 1; i>=0; i--)
		{
			if(timeEvents[i].waittype != WAITTYPE.STATIC)
			{
				EmptyPool.Enqueue(timeEvents[i]);
				timeEvents.Remove(timeEvents[i]);
			}
		}
		time = 0;
	}
//		public void ClearAll()
//		{
//			for(int i =  timeEvents.Count - 1; i>=0; i--)
//			{
//				timeEvents[i].dirty = true;
//			}
//		}
	public void Clear()
	{
//			Debug.Log("Timer clear");
		for(int i =  timeEvents.Count - 1; i>=0; i--)
		{
			if(timeEvents[i].waittype == WAITTYPE.NORMAL)
			{
				timeEvents[i].dirty = true;
			}
		}
	}
	
	public void Resume(string name)
	{
		for(int i =  timeEvents.Count - 1; i>=0; i--)
		{
			if(timeEvents[i].name == name)
			{
				timeEvents[i].idle = false;
				break;
			}
		}
	}
	
	public void Stop(string name)
	{
		for(int i =  timeEvents.Count - 1; i>=0; i--)
		{
			if(timeEvents[i].name == name)
			{
				timeEvents[i].idle = true;
				break;
			}
		}
	}
	
	public void Remove(string name)
	{
		for(int i =  timeEvents.Count - 1; i>=0; i--)
		{
			if(timeEvents[i].name == name)
			{
				timeEvents[i].dirty = true;
				//break;
			}
		}
	}

	public bool Has(string name)
	{
		for(int i =  timeEvents.Count - 1; i>=0; i--)
		{
			if(timeEvents[i].name == name && !timeEvents[i].dirty)
			{
				return true;
				//break;
			}
		}
		return false;
	}

	// Update is called once per frame
	public void Update (float deltaTime) 
	{
		time =  Time.realtimeSinceStartup;
		if(timeEvents.Count == 0) return;
		for(int i =  timeEvents.Count - 1; i>=0; i--)
		{
			if(timeEvents[i].dirty)
			{
				EmptyPool.Enqueue(timeEvents[i]);
				timeEvents.Remove(timeEvents[i]);
			}
			else if(timeEvents[i].idle)
			{
				timeEvents[i].triggerTime += Time.deltaTime;
			}
			else if(time >= timeEvents[i].triggerTime)
			{
				timeEvents[i].mCallback();
				if(!timeEvents[i].dirty && timeEvents[i].loop)
				{
					timeEvents[i].Reset(time);
				}
				else
				{
					EmptyPool.Enqueue(timeEvents[i]);
					timeEvents.Remove(timeEvents[i]);
				}
			}
			
		}
	}
		
}
