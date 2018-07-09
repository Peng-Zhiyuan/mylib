using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using GameCore;
using Ionic.Zlib;

public enum RoutineState
{
	Processing,
	Suspended,
	Idle
}
public class NetworkRoutine 
{
    private Action<NetBaseMsg> successCallback = null;
    private Action<NetMsg<string>> failCallback = null;
    private Func<NetMsg<string>, bool> exceptionCallback = null;
	public NetworkCommandInfo commandInfo = null;
    private NetworkArgument arg = null;
	
    private WWW www = null;
	private RoutineState _state = RoutineState.Idle;
    private float processingTime = 0;	

	private int net_id = 1;
	public RoutineState State
	{
		get
		{
            return _state;
		}
		set
		{
			if(value == RoutineState.Idle) 
			{
				processingTime = 0;
                DisposeWWW();
			}
			else if(value == RoutineState.Suspended) 
			{
				processingTime = 0;
			}
            _state = value;
		}
	}
	private void DisposeWWW()
	{
		if(www != null)
		{
			www.Dispose();
			www = null;
		}
	}

    private static int sq =1;
    public void Init(NetworkCommandInfo cmd, NetworkArgument arg, Action<NetBaseMsg> successCallback, Action<NetMsg<string>> failCallback, Func<NetMsg<string>, bool> exceptionCallback)
	{
        arg = arg ?? new NetworkArgument();
		this.commandInfo = cmd;
		this.net_id = sq++;
		this.arg = arg;
		this.successCallback = successCallback;
		this.failCallback = failCallback;
        this.exceptionCallback = exceptionCallback;
	}

	HttpRequest _request;
	public void PostRequest()
	{
		DisposeWWW();

		if(commandInfo.isBlock)
		{
			if(NetworkManager.blockInputHandler != null) NetworkManager.blockInputHandler.Invoke(true);
		}
		State = RoutineState.Processing;
        string url = commandInfo.url;

		WWWForm form = null;
		foreach(KeyValuePair<string,string> kv in NetworkArgument.baseParam)
		{
			arg.AddParam(kv.Key, kv.Value);
		}

		if(NetworkManager.addExtraParamHandler != null) NetworkManager.addExtraParamHandler.Invoke(arg);

		form = arg.ToWWWForm();
		Dictionary<string,string> headers = form.headers;
		headers["netid"]=net_id.ToString();
		www = new WWW( url, form.data, headers);

        #if !RELEASE
       
        int length = 1000;
        bool sendCml = false;
        switch(Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
                length = 90000;
                sendCml = false;
                break;
            default: 
                length = 1000;
                sendCml = true;
                break;
        }
        if(arg.ToString().Length > length)
        {
			Debug.Log("[SEND]:"+ url+"      args:"+arg.ToString().Substring(0, length));
        }
        else
        {
            Debug.Log("[SEND]:"+ url+"      "+arg.ToString());
        }
			
        #else
        if(Config.ModeDebug || GameInfo.Instance.showLog)
        {
            if(mArg.ToString().Length>1000)
            {
                Debug.Log("[SEND]:"+ url+"      "+mArg.ToString().Substring(0,1000));
            }
            else
            {
                Debug.Log("[SEND]:"+ url+"      "+mArg.ToString());
            }
        }
        #endif

		m_time=Time.time;
	}
	
	float m_time=0.0f;
	public void GetRequest()
	{
		DisposeWWW();
		State = RoutineState.Processing;
   		string url = commandInfo.url;

		www = new WWW( url );
		m_time=Time.time;
	}
		
	public void Update()
	{
		if(State != RoutineState.Processing) return;

		if(www != null && www.isDone)
		{
			State = RoutineState.Suspended;
			if(www.error != null)
			{
                OnHttpError(www.error);
			}
			else
			{
                OnHttpResponse();
			}
		}
		else
		{
			processingTime += Time.deltaTime;
            if(processingTime > NetworkConfiger.mTimeLimit)
			{
                OnTimeOut();
			}
		}
	}





	private void OnHttpResponse()
	{
		string result = "";
#if ((UNITY_ANDROID || UNITY_STANDALONE_WIN) && !UNITY_EDITOR) || UNITY_EDITOR_WIN 
		if (www.responseHeaders.ContainsKey("CONTENT-ENCODING") && www.responseHeaders["CONTENT-ENCODING"].Equals("deflate"))
		{	
			result = NetworkUtil.UnzipString(www.bytes);
		}
		else result = www.text;
#else
		result = www.text;
#endif
		NetworkManager.delay = Time.time - m_time;

        switch(Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
                if(result.Length > 16000) 
                {
                    Debug.Log("[BACK]:  "+www.url+" "+(Time.time-m_time).ToString("0.0")+"s :"+result.Substring(0,16000));
                    Debug.Log("+  "+www.url+" "+(Time.time-m_time).ToString("0.0")+"s :"+result.Substring(16000));
                }
                else 
                {
                    Debug.Log("[BACK]:  "+www.url+" "+(Time.time-m_time).ToString("0.0")+"s :"+result);
                }
                break;
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:


                #if !RELEASE

                if(result.Length > 1000) Debug.Log("[BACK]:  "+www.url+" "+(Time.time-m_time).ToString("0.0")+"s :"+result.Substring(0,1000));
                else Debug.Log("[BACK]:  "+www.url+" "+(Time.time-m_time).ToString("0.0")+"s :"+result);

                // // 输入到内嵌命令行
                // if (result.Length > 1050)
                // {
				// 	ConsoleMgr.Instance.WriteLine(LogLevel.Debug, ("[BACK]:  " + www.url + " " + (Time.time - m_time).ToString("0.0") + "s :" + result.Substring(1050)));
                // }
                // else
                // {
				// 	ConsoleMgr.Instance.WriteLine(LogLevel.Debug, ("[BACK]:  " + www.url + " " + (Time.time - m_time).ToString("0.0") + "s :" + result));
                // }

                #else
				if(GameCore.Conf.Instance.ModeDebug)
                {
                    if(result.Length > 1000) Debug.Log("[BACK]:  "+mWWW.url+" "+(Time.time-m_time).ToString("0.0")+"s :"+result.Substring(0,1000));
                    else Debug.Log("[BACK]:  "+mWWW.url+" "+(Time.time-m_time).ToString("0.0")+"s :"+result);

                }
                #endif
                break;
        }


		if(string.IsNullOrEmpty(result))
		{
			State = RoutineState.Suspended;
            var msg = new NetMsg<string>();
            msg.code = -1;
            msg.err = "no result";
            OnException(msg);
			return;
		}

		if (!result.StartsWith("{"))
		{
			byte[] bytesData = System.Convert.FromBase64String(result);
			result = EncryptionMgr.Instance.DecryptStringFromBytes(bytesData);
			#if UNITY_EDITOR
			if(result.Length > 1000) Debug.Log("[BACK]:  "+www.url+" "+(Time.time-m_time).ToString("0.0")+"s :"+result.Substring(0,1000));
			else Debug.Log("[BACK]:  "+www.url+" "+(Time.time-m_time).ToString("0.0")+"s :"+result);
			#endif
		}
	
		string code = result.Substring(8,3);
		if(code.Equals("200"))
		{
            // 200 success
			Type classType = null;
            classType = commandInfo.runtimeClass; 
            NetBaseMsg msg = JsonMapperExtend.ToObject(classType, result) as NetBaseMsg;
			if(NetworkManager.requestSuccessPredealHandler != null ) NetworkManager.requestSuccessPredealHandler.Invoke(msg);
			if(successCallback!= null )successCallback.Invoke(msg);
		}
		else if(code.Equals("203"))
		{
            // 203 server application not luanched
            var msg = NetworkUtil.MainJasonMapper().ToObject<NetMsg<string>>(result); 
            OnException(msg);
		}
		else if(code.Equals("204"))
		{
            // 207 data locked
            var msg = NetworkUtil.MainJasonMapper().ToObject<NetMsg<string>>(result); 
            OnException(msg);
			return;
			
		}
		else if(code.Equals("206"))
		{
            // 206 Repeated
            var msg = NetworkUtil.MainJasonMapper().ToObject<NetMsg<string>>(result); 
            OnException(msg);
		}
		else if(code.Equals("207"))
		{
            // 207 Id Frozen
            var msg = NetworkUtil.MainJasonMapper().ToObject<NetMsg<string>>(result);
            OnException(msg);	
		}
		else if(code.Equals("208"))
		{
            // 208 Specal: Do nothing
		}
		else 
		{
            // Fail
            NetMsg<string> msg = NetworkUtil.MainJasonMapper().ToObject<NetMsg<string>>(result); 
			if(failCallback != null) failCallback.Invoke(msg);
		}
		State = RoutineState.Idle;
	}

    void OnException(NetMsg<string> msg)
    {
		bool? suspend = null;
		if(exceptionCallback != null)
		{
			suspend = exceptionCallback.Invoke(msg);
		}
        if(suspend == true)
        {
            this.State = RoutineState.Suspended;
        }
        else
        {
            this.State = RoutineState.Idle;
        }
    }

	public void OnHttpError(string errorMsg)
	{
        Debug.LogError("HTTP ERROR:" + errorMsg);
		if (commandInfo.isBackGround)
		{
			State = RoutineState.Idle;
		}
		else
		{
			State = RoutineState.Suspended;

            //                #if !RELEASE
            //
            //                CommandLineControl.Instance.WriteLine(LogLevel.Error, "network fatal: " + errorMsg);
            //                
            //                #endif
            var msg = new NetMsg<string>();
            msg.code = -1;
            msg.err = errorMsg;
            msg.ret = "HTTP_ERROR";
            OnException(msg);
		}


	}

	public void OnTimeOut()
	{
		if (commandInfo.isBackGround) 
		{
			State = RoutineState.Idle;
		}
		else
		{
			State = RoutineState.Suspended;
            var msg = new NetMsg<string>();
            msg.code = -1;
            msg.err = "time out";
            msg.ret = "TIME_OUT";
            OnException(msg);
		}

	}

}


