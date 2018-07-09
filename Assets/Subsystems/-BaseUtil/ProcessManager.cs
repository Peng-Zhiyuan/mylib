using System;
using System.Collections.Generic;
using UnityEngine;

public static class ProcessManager 
{
	public static float Speed = 1.0f;
	private static List<IProcess> mProcesses = new List<IProcess>();
	private static List<IProcess> mTempProcesses = new List<IProcess>();
	public static void Add(IProcess process)
	{
		if( mProcesses.Contains(process))
			return;
		process.Start();
		mProcesses.Add(process);
	}
    public static void AddAndForceStart (IProcess process)
	{
		process.Start();
		if( mProcesses.Contains(process))
			return;
		mProcesses.Add(process);
	}

    public static void Remove(IProcess process)
	{
		if (mProcesses.Contains(process))
		{
			process.End();
			mProcesses.Remove(process);
		}
	}

    public static void RemoveWithoutEnd(IProcess process)
	{
		if (mProcesses.Contains(process))
		{
			mProcesses.Remove(process);
		}
	}

    public static void Remove(int processId)
	{
		for (int i=0; i<mProcesses.Count; i++) {
			if (mProcesses[i] is Process &&
				(mProcesses[i] as Process).ID == processId)
				mProcesses.RemoveAt(i);
		}
	}

    public static bool TryFindFirst(int processId, out Process process)
	{
		process = null;
		for (int i=0; i<mProcesses.Count; i++) {
			if (mProcesses[i] is Process &&
			    (mProcesses[i] as Process).ID == processId) {
				process = mProcesses[i] as Process;
				return true;
			}
		}
		return false;
	}
	#region IMgr implementation
    public static void Update ()
	{
		if (mProcesses.Count == 0)
			return;
		mTempProcesses.Clear ();
		mTempProcesses.AddRange (mProcesses);
		for (int i=0; i<mTempProcesses.Count; i++)
		{
			IProcess ip = mTempProcesses[i];
			if(!mProcesses.Contains(ip))continue;
			if (!ip.IsFinished()) {
				ip.Update(Time.deltaTime * Speed);
				if (ip is Process && (ip as Process).onUpdate != null)
					(ip as Process).onUpdate (Time.deltaTime * Speed);
			} else {
				ip.End();
				mProcesses.Remove(ip);
				if (ip != null && ip is Process)
					if ((ip as Process).NextProcess != null)
						Add ((ip as Process).NextProcess);
			}
		}
	}
	#endregion
}

public interface IProcess
{
	void Start();
	void Update(float deltaTime);
	void End();
	bool IsFinished();
}

public class Process: IProcess
{
	List<IProcess> mFinishedProcesses = new List<IProcess>();
	List<IProcess> mConcurrencyProcessList = new List<IProcess>();

	public int ID;
	public delegate void OnFinished (object data);
	public OnFinished onFinished;
	public OnFinished onStart;
	public OnFinished onUpdate;
	public Func<bool> isFinished;
	public object Data;
	public float mTimeout = float.MaxValue;
	public virtual void Start ()
	{
		mElapsed = 0;
		if (onStart != null)
			onStart (Data);
		for (int i=0; i<mConcurrencyProcessList.Count; i++) {
			if (mConcurrencyProcessList[i] != null)
				mConcurrencyProcessList[i].Start();
		}
	}
	

	public void AddConcurrencyProcess(IProcess proc) 
	{
		mConcurrencyProcessList.Add (proc);
	}
	public List<IProcess> ConcurrencyProcesses
	{
		get {return mConcurrencyProcessList;}
	}

	protected float mElapsed = 0;
	public virtual void Update (float deltaTime)
	{
		mElapsed += deltaTime;
		if (mConcurrencyProcessList.Count == 0)
			return;
		for (int i=0; i<mConcurrencyProcessList.Count; i++) {
			if (!mConcurrencyProcessList[i].IsFinished()) {
				mConcurrencyProcessList[i].Update(deltaTime);
				if (onUpdate != null)
					onUpdate (deltaTime);
			} else {
				if (!mFinishedProcesses.Contains(mConcurrencyProcessList[i])) {
					mConcurrencyProcessList[i].End();
					mFinishedProcesses.Add(mConcurrencyProcessList[i]);
					if (mConcurrencyProcessList[i] != null && mConcurrencyProcessList[i] is Process) {
						if ((mConcurrencyProcessList[i] as Process).NextProcess != null &&
						    !mConcurrencyProcessList.Contains ((mConcurrencyProcessList[i] as Process).NextProcess)){
							(mConcurrencyProcessList[i] as Process).NextProcess.Start();
							mConcurrencyProcessList.Add ((mConcurrencyProcessList[i] as Process).NextProcess);
						}
					}
				}
			}
		}
		
		foreach (IProcess process in mFinishedProcesses)
			mConcurrencyProcessList.Remove(process);
		mFinishedProcesses.Clear();
	}

	public virtual void End ()
	{
		if (onFinished != null)
			onFinished (Data);
	}


	public virtual bool IsFinished ()
	{
		bool result = isFinished != null ? isFinished () : true;
		for (int i=0; i<mConcurrencyProcessList.Count; i++) {
			result = result && mConcurrencyProcessList [i].IsFinished ();
			if (mConcurrencyProcessList [i].IsFinished ()) {
				mConcurrencyProcessList[i].End();
				mFinishedProcesses.Add(mConcurrencyProcessList[i]);
				if (mConcurrencyProcessList[i] != null && mConcurrencyProcessList[i] is Process) {
					if ((mConcurrencyProcessList[i] as Process).NextProcess != null && 
					    !mConcurrencyProcessList.Contains ((mConcurrencyProcessList[i] as Process).NextProcess)){
						(mConcurrencyProcessList[i] as Process).NextProcess.Start();
						mConcurrencyProcessList.Add ((mConcurrencyProcessList[i] as Process).NextProcess);
					}
				}
			}
		}
		return result || mElapsed > mTimeout;
	}

	Process mNextProcess = null;
	public Process NextProcess 
	{
		set
		{
			mNextProcess = value;
		}

		get {return mNextProcess;}
	}

	public Process LastProcess 
	{
		get 
		{
			var lastProcess = this;
		 	do {
				if (lastProcess.mNextProcess == null)
					return lastProcess;
				else
					lastProcess = lastProcess.mNextProcess;
			} while (true);
		}
	}
}

