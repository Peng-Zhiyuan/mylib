using System;
using System.Text;
using GameCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public static class SpecialPuncFilter
{
	private static Regex regex;

	private static Regex Regex {
		get {
			if (regex == null) {
				string s = @"[^a-zA-Z0-9\u4e00-\u9fa5]";
				regex = new Regex (s, RegexOptions.IgnoreCase);
			}

			return regex;
		}
	}

	public static bool Find (string strOutput)
	{
		return Regex.IsMatch (strOutput);
	}
}

public static class NumberPuncFilter
{
	private static Regex regex;

	private static Regex Regex {
		get {
			if (regex == null) {
				string s = @"[^0-9]";
				regex = new Regex (s, RegexOptions.IgnoreCase);
			}

			return regex;
		}
	}

	public static bool Find (string strOutput)
	{
		return Regex.IsMatch (strOutput);
	}
}




public static class KeyWordFilter
{
	public static Dictionary<string,string> mask_data = new Dictionary<string, string>();
	private static Dictionary<char, CharNode> dict;
	private static int Compare(string _l, string _r)
	{
		return string.Compare(_l,_r);
	}
	private static Dictionary<char, CharNode> Dict {
		get {
			if (dict == null)
			{
				dict = new Dictionary<char, CharNode> ();
				foreach (string key in mask_data.Keys) {
					Add (mask_data[key]);
				}

			}
			return dict;
		}
	}

	public static bool Find (string origionString)
	{
		int len = origionString.Length, i = 0;
		string lows = origionString;//origionString.ToLower ();
		char _char;
		while (i < len) {
			_char = lows [i];
			if (Dict.ContainsKey (_char)) {
				//find the world
				if (Dict [_char].Find (lows, i))
					return true;
			}
			++i;
		}
		return false;
	}

	public static bool Replace (StringBuilder replaceString, string intpuntstring, char replaceChar)
	{
		int len = intpuntstring.Length, index = 0;
		char _char;
		while (index < len) {
			_char = intpuntstring [index];
			if (Dict.ContainsKey (_char)) {
				//replace the world
				if (Dict [_char].Replace (replaceString, intpuntstring, index, replaceChar)){
					replaceString [index] = replaceChar;
					return true;
				}
			}
			++index;
		}
		return false;
	}

	private static void Add (IList<string> ict)
	{
		foreach (string item in ict) {
			//UnityEngine.Debug.Log("filter:"+item.world);

			Add (item);
		}
	}

	private static void Add (string oldStr)
	{
		if (string.IsNullOrEmpty (oldStr))
			return;

		char _char = oldStr [0];
		if (dict.ContainsKey (_char)) {
			if (oldStr.Length == 1) {
				return;
			} else {
				oldStr = oldStr.Substring (1, oldStr.Length - 1);
				dict [_char].Add (oldStr);
			}
		} else {
			if (oldStr.Length == 1) {
				CharNode node = new CharNode (true);
				dict.Add (_char, node);
			} else {
				CharNode node = new CharNode (false);
				dict.Add (_char, node);
				oldStr = oldStr.Substring (1, oldStr.Length - 1);
				node.Add (oldStr);
			}
		}
	}
}

public class CharNode
{
	//private char name;
	private Dictionary<char, CharNode> dict;

	private Dictionary<char, CharNode> Dict {
		get {
			if (dict == null)
				dict = new Dictionary<char, CharNode> ();
			return dict;
		}
	}

	private bool isEnded;

	public CharNode (bool ended)
	{
		this.isEnded = ended;
	}

	public bool Find (string intpuntstring, int i)
	{
		if (this.isEnded)
			return true;
		
		int index = i + 1;
		if (index >= intpuntstring.Length)
			return false;
		
		char nextchar = intpuntstring [index];
		if (Dict.ContainsKey (nextchar)) {
			return Dict [nextchar].Find (intpuntstring, index);
		} else {
			return false;
		}
	}

	public bool Replace (StringBuilder replaceString, string intpuntstring, int i, char replaceChar)
	{
		if (this.isEnded)
			return true;

		int index = i + 1;
		if (index >= intpuntstring.Length)
			return false;

		char nextchar = intpuntstring [index];
		if (Dict.ContainsKey (nextchar)) {
			if (Dict [nextchar].Replace (replaceString, intpuntstring, index, replaceChar)) {
				replaceString [index] = replaceChar;
				return true;
			}
			return false;
		} else {
			return false;
		}
	}

	public void Add (string oldStr)
	{
		char _char = oldStr [0];
		if (oldStr.Length == 1) {
			if (Dict.ContainsKey (_char)) {
				return;
			} else {
				Dict.Add (_char, new CharNode (true));
			}
		} else {
			if (Dict.ContainsKey (_char)) {
				oldStr = oldStr.Substring (1, oldStr.Length - 1);
				Dict [_char].Add (oldStr);
			} else {
				CharNode node = new CharNode (false);
				Dict.Add (_char, node);
				oldStr = oldStr.Substring (1, oldStr.Length - 1);
				node.Add (oldStr);
			}
		}
	}
}
