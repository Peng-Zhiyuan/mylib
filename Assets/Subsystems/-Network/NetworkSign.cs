using UnityEngine;
using System.Collections.Generic;
using GameCore;
using System.Text;
using System.Security.Cryptography;
using System;
using System.IO;

public class NetworkSign:Single<NetworkSign>
{


		private  string secret = "";
		public  string Secret
		{
			set
			{
				secret= value;
			}
		}


		public string MD5CryptoServiceProvider(string plaintext)
		{

			plaintext+="&"+secret;
			//Debug.LogError("plaintext:"+plaintext);
			byte[] result = Encoding.UTF8.GetBytes(plaintext.Trim());    //tbPass为输入密码的文本框  
			MD5 md5 = new MD5CryptoServiceProvider();  
			byte[] output = md5.ComputeHash(result);  
			return BitConverter.ToString(output).Replace("-","").ToLower();
		}

}
