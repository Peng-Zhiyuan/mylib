using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
public class EncryptionMgr:Single<EncryptionMgr> 
{
	//public static EncryptionMgr Instance = new EncryptionMgr();
	public EncryptionMgr()
	{
		Init();
	}

	public void Init()
	{
		if (mInit)
			return;

		mAesManaged = new RijndaelManaged();

//		byte[] key = ReadBytesFromFile("Config/data");
//		byte[] IV = ReadBytesFromFile("Config/data2");

		byte[] key = System.Text.Encoding.UTF8.GetBytes("abcde234123");;
		byte[] IV = System.Text.Encoding.UTF8.GetBytes("s9afn1@#$!#asdfi");
		mAesManaged.KeySize = 128;
		mAesManaged.BlockSize = 128;
		mAesManaged.Mode = CipherMode.CBC;

		mAesManaged.Key = key;
		mAesManaged.IV = IV;

		//Test();
		
	}

	public byte[] EncryptStringToBytes(string plainText)
	{
		// Check arguments. 
		if (plainText == null || plainText.Length <= 0)
			throw new ArgumentNullException("plainText");
		if (mAesManaged.Key == null || mAesManaged.Key.Length <= 0)
			throw new ArgumentNullException("Key");
		if (mAesManaged.IV == null || mAesManaged.IV.Length <= 0)
			throw new ArgumentNullException("IV");
		byte[] encrypted;
		// Create an RijndaelManaged object 
		// with the specified key and IV. 
		//using (RijndaelManaged rijAlg = new RijndaelManaged())
		{
			RijndaelManaged rijAlg = mAesManaged;

			// Create a decrytor to perform the stream transform.
			ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
			
			// Create the streams used for encryption. 
			using (MemoryStream msEncrypt = new MemoryStream())
			{
				using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				{
					using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
					{
						
						//Write all data to the stream.
						swEncrypt.Write(plainText);
					}
					encrypted = msEncrypt.ToArray();
				}
			}
		}
		
		// Return the encrypted bytes from the memory stream. 
		return encrypted;
		
	}
	
	public string DecryptStringFromBytes(byte[] cipherText)
	{
		// Check arguments. 
		if (cipherText == null || cipherText.Length <= 0)
			throw new ArgumentNullException("cipherText");
		if (mAesManaged.Key == null || mAesManaged.Key.Length <= 0)
			throw new ArgumentNullException("Key");
		if (mAesManaged.IV == null || mAesManaged.IV.Length <= 0)
			throw new ArgumentNullException("IV");
		
		// Declare the string used to hold 
		// the decrypted text. 
		string plaintext = null;
		
		// Create an RijndaelManaged object 
		// with the specified key and IV. 
		//using (RijndaelManaged rijAlg = new RijndaelManaged())
		{
			RijndaelManaged rijAlg = mAesManaged;

			// Create a decrytor to perform the stream transform.
			ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
			
			// Create the streams used for decryption. 
			using (MemoryStream msDecrypt = new MemoryStream(cipherText))
			{
				using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
				{
					using (StreamReader srDecrypt = new StreamReader(csDecrypt))
					{
						
						// Read the decrypted bytes from the decrypting stream 
						// and place them in a string.
						plaintext = srDecrypt.ReadToEnd();
					}
				}
			}
			
		}
		
		return plaintext;
	}

//	public void Test(string text)
//	{
//		//string text = "Magic Code";
//		Debug.Log("－－－－－－－－－－－－－－－－－输入明文:"+text);
//		byte[] encryptedBytes = EncryptStringToBytes(text);
//		Debug.Log("－－－－－－－－－－－－－－－－－加密byte:"+encryptedBytes.ToStringArray());
//		string encryptedStr = System.Convert.ToBase64String(encryptedBytes);
//		Debug.Log("－－－－－－－－－－－－－－－Base64string:"+encryptedStr);
//		//WriteBytesToFile("test", encryptedBytes);
//	}

	private void WriteBytesToFile(string fileName, byte[] bytes)
	{
		File.WriteAllBytes(UnityEngine.Application.dataPath + "/" + fileName, bytes);
	}

	private byte[] ReadBytesFromFile(string fileName)
	{
		//return File.ReadAllBytes(UnityEngine.Application.dataPath + "/Resources/" + fileName);
		TextAsset asset = Resources.Load(fileName) as TextAsset;
		Stream s = new MemoryStream(asset.bytes);
		BinaryReader br = new BinaryReader(s);
		return br.ReadBytes(1024);
	}

	public byte[] GetBytes(string str)
	{
		byte[] bytes = new byte[str.Length * sizeof(char)];
		System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
		return bytes;
	}
	
	public string GetString(byte[] bytes)
	{
		char[] chars = new char[bytes.Length / sizeof(char)];
		System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
		return new string(chars);
	}

	public bool NeedEncrypt(string url)
	{
		return false;
	}

	private bool mInit = false;
	private RijndaelManaged mAesManaged = null;
}
