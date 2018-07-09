using UnityEngine;
using System.Collections.Generic;
using System.Net.Sockets;
using SocketIO;

class McMessage
{
	public string name;
    public object arg;
}

public class McError
{
	public int code;
	public string msg;
}

public class SocketRoutine : IUpdatable
{
	protected virtual void RegisterListener()
	{
		socket.On("open", OnOpen);
		socket.On("connect", OnConnect);
		socket.On("disconnect", OnDisConnect);
		socket.On("error", OnError);
		socket.On("close", OnClose);
	}

	protected virtual void UnregisterListener()
	{
		socket.Off("open", OnOpen);
		socket.Off("connect", OnConnect);
		socket.Off("disconnect", OnDisConnect);
		socket.Off("error", OnError);
		socket.Off("close", OnClose);
	}

	public void Init(string socket_url)
	{
		
		Debug.Log("Socket Init");
		if (socket == null) 
        {
			GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/SocketIO") as GameObject);
			go.name = this.GetType().Name;
			socket = go.GetComponent<SocketIOComponent>();
			GameObject.DontDestroyOnLoad(go);
		}

		//IPv6转换	
		string[] info = socket_url.Split(':');
		string convert_url = IPV6Proxy.Instance.ConvertIP(info[0],int.Parse(info[1]));
		info = convert_url.Split(':');

		string _url = "ws://" + info[0] + ":" + info[1] + "/socket.io/?EIO=4&transport=websocket";
		socket.Init(_url);
		RegisterListener();
		UpdateManager.Add(this);
		TryConnect();
	}

	public void Close()
	{
		if (socket != null) 
        {
			socket.Close();
			UnregisterListener();
			m_state_check_tick = -1;
			willSendQueue.Clear();
			UpdateManager.Remove(this);
			GameObject.Destroy(socket.gameObject);
		}
	}

    public void Send(string name, object arg)
	{
        Debug.Log($"[MessageCenter] Enqueue: {name}");
        McMessage msg = new McMessage();
		msg.name = name;
		msg.arg = arg;
        willSendQueue.Enqueue(msg);
	}

	protected virtual void OnOpen(SocketIOEvent e)
	{
		Debug.Log("Socket Message OnOpen:" + e.data);
	}

	protected virtual void OnConnect(SocketIOEvent e)
	{
		Debug.Log("Socket Message OnConnect:" + e.data);
	}

	protected virtual void OnDisConnect(SocketIOEvent e)
	{
		Debug.Log("Socket Message OnDisConnect:" + e.data);
	}

	protected virtual void OnError(SocketIOEvent e)
	{
		Debug.Log("Socket Message OnError:" + e.data);
	}

	protected virtual void OnClose(SocketIOEvent e)
	{	
		Debug.Log("Socket Message OnError:" + e.data);
	}

	public void Update()
	{
		if (socket == null || !socket.IsConnected) 
        {
			return;
		}

		if (willSendQueue.Count > 0) 
        {
            var msg = willSendQueue.Dequeue();
            Debug.Log($"[MessageCenter] send: {msg.name}");
            var argJson = CustomLitJson.JsonMapper.Instance.ToJson(msg.arg);
            var argJsonObject = new JSONObject(argJson);
			socket.Emit(msg.name, argJsonObject);
		}
	}


	//	public void Test()
	//	{
	//		Debug.LogError("socket.IsConnected:"+socket.IsConnected);
	//		Close();
	//		StartConnect();
	//
	//	}
	//	public void StartConnect()
	//	{
	//		string[] _ss = SelectServerState.Instance.CurServer.socket.Split(':');
	//		string _url="ws://"+_ss[0]+":"+_ss[1]+"/socket.io/?EIO=4&transport=websocket";
	//		Init(_url);
	//		TryConnect();
	//		m_state_check_tick=-1.0f;
	//	}



	private bool checkNetReachable()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			return false;
		} else {
			return true;
		}
	}


	private void TryConnect()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable) {
			return;
		}

		if (!socket.IsConnected) {
			socket.Connect();
		}

	}

	private Queue<McMessage> willSendQueue = new Queue<McMessage>();
	protected SocketIOComponent socket;
	float m_state_check_tick = -1.0f;
}