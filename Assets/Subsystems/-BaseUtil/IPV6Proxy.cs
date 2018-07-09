using UnityEngine;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System;

public class IPV6Proxy:Single<IPV6Proxy>
{
	public static string HTTP {
		get {
			return "http://";
		}
	}

	#if UNITY_IPHONE
		[DllImport("__Internal")]
		private static extern string _GetIPv6(string mHost, string mPort);  
	#endif

	private static string GetIPv6(string mHost, string mPort)
	{
		#if UNITY_IPHONE && !UNITY_EDITOR
			string mIPv6 = _GetIPv6(mHost, mPort);
			return mIPv6;
		#else
		return mHost + "&&ipv4";
		#endif
	}

	public string ConvertIPWithHTTPHead(string ip, int ports)
	{
		return HTTP + ConvertIP(ip, ports);
	}

	public string ConvertIP(string ip, int ports)
	{
		AddressFamily newAddressFamily = AddressFamily.InterNetwork;
		string newIp = ip;
		try {
			string mIPv6 = GetIPv6(ip, ports.ToString());
			if (!string.IsNullOrEmpty(mIPv6)) {
				string[] m_StrTemp = System.Text.RegularExpressions.Regex.Split(mIPv6, "&&");
				if (m_StrTemp != null && m_StrTemp.Length >= 2) {
					string IPType = m_StrTemp[1];
					if (IPType == "ipv6") {
						newIp = m_StrTemp[0];
						newAddressFamily = AddressFamily.InterNetworkV6;
						return "[" + newIp + "]" + ":" + ports;
					}
				}
			}
		} catch (Exception e) {
			Debug.Log("GetIPv6 error:" + e);
		}
		return  newIp + ":" + ports;

	}

}
