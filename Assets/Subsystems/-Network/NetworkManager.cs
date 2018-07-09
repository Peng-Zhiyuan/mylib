using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameCore;
using System;
public static class NetworkManager
{
	private static readonly Dictionary<uint, NetworkCommandInfo> commandInfoTable = new Dictionary<uint, NetworkCommandInfo>();	
    private static readonly Queue<NetworkRoutine> bank = new Queue<NetworkRoutine>();
    private static readonly Queue<NetworkRoutine> willPostQueue = new Queue<NetworkRoutine>();
    private static readonly List<NetworkRoutine> routineList = new List<NetworkRoutine>();
    public static float delay = 0;

    public static Action<NetBaseMsg> requestSuccessPredealHandler;
    public static Func<NetMsg<string>, bool> defaultExcetionCallback;
    public static Action<NetMsg<string>> defaultFailCallback;
    public static Action<bool> blockInputHandler;
    public static Action<NetworkArgument> addExtraParamHandler;
    
		
	// command register routine
	// @id: specified a network message id
	// @cmd: Network command pack, includes url and message processor
	// @returns: a boolean value to indicate whehter the command is successfully registered or not
	public static bool RegisterCommand( uint id, NetworkCommandInfo info )
	{
		if (commandInfoTable.ContainsKey(id) == false && info != null )
		{
            commandInfoTable[id] = info;
            info.mId = id;
			return true;
		}
		return false;
	}
	
	// remove registered command
	// @id: specified a network message id
	// @cmd: Network command pack, includes url and message processor
	// @returns: a boolean value to indicate whehter the command is successfully unregistered or not
    public static bool UnregisterCommand( uint id )
	{
		if ( commandInfoTable.ContainsKey( id ) )
		{
			commandInfoTable.Remove( id );
			return true;
		}
		return false;
	}

    public static void Request(uint id, NetworkArgument arg, Action<NetBaseMsg> successCallback = null)
	{
        Request(id, arg, successCallback, defaultFailCallback, defaultExcetionCallback);
	}

    public static void Request(uint id, NetworkArgument arg, Action<NetBaseMsg> successCallback, Action<NetMsg<string>> failCallback)
    {
        Request(id, arg, successCallback, failCallback, defaultExcetionCallback);
    }

    public static void Request(uint id, NetworkArgument arg, Action<NetBaseMsg> successCallback, Action<NetMsg<string>> faillCallback, Func<NetMsg<string>, bool> exceptionCallback)
	{
		if (commandInfoTable.ContainsKey(id))
		{
			NetworkCommandInfo cmd = commandInfoTable[id];
            NetworkRoutine routine = FetchIdleRoutine();
            routine.Init(cmd, arg, successCallback, faillCallback, exceptionCallback);
            willPostQueue.Enqueue(routine);
            if (routine.commandInfo.isBlock)
            {
				if(blockInputHandler!=null)blockInputHandler.Invoke(true);
            }
            UpdateManager.Add(updateObj);
		}
	}

    private static NetworkManagerUpdateObject updateObj = new NetworkManagerUpdateObject();

    private static NetworkRoutine FetchIdleRoutine()
	{
		NetworkRoutine routine = null;
		if(bank.Count > 0) 
		{
			routine = bank.Dequeue();
		}
		else 
		{
			routine = new NetworkRoutine();
		}
		return routine;	
	}

	
    public static void Clear()
	{
		for (int i = routineList.Count - 1; i >= 0; i--)
		{
			routineList[i].State = RoutineState.Idle;
		}
		if(routineList.Count == 0)
		{
			if(blockInputHandler != null )blockInputHandler.Invoke(false);
		}
		while (willPostQueue.Count > 0)
        {
            var routine = willPostQueue.Dequeue();
			routine.State = RoutineState.Idle;
			bank.Enqueue(routine);
        }
	}

    public static void RepostAllSuspendedRequest()    
    {
        if (routineList.Count > 0)
        {
            for (int i = 0; i < routineList.Count; i++)
            {
                if(routineList[i].State == RoutineState.Suspended)
                {
                    routineList[i].PostRequest();
                }
            }
        }
    }

    public static void DisposeAllSuspendedReqeust()
    {
        foreach(var r in routineList)
        {
            if (r.State == RoutineState.Suspended)
            {
                r.State = RoutineState.Idle;
            }
        }
    }

    class NetworkManagerUpdateObject : IUpdatable
    {
        float t = 0;
        public void Update()
        {
            t += Time.deltaTime;
            if(t < 0.1f) return;
            t=0;
            for (int i = routineList.Count - 1; i >= 0; i--)
            {
                if (routineList[i].State == RoutineState.Processing)
                {
                    routineList[i].Update();
                }
                else if(routineList[i].State == RoutineState.Idle)
                {
                    bank.Enqueue(routineList[i]);
                    routineList.RemoveAt(i);
                }
            }

            if (willPostQueue.Count > 0)
            {
                var routine = willPostQueue.Dequeue();
                routine.PostRequest();
                routineList.Add(routine);
            }

            if (routineList.Count == 0 && willPostQueue.Count == 0)
            {
				if(blockInputHandler != null)blockInputHandler.Invoke(false);
                UpdateManager.Remove(this);
            }
        }
    }
}
