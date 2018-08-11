using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandLineFloating : Floating 
{
	public Text text;
	public GameObject content;
	public GameObject hideContent;

	public static CommandLineFloating instance;

	public override void OnCreate()
	{
		instance = this;
		ConsoleService.Instance.OnPrint += OnPrint;
		this.Hide();
	}

	private void OnPrint(LogLevel level, string msg)
	{
		Log(msg);
	}

	public void Log(string msg)
	{
		var s = text.text;
		s += "\n";
		s += msg;
		if(s.Length > 2000)
		{
			s = s.Substring(s.Length - 2000);
		}
		text.text = s;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.BackQuote))
		{
			ToggleVisible();
		}
	}

	private bool _isVisible;
	public void ToggleVisible()
	{
		if(_isVisible)
		{
			this.Hide();
		}
		else
		{
			this.Show();
		}
	}

	public void Hide()
	{
		_isVisible = false;
		this.content.SetActive(false);
		this.hideContent.SetActive(true);
	}

	public void Show()
	{
		_isVisible = true;
		this.content.SetActive(true);
		this.hideContent.SetActive(false);
	}

	public void OnCloseButton()
	{
		this.Hide();
	}

	public void OnOpenButton()
	{
		this.Show();
	}
}
