using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
	public enum EVENTTYPE
	{
		SWITCH_PAGE = 0,
		SWITCH_FLOWER = 1,
		SWITCH_DAY = 2,
		PAGE_BLOCK =3,
		DIALOG_BLOCK =4,
		INPUT_BLOCK = 5,
		TIME_SECOND_UPDATE = 6,
		TIME_MINUTE_UPDATE = 7,
		TIME_HOUR_UPDATE = 8,
		RELOGIN,
		RECONNECT,
		DETECTION,
	//
	//		//SWITCH_LOCK = 2,
	//		SWITCH_WEBVIEW = 3,
	//		FILTER_BUTTON_CLICK = 4,
	//		FILTER_BUTTON_KEY_CLICK = 5,


	//		REFRESH_UI =9,
	//		//BLOCK_DEPTH_SET =10,
	//		//BLOCK_SWITCH = 11,
	//		//BLACK_MASK_SWITCH =12,

	//		PAGE_BLOCK_OFFSET =16,
	//		//BLOCK_SET = 16,
	//		//BLOCK_INPUT = 17, 
	//
	//
	//		ATTR_UPDATE =18, 
	//		MSG_TAG_UPDATE = 19,
	//		SWITCH_DAY = 20,
		//REFRESH_VIEW_NOW = 21,
	}
		
	public delegate bool EVENT_DELEGATE<T> (T arg);
	public delegate bool EVENT_DELEGATE();
	public class EventManager:Single<EventManager>{

	//public static EventManager Instance = new EventManager();
	private Dictionary<string, Delegate> mDelegates = new Dictionary<string, Delegate>();

	public void SendEvent(string eventType)	
	{ 
		
		Delegate d = null;
		if (mDelegates.TryGetValue(eventType, out d))
		{
			Action callback = d as Action;
			if (callback != null)
			{
				callback();
			}
		}
	}
	public void SendEvent<T>(string eventType, T arg)	
	{ 
		if (arg == null)
        {
            throw new ArgumentNullException("arg");
        }
        Delegate d = null;
        if (mDelegates.TryGetValue(eventType, out d))
        {
            Action<T> callback = d as Action<T>;
            if (callback != null)
            {
                callback(arg);
            }
        }
	}
	public void AddListener(string eventType, Action listener)
	{
		Delegate d = null;
		if (mDelegates.TryGetValue(eventType, out d))
		{
			mDelegates[eventType] = Delegate.Combine(d, listener);
		}
		else
		{
			mDelegates[eventType] = listener;
		}
	}
	public void AddListener<T>(string eventType, Action<T> listener)
	{
		Delegate d = null;
        if (mDelegates.TryGetValue(eventType, out d))
        {
            mDelegates[eventType] = Delegate.Combine(d, listener);
        }
        else
        {
            mDelegates[eventType] = listener;
		}
	}
	public void RemoveListener(string eventType,  Action listener) 
	{
		Delegate d = null;
		if (mDelegates.TryGetValue(eventType, out d))
		{
			Delegate currentDel = Delegate.Remove(d, listener);
			
			if (currentDel == null)
			{
				mDelegates.Remove(eventType);
			}
			else
			{
				mDelegates[eventType] = currentDel;
			}
		}
	}
	public void RemoveListener<T>(string eventType,  Action<T> listener) 
    {
        Delegate d = null;
        if (mDelegates.TryGetValue(eventType, out d))
        {
            Delegate currentDel = Delegate.Remove(d, listener);
 
            if (currentDel == null)
            {
                 mDelegates.Remove(eventType);
            }
            else
            {
                 mDelegates[eventType] = currentDel;
            }
        }
    } 

	public bool SendCallbackEvent(string eventType)	
	{ 
		Delegate d = null;
		if (mDelegates.TryGetValue(eventType, out d))
		{
			EVENT_DELEGATE callback = d as EVENT_DELEGATE;
			if (callback != null)
			{
				return callback();
			}
		}
		return false;
	}
	
	public bool SendCallbackEvent<T>(string eventType, T arg)	
	{ 
		if (arg == null)
		{
			throw new ArgumentNullException("arg");
		}
		Delegate d = null;
		if (mDelegates.TryGetValue(eventType, out d))
		{
			EVENT_DELEGATE<T> callback = d as EVENT_DELEGATE<T>;
			if (callback != null)
			{
				return callback(arg);
			}
		}
		return false;
	}

	public void AddCallbackListener<T>(string eventType, EVENT_DELEGATE<T> listener)
	{
		Delegate d = null;
		if (mDelegates.TryGetValue(eventType, out d))
		{
			mDelegates[eventType] = Delegate.Combine(d, listener);
		}
		else
		{
			mDelegates[eventType] = listener;
		}
	}
	
	public void AddCallbackListener(string eventType, EVENT_DELEGATE listener)
	{
		Delegate d = null;
		if (mDelegates.TryGetValue(eventType, out d))
		{
			mDelegates[eventType] = Delegate.Combine(d, listener);
		}
		else
		{
			mDelegates[eventType] = listener;
		}
	}



	public void RemoveCallbackListener<T>(string eventType,  EVENT_DELEGATE<T> listener) 
	{
		Delegate d = null;
		if (mDelegates.TryGetValue(eventType, out d))
		{
			Delegate currentDel = Delegate.Remove(d, listener);
			
			if (currentDel == null)
			{
				mDelegates.Remove(eventType);
			}
			else
			{
				mDelegates[eventType] = currentDel;
			}
		}
	}

	public void RemoveCallbackListener(string eventType,  EVENT_DELEGATE listener) 
	{
		Delegate d = null;
		if (mDelegates.TryGetValue(eventType, out d))
		{
			Delegate currentDel = Delegate.Remove(d, listener);
			
			if (currentDel == null)
			{
				mDelegates.Remove(eventType);
			}
			else
			{
				mDelegates[eventType] = currentDel;
			}
		}
	}
}

