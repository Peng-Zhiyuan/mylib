using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public delegate void FileSelecterDel(List<string> _list);
public class FileSelecter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	static FileSelecter _single=null;
	public static FileSelecter GetSingle()
	{
		if(_single==null)
		{
			_single=GameObject.FindObjectOfType<FileSelecter>();
		}
		return _single;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClose()
	{
		m_root.SetActive(false);
	}
	public void Show(List<FileSeLineInfo> _list,FileSelecterDel _del)
	{
		m_root.SetActive(true);
		m_del=_del;
		for(int i=0;i<m_line_list.Count;++i)
		{
			GameObject.Destroy(m_line_list[i].gameObject);
		}
		m_line_list.Clear();
		for(int i=0;i<_list.Count;++i)
		{
			//_list[i]
			GameObject _unit=GameObject.Instantiate(m_line_pref) as GameObject;
			_unit.transform.parent=m_line_root;
			_unit.transform.localPosition=new Vector3(0,-38*i,0);
			_unit.GetComponent<FileSelLine>().SetInfo(_list[i]);
			_unit.transform.localScale=Vector3.one;
			m_line_list.Add(_unit.GetComponent<FileSelLine>());
			_unit.SetActive(true);
		}
	}

	public void Ok()
	{
		if(m_del!=null)
		{
			List<string> _list=new List<string>();
			for(int i=0;i<m_line_list.Count;++i)
			{
				if(m_line_list[i].make_tog.value)
				{
					_list.Add(m_line_list[i].GetFileName());
				}
			}
			m_del(_list);
		}
		m_root.SetActive(false);
	}
	public void All()
	{
		for(int i=0;i<m_line_list.Count;++i)
		{
			m_line_list[i].make_tog.value=true;
		}
	}
	public void Clear()
	{
		for(int i=0;i<m_line_list.Count;++i)
		{
			m_line_list[i].make_tog.value=false;
		}
	}
	List<FileSelLine> m_line_list=new List<FileSelLine>();
	public GameObject m_line_pref;
	public Transform m_line_root;
	public GameObject m_root;
	FileSelecterDel m_del;
}
