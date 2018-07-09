using UnityEngine;
using System.Collections;

public class FileSeLineInfo
{
	public string lname;
	public string name;
	public float size;
	public string time;
	public bool ditry;
	public long tick;
}

public class FileSelLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetInfo(FileSeLineInfo _info)
	{
		m_raw=_info;
		name_label.text=_info.name;
		if(_info.size<1)
		{
			size_label.color=Color.white;
		}
		else if(_info.size<3)
		{
			size_label.color=Color.yellow;
		}
		else
		{
			size_label.color=Color.red;
		}
		size_label.text=_info.size.ToString("0.00")+"M";
		time_label.text=_info.time;
		make_tog.value=_info.ditry;
		modify_label.enabled=_info.ditry;
	}
	public string GetFileName()
	{
		return m_raw.lname;
	}
	FileSeLineInfo m_raw;
	public UILabel name_label;
	public UILabel size_label;
	public UILabel time_label;
	public UIToggle make_tog;
	public UILabel modify_label;
}
