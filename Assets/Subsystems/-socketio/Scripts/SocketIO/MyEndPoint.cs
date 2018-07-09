using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using System.Collections.Generic;
//using NetworkFrame;
using System.Text;
using System.IO;
namespace System.Net
{
public class MyEndPoint : EndPoint {

	private IPEndPoint mIPEndPoint;
	public IPEndPoint IpEndPoint
	{
		get
		{
			return mIPEndPoint;
		}
	}
//	public IPAddress address
//	{
//			get
//			{
//				mIPEndPoint.Address;
//			}	
//	}
	public const int MaxPort = 0xffff;
	public const int MinPort = 0;
//	private int port;
	public MyEndPoint(long iaddr, int port)
	{
		mIPEndPoint = new IPEndPoint(iaddr, port);
	}
	public MyEndPoint(IPAddress address, int port)
	{
		mIPEndPoint = new IPEndPoint(address, port);
	}
	public override EndPoint Create(SocketAddress socketaddr)
	{
		return mIPEndPoint.Create(socketaddr);
	}
	public override bool Equals(object obj)
	{
		return mIPEndPoint.Equals(((MyEndPoint)obj).IpEndPoint);
	}
	public override int GetHashCode()
	{
		return mIPEndPoint.GetHashCode();
	}
	public override  SocketAddress Serialize()
	{
		return mIPEndPoint.Serialize();
	}
	public override string ToString()
	{
		return mIPEndPoint.ToString();
	}

	public IPAddress Address
	{
		get
		{
			return mIPEndPoint.Address;
		}
		set
		{
			mIPEndPoint.Address = value;
		}
	}
	public override AddressFamily AddressFamily
	{
		get
		{
			return mIPEndPoint.AddressFamily;
		}
	}
	public int Port
	{
		get
		{
			return mIPEndPoint.Port;
		}
		set
		{
			mIPEndPoint.Port = value;
		}
	}

}
}