using UnityEngine;
using System.Collections.Generic;
public class BranchData
{
	public string affcode="common";
	public int gver = 100;
	public int force = 0;
	public string url;

}

public class GameVesoinData
{

	public int data_ver=0;
	public int hot_ver=0;
	public int pack_ver=0;
	public string data_md5;
	public string hot_md5;
	public string pack_md5;
	public int data_size;
	public int debug = 0;
    public int cui = 0;
	public List<BranchData> branches;
}