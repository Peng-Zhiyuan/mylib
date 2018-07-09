//===========Code Maker By ETU=============
//===========Gool Luck===========
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CustomLitJson;
public partial class StaticDatar
{
JsonDic<JDAiBehaviorTree> _m_AiBehaviorTree_dic;
public void AiBehaviorTree_Pre()
{
	if(_m_AiBehaviorTree_dic==null)
	{
		if(m_AiBehaviorTree_dic.Count>0)return;
	}
}

public List<JDAiBehaviorTree> m_AiBehaviorTree_list
{
	get
	{
		return m_AiBehaviorTree_dic.DataList;
	}
}

public JsonDic<JDAiBehaviorTree> m_AiBehaviorTree_dic
{
	get
	{
		if(_m_AiBehaviorTree_dic==null)
		{
			string _data=LoadFile("AiBehaviorTree",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_AiBehaviorTree_dic=new JsonDic<JDAiBehaviorTree>(_data);
		}
		return _m_AiBehaviorTree_dic;
	}
}

JsonDic<JDAiDialog> _m_AiDialog_dic;
public void AiDialog_Pre()
{
	if(_m_AiDialog_dic==null)
	{
		if(m_AiDialog_dic.Count>0)return;
	}
}

public List<JDAiDialog> m_AiDialog_list
{
	get
	{
		return m_AiDialog_dic.DataList;
	}
}

public JsonDic<JDAiDialog> m_AiDialog_dic
{
	get
	{
		if(_m_AiDialog_dic==null)
		{
			string _data=LoadFile("AiDialog",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_AiDialog_dic=new JsonDic<JDAiDialog>(_data);
		}
		return _m_AiDialog_dic;
	}
}

JsonDic<JDArenaKing> _m_ArenaKing_dic;
public void ArenaKing_Pre()
{
	if(_m_ArenaKing_dic==null)
	{
		if(m_ArenaKing_dic.Count>0)return;
	}
}

public List<JDArenaKing> m_ArenaKing_list
{
	get
	{
		return m_ArenaKing_dic.DataList;
	}
}

public JsonDic<JDArenaKing> m_ArenaKing_dic
{
	get
	{
		if(_m_ArenaKing_dic==null)
		{
			string _data=LoadFile("ArenaKing",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_ArenaKing_dic=new JsonDic<JDArenaKing>(_data);
		}
		return _m_ArenaKing_dic;
	}
}

JsonDic<JDAwardReturn> _m_AwardReturn_dic;
public void AwardReturn_Pre()
{
	if(_m_AwardReturn_dic==null)
	{
		if(m_AwardReturn_dic.Count>0)return;
	}
}

public List<JDAwardReturn> m_AwardReturn_list
{
	get
	{
		return m_AwardReturn_dic.DataList;
	}
}

public JsonDic<JDAwardReturn> m_AwardReturn_dic
{
	get
	{
		if(_m_AwardReturn_dic==null)
		{
			string _data=LoadFile("AwardReturn",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_AwardReturn_dic=new JsonDic<JDAwardReturn>(_data);
		}
		return _m_AwardReturn_dic;
	}
}

JsonDic<JDAwardTitle> _m_AwardTitle_dic;
public void AwardTitle_Pre()
{
	if(_m_AwardTitle_dic==null)
	{
		if(m_AwardTitle_dic.Count>0)return;
	}
}

public List<JDAwardTitle> m_AwardTitle_list
{
	get
	{
		return m_AwardTitle_dic.DataList;
	}
}

public JsonDic<JDAwardTitle> m_AwardTitle_dic
{
	get
	{
		if(_m_AwardTitle_dic==null)
		{
			string _data=LoadFile("AwardTitle",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_AwardTitle_dic=new JsonDic<JDAwardTitle>(_data);
		}
		return _m_AwardTitle_dic;
	}
}

JsonDic<JDBannerActivity> _m_BannerActivity_dic;
public void BannerActivity_Pre()
{
	if(_m_BannerActivity_dic==null)
	{
		if(m_BannerActivity_dic.Count>0)return;
	}
}

public List<JDBannerActivity> m_BannerActivity_list
{
	get
	{
		return m_BannerActivity_dic.DataList;
	}
}

public JsonDic<JDBannerActivity> m_BannerActivity_dic
{
	get
	{
		if(_m_BannerActivity_dic==null)
		{
			string _data=LoadFile("BannerActivity",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_BannerActivity_dic=new JsonDic<JDBannerActivity>(_data);
		}
		return _m_BannerActivity_dic;
	}
}

JsonDic<JDBaseMail> _m_BaseMail_dic;
public void BaseMail_Pre()
{
	if(_m_BaseMail_dic==null)
	{
		if(m_BaseMail_dic.Count>0)return;
	}
}

public List<JDBaseMail> m_BaseMail_list
{
	get
	{
		return m_BaseMail_dic.DataList;
	}
}

public JsonDic<JDBaseMail> m_BaseMail_dic
{
	get
	{
		if(_m_BaseMail_dic==null)
		{
			string _data=LoadFile("BaseMail",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_BaseMail_dic=new JsonDic<JDBaseMail>(_data);
		}
		return _m_BaseMail_dic;
	}
}

JsonDic<JDBattleEfect> _m_BattleEfect_dic;
public void BattleEfect_Pre()
{
	if(_m_BattleEfect_dic==null)
	{
		if(m_BattleEfect_dic.Count>0)return;
	}
}

public List<JDBattleEfect> m_BattleEfect_list
{
	get
	{
		return m_BattleEfect_dic.DataList;
	}
}

public JsonDic<JDBattleEfect> m_BattleEfect_dic
{
	get
	{
		if(_m_BattleEfect_dic==null)
		{
			string _data=LoadFile("BattleEfect",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_BattleEfect_dic=new JsonDic<JDBattleEfect>(_data);
		}
		return _m_BattleEfect_dic;
	}
}

JsonDic<JDBranch> _m_Branch_dic;
public void Branch_Pre()
{
	if(_m_Branch_dic==null)
	{
		if(m_Branch_dic.Count>0)return;
	}
}

public List<JDBranch> m_Branch_list
{
	get
	{
		return m_Branch_dic.DataList;
	}
}

public JsonDic<JDBranch> m_Branch_dic
{
	get
	{
		if(_m_Branch_dic==null)
		{
			string _data=LoadFile("Branch",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_Branch_dic=new JsonDic<JDBranch>(_data);
		}
		return _m_Branch_dic;
	}
}

JsonDic<JDBroadCast> _m_BroadCast_dic;
public void BroadCast_Pre()
{
	if(_m_BroadCast_dic==null)
	{
		if(m_BroadCast_dic.Count>0)return;
	}
}

public List<JDBroadCast> m_BroadCast_list
{
	get
	{
		return m_BroadCast_dic.DataList;
	}
}

public JsonDic<JDBroadCast> m_BroadCast_dic
{
	get
	{
		if(_m_BroadCast_dic==null)
		{
			string _data=LoadFile("BroadCast",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_BroadCast_dic=new JsonDic<JDBroadCast>(_data);
		}
		return _m_BroadCast_dic;
	}
}

JsonDic<JDButtonCloseList> _m_ButtonCloseList_dic;
public void ButtonCloseList_Pre()
{
	if(_m_ButtonCloseList_dic==null)
	{
		if(m_ButtonCloseList_dic.Count>0)return;
	}
}

public List<JDButtonCloseList> m_ButtonCloseList_list
{
	get
	{
		return m_ButtonCloseList_dic.DataList;
	}
}

public JsonDic<JDButtonCloseList> m_ButtonCloseList_dic
{
	get
	{
		if(_m_ButtonCloseList_dic==null)
		{
			string _data=LoadFile("ButtonCloseList",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_ButtonCloseList_dic=new JsonDic<JDButtonCloseList>(_data);
		}
		return _m_ButtonCloseList_dic;
	}
}

JsonDic<JDClubFlag> _m_ClubFlag_dic;
public void ClubFlag_Pre()
{
	if(_m_ClubFlag_dic==null)
	{
		if(m_ClubFlag_dic.Count>0)return;
	}
}

public List<JDClubFlag> m_ClubFlag_list
{
	get
	{
		return m_ClubFlag_dic.DataList;
	}
}

public JsonDic<JDClubFlag> m_ClubFlag_dic
{
	get
	{
		if(_m_ClubFlag_dic==null)
		{
			string _data=LoadFile("ClubFlag",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_ClubFlag_dic=new JsonDic<JDClubFlag>(_data);
		}
		return _m_ClubFlag_dic;
	}
}

JsonDic<JDClubTaskGroup> _m_ClubTaskGroup_dic;
public void ClubTaskGroup_Pre()
{
	if(_m_ClubTaskGroup_dic==null)
	{
		if(m_ClubTaskGroup_dic.Count>0)return;
	}
}

public List<JDClubTaskGroup> m_ClubTaskGroup_list
{
	get
	{
		return m_ClubTaskGroup_dic.DataList;
	}
}

public JsonDic<JDClubTaskGroup> m_ClubTaskGroup_dic
{
	get
	{
		if(_m_ClubTaskGroup_dic==null)
		{
			string _data=LoadFile("ClubTaskGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_ClubTaskGroup_dic=new JsonDic<JDClubTaskGroup>(_data);
		}
		return _m_ClubTaskGroup_dic;
	}
}

JsonDic<JDCustomNotification> _m_CustomNotification_dic;
public void CustomNotification_Pre()
{
	if(_m_CustomNotification_dic==null)
	{
		if(m_CustomNotification_dic.Count>0)return;
	}
}

public List<JDCustomNotification> m_CustomNotification_list
{
	get
	{
		return m_CustomNotification_dic.DataList;
	}
}

public JsonDic<JDCustomNotification> m_CustomNotification_dic
{
	get
	{
		if(_m_CustomNotification_dic==null)
		{
			string _data=LoadFile("CustomNotification",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_CustomNotification_dic=new JsonDic<JDCustomNotification>(_data);
		}
		return _m_CustomNotification_dic;
	}
}

JsonDic<JDDrawGroupView> _m_DrawGroupView_dic;
public void DrawGroupView_Pre()
{
	if(_m_DrawGroupView_dic==null)
	{
		if(m_DrawGroupView_dic.Count>0)return;
	}
}

public List<JDDrawGroupView> m_DrawGroupView_list
{
	get
	{
		return m_DrawGroupView_dic.DataList;
	}
}

public JsonDic<JDDrawGroupView> m_DrawGroupView_dic
{
	get
	{
		if(_m_DrawGroupView_dic==null)
		{
			string _data=LoadFile("DrawGroupView",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_DrawGroupView_dic=new JsonDic<JDDrawGroupView>(_data);
		}
		return _m_DrawGroupView_dic;
	}
}

JsonDic<JDEncryptionList> _m_EncryptionList_dic;
public void EncryptionList_Pre()
{
	if(_m_EncryptionList_dic==null)
	{
		if(m_EncryptionList_dic.Count>0)return;
	}
}

public List<JDEncryptionList> m_EncryptionList_list
{
	get
	{
		return m_EncryptionList_dic.DataList;
	}
}

public JsonDic<JDEncryptionList> m_EncryptionList_dic
{
	get
	{
		if(_m_EncryptionList_dic==null)
		{
			string _data=LoadFile("EncryptionList",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_EncryptionList_dic=new JsonDic<JDEncryptionList>(_data);
		}
		return _m_EncryptionList_dic;
	}
}

JsonDic<JDFirstBattle> _m_FirstBattle_dic;
public void FirstBattle_Pre()
{
	if(_m_FirstBattle_dic==null)
	{
		if(m_FirstBattle_dic.Count>0)return;
	}
}

public List<JDFirstBattle> m_FirstBattle_list
{
	get
	{
		return m_FirstBattle_dic.DataList;
	}
}

public JsonDic<JDFirstBattle> m_FirstBattle_dic
{
	get
	{
		if(_m_FirstBattle_dic==null)
		{
			string _data=LoadFile("FirstBattle",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_FirstBattle_dic=new JsonDic<JDFirstBattle>(_data);
		}
		return _m_FirstBattle_dic;
	}
}

JsonDic<JDFirstBattleHero> _m_FirstBattleHero_dic;
public void FirstBattleHero_Pre()
{
	if(_m_FirstBattleHero_dic==null)
	{
		if(m_FirstBattleHero_dic.Count>0)return;
	}
}

public List<JDFirstBattleHero> m_FirstBattleHero_list
{
	get
	{
		return m_FirstBattleHero_dic.DataList;
	}
}

public JsonDic<JDFirstBattleHero> m_FirstBattleHero_dic
{
	get
	{
		if(_m_FirstBattleHero_dic==null)
		{
			string _data=LoadFile("FirstBattleHero",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_FirstBattleHero_dic=new JsonDic<JDFirstBattleHero>(_data);
		}
		return _m_FirstBattleHero_dic;
	}
}

JsonDic<JDFunctionAccessDetials> _m_FunctionAccessDetials_dic;
public void FunctionAccessDetials_Pre()
{
	if(_m_FunctionAccessDetials_dic==null)
	{
		if(m_FunctionAccessDetials_dic.Count>0)return;
	}
}

public List<JDFunctionAccessDetials> m_FunctionAccessDetials_list
{
	get
	{
		return m_FunctionAccessDetials_dic.DataList;
	}
}

public JsonDic<JDFunctionAccessDetials> m_FunctionAccessDetials_dic
{
	get
	{
		if(_m_FunctionAccessDetials_dic==null)
		{
			string _data=LoadFile("FunctionAccessDetials",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_FunctionAccessDetials_dic=new JsonDic<JDFunctionAccessDetials>(_data);
		}
		return _m_FunctionAccessDetials_dic;
	}
}

JsonDic<JDFunctionAccessTab> _m_FunctionAccessTab_dic;
public void FunctionAccessTab_Pre()
{
	if(_m_FunctionAccessTab_dic==null)
	{
		if(m_FunctionAccessTab_dic.Count>0)return;
	}
}

public List<JDFunctionAccessTab> m_FunctionAccessTab_list
{
	get
	{
		return m_FunctionAccessTab_dic.DataList;
	}
}

public JsonDic<JDFunctionAccessTab> m_FunctionAccessTab_dic
{
	get
	{
		if(_m_FunctionAccessTab_dic==null)
		{
			string _data=LoadFile("FunctionAccessTab",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_FunctionAccessTab_dic=new JsonDic<JDFunctionAccessTab>(_data);
		}
		return _m_FunctionAccessTab_dic;
	}
}

JsonDic<JDGuideHero> _m_GuideHero_dic;
public void GuideHero_Pre()
{
	if(_m_GuideHero_dic==null)
	{
		if(m_GuideHero_dic.Count>0)return;
	}
}

public List<JDGuideHero> m_GuideHero_list
{
	get
	{
		return m_GuideHero_dic.DataList;
	}
}

public JsonDic<JDGuideHero> m_GuideHero_dic
{
	get
	{
		if(_m_GuideHero_dic==null)
		{
			string _data=LoadFile("GuideHero",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_GuideHero_dic=new JsonDic<JDGuideHero>(_data);
		}
		return _m_GuideHero_dic;
	}
}

JsonDic<JDGuideStory> _m_GuideStory_dic;
public void GuideStory_Pre()
{
	if(_m_GuideStory_dic==null)
	{
		if(m_GuideStory_dic.Count>0)return;
	}
}

public List<JDGuideStory> m_GuideStory_list
{
	get
	{
		return m_GuideStory_dic.DataList;
	}
}

public JsonDic<JDGuideStory> m_GuideStory_dic
{
	get
	{
		if(_m_GuideStory_dic==null)
		{
			string _data=LoadFile("GuideStory",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_GuideStory_dic=new JsonDic<JDGuideStory>(_data);
		}
		return _m_GuideStory_dic;
	}
}

JsonDic<JDHeadFrame> _m_HeadFrame_dic;
public void HeadFrame_Pre()
{
	if(_m_HeadFrame_dic==null)
	{
		if(m_HeadFrame_dic.Count>0)return;
	}
}

public List<JDHeadFrame> m_HeadFrame_list
{
	get
	{
		return m_HeadFrame_dic.DataList;
	}
}

public JsonDic<JDHeadFrame> m_HeadFrame_dic
{
	get
	{
		if(_m_HeadFrame_dic==null)
		{
			string _data=LoadFile("HeadFrame",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_HeadFrame_dic=new JsonDic<JDHeadFrame>(_data);
		}
		return _m_HeadFrame_dic;
	}
}

JsonDic<JDLimitGift> _m_LimitGift_dic;
public void LimitGift_Pre()
{
	if(_m_LimitGift_dic==null)
	{
		if(m_LimitGift_dic.Count>0)return;
	}
}

public List<JDLimitGift> m_LimitGift_list
{
	get
	{
		return m_LimitGift_dic.DataList;
	}
}

public JsonDic<JDLimitGift> m_LimitGift_dic
{
	get
	{
		if(_m_LimitGift_dic==null)
		{
			string _data=LoadFile("LimitGift",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_LimitGift_dic=new JsonDic<JDLimitGift>(_data);
		}
		return _m_LimitGift_dic;
	}
}

JsonDic<JDLimitGiftItem> _m_LimitGiftItem_dic;
public void LimitGiftItem_Pre()
{
	if(_m_LimitGiftItem_dic==null)
	{
		if(m_LimitGiftItem_dic.Count>0)return;
	}
}

public List<JDLimitGiftItem> m_LimitGiftItem_list
{
	get
	{
		return m_LimitGiftItem_dic.DataList;
	}
}

public JsonDic<JDLimitGiftItem> m_LimitGiftItem_dic
{
	get
	{
		if(_m_LimitGiftItem_dic==null)
		{
			string _data=LoadFile("LimitGiftItem",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_LimitGiftItem_dic=new JsonDic<JDLimitGiftItem>(_data);
		}
		return _m_LimitGiftItem_dic;
	}
}

JsonDic<JDLimitGiftRef> _m_LimitGiftRef_dic;
public void LimitGiftRef_Pre()
{
	if(_m_LimitGiftRef_dic==null)
	{
		if(m_LimitGiftRef_dic.Count>0)return;
	}
}

public List<JDLimitGiftRef> m_LimitGiftRef_list
{
	get
	{
		return m_LimitGiftRef_dic.DataList;
	}
}

public JsonDic<JDLimitGiftRef> m_LimitGiftRef_dic
{
	get
	{
		if(_m_LimitGiftRef_dic==null)
		{
			string _data=LoadFile("LimitGiftRef",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_LimitGiftRef_dic=new JsonDic<JDLimitGiftRef>(_data);
		}
		return _m_LimitGiftRef_dic;
	}
}

JsonDic<JDMaskWord> _m_MaskWord_dic;
public void MaskWord_Pre()
{
	if(_m_MaskWord_dic==null)
	{
		if(m_MaskWord_dic.Count>0)return;
	}
}

public List<JDMaskWord> m_MaskWord_list
{
	get
	{
		return m_MaskWord_dic.DataList;
	}
}

public JsonDic<JDMaskWord> m_MaskWord_dic
{
	get
	{
		if(_m_MaskWord_dic==null)
		{
			string _data=LoadFile("MaskWord",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_MaskWord_dic=new JsonDic<JDMaskWord>(_data);
		}
		return _m_MaskWord_dic;
	}
}

JsonDic<JDMonster> _m_Monster_dic;
public void Monster_Pre()
{
	if(_m_Monster_dic==null)
	{
		if(m_Monster_dic.Count>0)return;
	}
}

public List<JDMonster> m_Monster_list
{
	get
	{
		return m_Monster_dic.DataList;
	}
}

public JsonDic<JDMonster> m_Monster_dic
{
	get
	{
		if(_m_Monster_dic==null)
		{
			string _data=LoadFile("Monster",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_Monster_dic=new JsonDic<JDMonster>(_data);
		}
		return _m_Monster_dic;
	}
}

JsonDic<JDMonster_gold> _m_Monster_gold_dic;
public void Monster_gold_Pre()
{
	if(_m_Monster_gold_dic==null)
	{
		if(m_Monster_gold_dic.Count>0)return;
	}
}

public List<JDMonster_gold> m_Monster_gold_list
{
	get
	{
		return m_Monster_gold_dic.DataList;
	}
}

public JsonDic<JDMonster_gold> m_Monster_gold_dic
{
	get
	{
		if(_m_Monster_gold_dic==null)
		{
			string _data=LoadFile("Monster_gold",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_Monster_gold_dic=new JsonDic<JDMonster_gold>(_data);
		}
		return _m_Monster_gold_dic;
	}
}

JsonDic<JDMsgList> _m_MsgList_dic;
public void MsgList_Pre()
{
	if(_m_MsgList_dic==null)
	{
		if(m_MsgList_dic.Count>0)return;
	}
}

public List<JDMsgList> m_MsgList_list
{
	get
	{
		return m_MsgList_dic.DataList;
	}
}

public JsonDic<JDMsgList> m_MsgList_dic
{
	get
	{
		if(_m_MsgList_dic==null)
		{
			string _data=LoadFile("MsgList",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_MsgList_dic=new JsonDic<JDMsgList>(_data);
		}
		return _m_MsgList_dic;
	}
}

JsonDic<JDMsgList1> _m_MsgList1_dic;
public void MsgList1_Pre()
{
	if(_m_MsgList1_dic==null)
	{
		if(m_MsgList1_dic.Count>0)return;
	}
}

public List<JDMsgList1> m_MsgList1_list
{
	get
	{
		return m_MsgList1_dic.DataList;
	}
}

public JsonDic<JDMsgList1> m_MsgList1_dic
{
	get
	{
		if(_m_MsgList1_dic==null)
		{
			string _data=LoadFile("MsgList1",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_MsgList1_dic=new JsonDic<JDMsgList1>(_data);
		}
		return _m_MsgList1_dic;
	}
}

JsonDic<JDMsgList2> _m_MsgList2_dic;
public void MsgList2_Pre()
{
	if(_m_MsgList2_dic==null)
	{
		if(m_MsgList2_dic.Count>0)return;
	}
}

public List<JDMsgList2> m_MsgList2_list
{
	get
	{
		return m_MsgList2_dic.DataList;
	}
}

public JsonDic<JDMsgList2> m_MsgList2_dic
{
	get
	{
		if(_m_MsgList2_dic==null)
		{
			string _data=LoadFile("MsgList2",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_MsgList2_dic=new JsonDic<JDMsgList2>(_data);
		}
		return _m_MsgList2_dic;
	}
}

JsonDic<JDMsgList3> _m_MsgList3_dic;
public void MsgList3_Pre()
{
	if(_m_MsgList3_dic==null)
	{
		if(m_MsgList3_dic.Count>0)return;
	}
}

public List<JDMsgList3> m_MsgList3_list
{
	get
	{
		return m_MsgList3_dic.DataList;
	}
}

public JsonDic<JDMsgList3> m_MsgList3_dic
{
	get
	{
		if(_m_MsgList3_dic==null)
		{
			string _data=LoadFile("MsgList3",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_MsgList3_dic=new JsonDic<JDMsgList3>(_data);
		}
		return _m_MsgList3_dic;
	}
}

JsonDic<JDNAmbit> _m_NAmbit_dic;
public void NAmbit_Pre()
{
	if(_m_NAmbit_dic==null)
	{
		if(m_NAmbit_dic.Count>0)return;
	}
}

public List<JDNAmbit> m_NAmbit_list
{
	get
	{
		return m_NAmbit_dic.DataList;
	}
}

public JsonDic<JDNAmbit> m_NAmbit_dic
{
	get
	{
		if(_m_NAmbit_dic==null)
		{
			string _data=LoadFile("NAmbit",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NAmbit_dic=new JsonDic<JDNAmbit>(_data);
		}
		return _m_NAmbit_dic;
	}
}

JsonDic<JDNAmbitAtt> _m_NAmbitAtt_dic;
public void NAmbitAtt_Pre()
{
	if(_m_NAmbitAtt_dic==null)
	{
		if(m_NAmbitAtt_dic.Count>0)return;
	}
}

public List<JDNAmbitAtt> m_NAmbitAtt_list
{
	get
	{
		return m_NAmbitAtt_dic.DataList;
	}
}

public JsonDic<JDNAmbitAtt> m_NAmbitAtt_dic
{
	get
	{
		if(_m_NAmbitAtt_dic==null)
		{
			string _data=LoadFile("NAmbitAtt",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NAmbitAtt_dic=new JsonDic<JDNAmbitAtt>(_data);
		}
		return _m_NAmbitAtt_dic;
	}
}

JsonDic<JDNAttrDesc> _m_NAttrDesc_dic;
public void NAttrDesc_Pre()
{
	if(_m_NAttrDesc_dic==null)
	{
		if(m_NAttrDesc_dic.Count>0)return;
	}
}

public List<JDNAttrDesc> m_NAttrDesc_list
{
	get
	{
		return m_NAttrDesc_dic.DataList;
	}
}

public JsonDic<JDNAttrDesc> m_NAttrDesc_dic
{
	get
	{
		if(_m_NAttrDesc_dic==null)
		{
			string _data=LoadFile("NAttrDesc",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NAttrDesc_dic=new JsonDic<JDNAttrDesc>(_data);
		}
		return _m_NAttrDesc_dic;
	}
}

JsonDic<JDNAvatar> _m_NAvatar_dic;
public void NAvatar_Pre()
{
	if(_m_NAvatar_dic==null)
	{
		if(m_NAvatar_dic.Count>0)return;
	}
}

public List<JDNAvatar> m_NAvatar_list
{
	get
	{
		return m_NAvatar_dic.DataList;
	}
}

public JsonDic<JDNAvatar> m_NAvatar_dic
{
	get
	{
		if(_m_NAvatar_dic==null)
		{
			string _data=LoadFile("NAvatar",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NAvatar_dic=new JsonDic<JDNAvatar>(_data);
		}
		return _m_NAvatar_dic;
	}
}

JsonDic<JDNAvatarShowConfig> _m_NAvatarShowConfig_dic;
public void NAvatarShowConfig_Pre()
{
	if(_m_NAvatarShowConfig_dic==null)
	{
		if(m_NAvatarShowConfig_dic.Count>0)return;
	}
}

public List<JDNAvatarShowConfig> m_NAvatarShowConfig_list
{
	get
	{
		return m_NAvatarShowConfig_dic.DataList;
	}
}

public JsonDic<JDNAvatarShowConfig> m_NAvatarShowConfig_dic
{
	get
	{
		if(_m_NAvatarShowConfig_dic==null)
		{
			string _data=LoadFile("NAvatarShowConfig",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NAvatarShowConfig_dic=new JsonDic<JDNAvatarShowConfig>(_data);
		}
		return _m_NAvatarShowConfig_dic;
	}
}

JsonDic<JDNBuffer> _m_NBuffer_dic;
public void NBuffer_Pre()
{
	if(_m_NBuffer_dic==null)
	{
		if(m_NBuffer_dic.Count>0)return;
	}
}

public List<JDNBuffer> m_NBuffer_list
{
	get
	{
		return m_NBuffer_dic.DataList;
	}
}

public JsonDic<JDNBuffer> m_NBuffer_dic
{
	get
	{
		if(_m_NBuffer_dic==null)
		{
			string _data=LoadFile("NBuffer",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NBuffer_dic=new JsonDic<JDNBuffer>(_data);
		}
		return _m_NBuffer_dic;
	}
}

JsonDic<JDNBufferXDamage> _m_NBufferXDamage_dic;
public void NBufferXDamage_Pre()
{
	if(_m_NBufferXDamage_dic==null)
	{
		if(m_NBufferXDamage_dic.Count>0)return;
	}
}

public List<JDNBufferXDamage> m_NBufferXDamage_list
{
	get
	{
		return m_NBufferXDamage_dic.DataList;
	}
}

public JsonDic<JDNBufferXDamage> m_NBufferXDamage_dic
{
	get
	{
		if(_m_NBufferXDamage_dic==null)
		{
			string _data=LoadFile("NBufferXDamage",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NBufferXDamage_dic=new JsonDic<JDNBufferXDamage>(_data);
		}
		return _m_NBufferXDamage_dic;
	}
}

JsonDic<JDNCharacterAttr> _m_NCharacterAttr_dic;
public void NCharacterAttr_Pre()
{
	if(_m_NCharacterAttr_dic==null)
	{
		if(m_NCharacterAttr_dic.Count>0)return;
	}
}

public List<JDNCharacterAttr> m_NCharacterAttr_list
{
	get
	{
		return m_NCharacterAttr_dic.DataList;
	}
}

public JsonDic<JDNCharacterAttr> m_NCharacterAttr_dic
{
	get
	{
		if(_m_NCharacterAttr_dic==null)
		{
			string _data=LoadFile("NCharacterAttr",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NCharacterAttr_dic=new JsonDic<JDNCharacterAttr>(_data);
		}
		return _m_NCharacterAttr_dic;
	}
}

JsonDic<JDNClass> _m_NClass_dic;
public void NClass_Pre()
{
	if(_m_NClass_dic==null)
	{
		if(m_NClass_dic.Count>0)return;
	}
}

public List<JDNClass> m_NClass_list
{
	get
	{
		return m_NClass_dic.DataList;
	}
}

public JsonDic<JDNClass> m_NClass_dic
{
	get
	{
		if(_m_NClass_dic==null)
		{
			string _data=LoadFile("NClass",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NClass_dic=new JsonDic<JDNClass>(_data);
		}
		return _m_NClass_dic;
	}
}

JsonDic<JDNEleAttr> _m_NEleAttr_dic;
public void NEleAttr_Pre()
{
	if(_m_NEleAttr_dic==null)
	{
		if(m_NEleAttr_dic.Count>0)return;
	}
}

public List<JDNEleAttr> m_NEleAttr_list
{
	get
	{
		return m_NEleAttr_dic.DataList;
	}
}

public JsonDic<JDNEleAttr> m_NEleAttr_dic
{
	get
	{
		if(_m_NEleAttr_dic==null)
		{
			string _data=LoadFile("NEleAttr",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NEleAttr_dic=new JsonDic<JDNEleAttr>(_data);
		}
		return _m_NEleAttr_dic;
	}
}

JsonDic<JDNElement> _m_NElement_dic;
public void NElement_Pre()
{
	if(_m_NElement_dic==null)
	{
		if(m_NElement_dic.Count>0)return;
	}
}

public List<JDNElement> m_NElement_list
{
	get
	{
		return m_NElement_dic.DataList;
	}
}

public JsonDic<JDNElement> m_NElement_dic
{
	get
	{
		if(_m_NElement_dic==null)
		{
			string _data=LoadFile("NElement",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NElement_dic=new JsonDic<JDNElement>(_data);
		}
		return _m_NElement_dic;
	}
}

JsonDic<JDNLevel> _m_NLevel_dic;
public void NLevel_Pre()
{
	if(_m_NLevel_dic==null)
	{
		if(m_NLevel_dic.Count>0)return;
	}
}

public List<JDNLevel> m_NLevel_list
{
	get
	{
		return m_NLevel_dic.DataList;
	}
}

public JsonDic<JDNLevel> m_NLevel_dic
{
	get
	{
		if(_m_NLevel_dic==null)
		{
			string _data=LoadFile("NLevel",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NLevel_dic=new JsonDic<JDNLevel>(_data);
		}
		return _m_NLevel_dic;
	}
}

JsonDic<JDNPCList> _m_NPCList_dic;
public void NPCList_Pre()
{
	if(_m_NPCList_dic==null)
	{
		if(m_NPCList_dic.Count>0)return;
	}
}

public List<JDNPCList> m_NPCList_list
{
	get
	{
		return m_NPCList_dic.DataList;
	}
}

public JsonDic<JDNPCList> m_NPCList_dic
{
	get
	{
		if(_m_NPCList_dic==null)
		{
			string _data=LoadFile("NPCList",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NPCList_dic=new JsonDic<JDNPCList>(_data);
		}
		return _m_NPCList_dic;
	}
}

JsonDic<JDNSkill> _m_NSkill_dic;
public void NSkill_Pre()
{
	if(_m_NSkill_dic==null)
	{
		if(m_NSkill_dic.Count>0)return;
	}
}

public List<JDNSkill> m_NSkill_list
{
	get
	{
		return m_NSkill_dic.DataList;
	}
}

public JsonDic<JDNSkill> m_NSkill_dic
{
	get
	{
		if(_m_NSkill_dic==null)
		{
			string _data=LoadFile("NSkill",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkill_dic=new JsonDic<JDNSkill>(_data);
		}
		return _m_NSkill_dic;
	}
}

JsonDic<JDNSkillCheck> _m_NSkillCheck_dic;
public void NSkillCheck_Pre()
{
	if(_m_NSkillCheck_dic==null)
	{
		if(m_NSkillCheck_dic.Count>0)return;
	}
}

public List<JDNSkillCheck> m_NSkillCheck_list
{
	get
	{
		return m_NSkillCheck_dic.DataList;
	}
}

public JsonDic<JDNSkillCheck> m_NSkillCheck_dic
{
	get
	{
		if(_m_NSkillCheck_dic==null)
		{
			string _data=LoadFile("NSkillCheck",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillCheck_dic=new JsonDic<JDNSkillCheck>(_data);
		}
		return _m_NSkillCheck_dic;
	}
}

JsonDic<JDNSkillEffectAni> _m_NSkillEffectAni_dic;
public void NSkillEffectAni_Pre()
{
	if(_m_NSkillEffectAni_dic==null)
	{
		if(m_NSkillEffectAni_dic.Count>0)return;
	}
}

public List<JDNSkillEffectAni> m_NSkillEffectAni_list
{
	get
	{
		return m_NSkillEffectAni_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectAni> m_NSkillEffectAni_dic
{
	get
	{
		if(_m_NSkillEffectAni_dic==null)
		{
			string _data=LoadFile("NSkillEffectAni",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectAni_dic=new JsonDic<JDNSkillEffectAni>(_data);
		}
		return _m_NSkillEffectAni_dic;
	}
}

JsonDic<JDNSkillEffectCall> _m_NSkillEffectCall_dic;
public void NSkillEffectCall_Pre()
{
	if(_m_NSkillEffectCall_dic==null)
	{
		if(m_NSkillEffectCall_dic.Count>0)return;
	}
}

public List<JDNSkillEffectCall> m_NSkillEffectCall_list
{
	get
	{
		return m_NSkillEffectCall_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectCall> m_NSkillEffectCall_dic
{
	get
	{
		if(_m_NSkillEffectCall_dic==null)
		{
			string _data=LoadFile("NSkillEffectCall",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectCall_dic=new JsonDic<JDNSkillEffectCall>(_data);
		}
		return _m_NSkillEffectCall_dic;
	}
}

JsonDic<JDNSkillEffectDamage> _m_NSkillEffectDamage_dic;
public void NSkillEffectDamage_Pre()
{
	if(_m_NSkillEffectDamage_dic==null)
	{
		if(m_NSkillEffectDamage_dic.Count>0)return;
	}
}

public List<JDNSkillEffectDamage> m_NSkillEffectDamage_list
{
	get
	{
		return m_NSkillEffectDamage_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectDamage> m_NSkillEffectDamage_dic
{
	get
	{
		if(_m_NSkillEffectDamage_dic==null)
		{
			string _data=LoadFile("NSkillEffectDamage",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectDamage_dic=new JsonDic<JDNSkillEffectDamage>(_data);
		}
		return _m_NSkillEffectDamage_dic;
	}
}

JsonDic<JDNSkillEffectFlag> _m_NSkillEffectFlag_dic;
public void NSkillEffectFlag_Pre()
{
	if(_m_NSkillEffectFlag_dic==null)
	{
		if(m_NSkillEffectFlag_dic.Count>0)return;
	}
}

public List<JDNSkillEffectFlag> m_NSkillEffectFlag_list
{
	get
	{
		return m_NSkillEffectFlag_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectFlag> m_NSkillEffectFlag_dic
{
	get
	{
		if(_m_NSkillEffectFlag_dic==null)
		{
			string _data=LoadFile("NSkillEffectFlag",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectFlag_dic=new JsonDic<JDNSkillEffectFlag>(_data);
		}
		return _m_NSkillEffectFlag_dic;
	}
}

JsonDic<JDNSkillEffectFly> _m_NSkillEffectFly_dic;
public void NSkillEffectFly_Pre()
{
	if(_m_NSkillEffectFly_dic==null)
	{
		if(m_NSkillEffectFly_dic.Count>0)return;
	}
}

public List<JDNSkillEffectFly> m_NSkillEffectFly_list
{
	get
	{
		return m_NSkillEffectFly_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectFly> m_NSkillEffectFly_dic
{
	get
	{
		if(_m_NSkillEffectFly_dic==null)
		{
			string _data=LoadFile("NSkillEffectFly",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectFly_dic=new JsonDic<JDNSkillEffectFly>(_data);
		}
		return _m_NSkillEffectFly_dic;
	}
}

JsonDic<JDNSkillEffectFx> _m_NSkillEffectFx_dic;
public void NSkillEffectFx_Pre()
{
	if(_m_NSkillEffectFx_dic==null)
	{
		if(m_NSkillEffectFx_dic.Count>0)return;
	}
}

public List<JDNSkillEffectFx> m_NSkillEffectFx_list
{
	get
	{
		return m_NSkillEffectFx_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectFx> m_NSkillEffectFx_dic
{
	get
	{
		if(_m_NSkillEffectFx_dic==null)
		{
			string _data=LoadFile("NSkillEffectFx",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectFx_dic=new JsonDic<JDNSkillEffectFx>(_data);
		}
		return _m_NSkillEffectFx_dic;
	}
}

JsonDic<JDNSkillEffectGround> _m_NSkillEffectGround_dic;
public void NSkillEffectGround_Pre()
{
	if(_m_NSkillEffectGround_dic==null)
	{
		if(m_NSkillEffectGround_dic.Count>0)return;
	}
}

public List<JDNSkillEffectGround> m_NSkillEffectGround_list
{
	get
	{
		return m_NSkillEffectGround_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectGround> m_NSkillEffectGround_dic
{
	get
	{
		if(_m_NSkillEffectGround_dic==null)
		{
			string _data=LoadFile("NSkillEffectGround",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectGround_dic=new JsonDic<JDNSkillEffectGround>(_data);
		}
		return _m_NSkillEffectGround_dic;
	}
}

JsonDic<JDNSkillEffectMove> _m_NSkillEffectMove_dic;
public void NSkillEffectMove_Pre()
{
	if(_m_NSkillEffectMove_dic==null)
	{
		if(m_NSkillEffectMove_dic.Count>0)return;
	}
}

public List<JDNSkillEffectMove> m_NSkillEffectMove_list
{
	get
	{
		return m_NSkillEffectMove_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectMove> m_NSkillEffectMove_dic
{
	get
	{
		if(_m_NSkillEffectMove_dic==null)
		{
			string _data=LoadFile("NSkillEffectMove",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectMove_dic=new JsonDic<JDNSkillEffectMove>(_data);
		}
		return _m_NSkillEffectMove_dic;
	}
}

JsonDic<JDNSkillEffectOther> _m_NSkillEffectOther_dic;
public void NSkillEffectOther_Pre()
{
	if(_m_NSkillEffectOther_dic==null)
	{
		if(m_NSkillEffectOther_dic.Count>0)return;
	}
}

public List<JDNSkillEffectOther> m_NSkillEffectOther_list
{
	get
	{
		return m_NSkillEffectOther_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectOther> m_NSkillEffectOther_dic
{
	get
	{
		if(_m_NSkillEffectOther_dic==null)
		{
			string _data=LoadFile("NSkillEffectOther",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectOther_dic=new JsonDic<JDNSkillEffectOther>(_data);
		}
		return _m_NSkillEffectOther_dic;
	}
}

JsonDic<JDNSkillEffectSaiya> _m_NSkillEffectSaiya_dic;
public void NSkillEffectSaiya_Pre()
{
	if(_m_NSkillEffectSaiya_dic==null)
	{
		if(m_NSkillEffectSaiya_dic.Count>0)return;
	}
}

public List<JDNSkillEffectSaiya> m_NSkillEffectSaiya_list
{
	get
	{
		return m_NSkillEffectSaiya_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectSaiya> m_NSkillEffectSaiya_dic
{
	get
	{
		if(_m_NSkillEffectSaiya_dic==null)
		{
			string _data=LoadFile("NSkillEffectSaiya",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectSaiya_dic=new JsonDic<JDNSkillEffectSaiya>(_data);
		}
		return _m_NSkillEffectSaiya_dic;
	}
}

JsonDic<JDNSkillEffectSe> _m_NSkillEffectSe_dic;
public void NSkillEffectSe_Pre()
{
	if(_m_NSkillEffectSe_dic==null)
	{
		if(m_NSkillEffectSe_dic.Count>0)return;
	}
}

public List<JDNSkillEffectSe> m_NSkillEffectSe_list
{
	get
	{
		return m_NSkillEffectSe_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectSe> m_NSkillEffectSe_dic
{
	get
	{
		if(_m_NSkillEffectSe_dic==null)
		{
			string _data=LoadFile("NSkillEffectSe",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectSe_dic=new JsonDic<JDNSkillEffectSe>(_data);
		}
		return _m_NSkillEffectSe_dic;
	}
}

JsonDic<JDNSkillEffectSpe> _m_NSkillEffectSpe_dic;
public void NSkillEffectSpe_Pre()
{
	if(_m_NSkillEffectSpe_dic==null)
	{
		if(m_NSkillEffectSpe_dic.Count>0)return;
	}
}

public List<JDNSkillEffectSpe> m_NSkillEffectSpe_list
{
	get
	{
		return m_NSkillEffectSpe_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectSpe> m_NSkillEffectSpe_dic
{
	get
	{
		if(_m_NSkillEffectSpe_dic==null)
		{
			string _data=LoadFile("NSkillEffectSpe",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectSpe_dic=new JsonDic<JDNSkillEffectSpe>(_data);
		}
		return _m_NSkillEffectSpe_dic;
	}
}

JsonDic<JDNSkillEffectTs> _m_NSkillEffectTs_dic;
public void NSkillEffectTs_Pre()
{
	if(_m_NSkillEffectTs_dic==null)
	{
		if(m_NSkillEffectTs_dic.Count>0)return;
	}
}

public List<JDNSkillEffectTs> m_NSkillEffectTs_list
{
	get
	{
		return m_NSkillEffectTs_dic.DataList;
	}
}

public JsonDic<JDNSkillEffectTs> m_NSkillEffectTs_dic
{
	get
	{
		if(_m_NSkillEffectTs_dic==null)
		{
			string _data=LoadFile("NSkillEffectTs",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillEffectTs_dic=new JsonDic<JDNSkillEffectTs>(_data);
		}
		return _m_NSkillEffectTs_dic;
	}
}

JsonDic<JDNSkillFw> _m_NSkillFw_dic;
public void NSkillFw_Pre()
{
	if(_m_NSkillFw_dic==null)
	{
		if(m_NSkillFw_dic.Count>0)return;
	}
}

public List<JDNSkillFw> m_NSkillFw_list
{
	get
	{
		return m_NSkillFw_dic.DataList;
	}
}

public JsonDic<JDNSkillFw> m_NSkillFw_dic
{
	get
	{
		if(_m_NSkillFw_dic==null)
		{
			string _data=LoadFile("NSkillFw",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillFw_dic=new JsonDic<JDNSkillFw>(_data);
		}
		return _m_NSkillFw_dic;
	}
}

JsonDic<JDNSkillLv> _m_NSkillLv_dic;
public void NSkillLv_Pre()
{
	if(_m_NSkillLv_dic==null)
	{
		if(m_NSkillLv_dic.Count>0)return;
	}
}

public List<JDNSkillLv> m_NSkillLv_list
{
	get
	{
		return m_NSkillLv_dic.DataList;
	}
}

public JsonDic<JDNSkillLv> m_NSkillLv_dic
{
	get
	{
		if(_m_NSkillLv_dic==null)
		{
			string _data=LoadFile("NSkillLv",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillLv_dic=new JsonDic<JDNSkillLv>(_data);
		}
		return _m_NSkillLv_dic;
	}
}

JsonDic<JDNSkillPos> _m_NSkillPos_dic;
public void NSkillPos_Pre()
{
	if(_m_NSkillPos_dic==null)
	{
		if(m_NSkillPos_dic.Count>0)return;
	}
}

public List<JDNSkillPos> m_NSkillPos_list
{
	get
	{
		return m_NSkillPos_dic.DataList;
	}
}

public JsonDic<JDNSkillPos> m_NSkillPos_dic
{
	get
	{
		if(_m_NSkillPos_dic==null)
		{
			string _data=LoadFile("NSkillPos",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NSkillPos_dic=new JsonDic<JDNSkillPos>(_data);
		}
		return _m_NSkillPos_dic;
	}
}

JsonDic<JDNTalent> _m_NTalent_dic;
public void NTalent_Pre()
{
	if(_m_NTalent_dic==null)
	{
		if(m_NTalent_dic.Count>0)return;
	}
}

public List<JDNTalent> m_NTalent_list
{
	get
	{
		return m_NTalent_dic.DataList;
	}
}

public JsonDic<JDNTalent> m_NTalent_dic
{
	get
	{
		if(_m_NTalent_dic==null)
		{
			string _data=LoadFile("NTalent",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NTalent_dic=new JsonDic<JDNTalent>(_data);
		}
		return _m_NTalent_dic;
	}
}

JsonDic<JDNTalentPos> _m_NTalentPos_dic;
public void NTalentPos_Pre()
{
	if(_m_NTalentPos_dic==null)
	{
		if(m_NTalentPos_dic.Count>0)return;
	}
}

public List<JDNTalentPos> m_NTalentPos_list
{
	get
	{
		return m_NTalentPos_dic.DataList;
	}
}

public JsonDic<JDNTalentPos> m_NTalentPos_dic
{
	get
	{
		if(_m_NTalentPos_dic==null)
		{
			string _data=LoadFile("NTalentPos",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NTalentPos_dic=new JsonDic<JDNTalentPos>(_data);
		}
		return _m_NTalentPos_dic;
	}
}

JsonDic<JDNTitle> _m_NTitle_dic;
public void NTitle_Pre()
{
	if(_m_NTitle_dic==null)
	{
		if(m_NTitle_dic.Count>0)return;
	}
}

public List<JDNTitle> m_NTitle_list
{
	get
	{
		return m_NTitle_dic.DataList;
	}
}

public JsonDic<JDNTitle> m_NTitle_dic
{
	get
	{
		if(_m_NTitle_dic==null)
		{
			string _data=LoadFile("NTitle",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NTitle_dic=new JsonDic<JDNTitle>(_data);
		}
		return _m_NTitle_dic;
	}
}

JsonDic<JDNTitleAttr> _m_NTitleAttr_dic;
public void NTitleAttr_Pre()
{
	if(_m_NTitleAttr_dic==null)
	{
		if(m_NTitleAttr_dic.Count>0)return;
	}
}

public List<JDNTitleAttr> m_NTitleAttr_list
{
	get
	{
		return m_NTitleAttr_dic.DataList;
	}
}

public JsonDic<JDNTitleAttr> m_NTitleAttr_dic
{
	get
	{
		if(_m_NTitleAttr_dic==null)
		{
			string _data=LoadFile("NTitleAttr",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_NTitleAttr_dic=new JsonDic<JDNTitleAttr>(_data);
		}
		return _m_NTitleAttr_dic;
	}
}

JsonDic<JDPlatform> _m_Platform_dic;
public void Platform_Pre()
{
	if(_m_Platform_dic==null)
	{
		if(m_Platform_dic.Count>0)return;
	}
}

public List<JDPlatform> m_Platform_list
{
	get
	{
		return m_Platform_dic.DataList;
	}
}

public JsonDic<JDPlatform> m_Platform_dic
{
	get
	{
		if(_m_Platform_dic==null)
		{
			string _data=LoadFile("Platform",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_Platform_dic=new JsonDic<JDPlatform>(_data);
		}
		return _m_Platform_dic;
	}
}

JsonDic<JDRaytheonTest> _m_RaytheonTest_dic;
public void RaytheonTest_Pre()
{
	if(_m_RaytheonTest_dic==null)
	{
		if(m_RaytheonTest_dic.Count>0)return;
	}
}

public List<JDRaytheonTest> m_RaytheonTest_list
{
	get
	{
		return m_RaytheonTest_dic.DataList;
	}
}

public JsonDic<JDRaytheonTest> m_RaytheonTest_dic
{
	get
	{
		if(_m_RaytheonTest_dic==null)
		{
			string _data=LoadFile("RaytheonTest",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_RaytheonTest_dic=new JsonDic<JDRaytheonTest>(_data);
		}
		return _m_RaytheonTest_dic;
	}
}

JsonDic<JDRoomType> _m_RoomType_dic;
public void RoomType_Pre()
{
	if(_m_RoomType_dic==null)
	{
		if(m_RoomType_dic.Count>0)return;
	}
}

public List<JDRoomType> m_RoomType_list
{
	get
	{
		return m_RoomType_dic.DataList;
	}
}

public JsonDic<JDRoomType> m_RoomType_dic
{
	get
	{
		if(_m_RoomType_dic==null)
		{
			string _data=LoadFile("RoomType",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_RoomType_dic=new JsonDic<JDRoomType>(_data);
		}
		return _m_RoomType_dic;
	}
}

JsonDic<JDSpinWin> _m_SpinWin_dic;
public void SpinWin_Pre()
{
	if(_m_SpinWin_dic==null)
	{
		if(m_SpinWin_dic.Count>0)return;
	}
}

public List<JDSpinWin> m_SpinWin_list
{
	get
	{
		return m_SpinWin_dic.DataList;
	}
}

public JsonDic<JDSpinWin> m_SpinWin_dic
{
	get
	{
		if(_m_SpinWin_dic==null)
		{
			string _data=LoadFile("SpinWin",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_SpinWin_dic=new JsonDic<JDSpinWin>(_data);
		}
		return _m_SpinWin_dic;
	}
}

JsonDic<JDSpinWinBase> _m_SpinWinBase_dic;
public void SpinWinBase_Pre()
{
	if(_m_SpinWinBase_dic==null)
	{
		if(m_SpinWinBase_dic.Count>0)return;
	}
}

public List<JDSpinWinBase> m_SpinWinBase_list
{
	get
	{
		return m_SpinWinBase_dic.DataList;
	}
}

public JsonDic<JDSpinWinBase> m_SpinWinBase_dic
{
	get
	{
		if(_m_SpinWinBase_dic==null)
		{
			string _data=LoadFile("SpinWinBase",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_SpinWinBase_dic=new JsonDic<JDSpinWinBase>(_data);
		}
		return _m_SpinWinBase_dic;
	}
}

JsonDic<JDSpinWinCost> _m_SpinWinCost_dic;
public void SpinWinCost_Pre()
{
	if(_m_SpinWinCost_dic==null)
	{
		if(m_SpinWinCost_dic.Count>0)return;
	}
}

public List<JDSpinWinCost> m_SpinWinCost_list
{
	get
	{
		return m_SpinWinCost_dic.DataList;
	}
}

public JsonDic<JDSpinWinCost> m_SpinWinCost_dic
{
	get
	{
		if(_m_SpinWinCost_dic==null)
		{
			string _data=LoadFile("SpinWinCost",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_SpinWinCost_dic=new JsonDic<JDSpinWinCost>(_data);
		}
		return _m_SpinWinCost_dic;
	}
}

JsonDic<JDSuitShow> _m_SuitShow_dic;
public void SuitShow_Pre()
{
	if(_m_SuitShow_dic==null)
	{
		if(m_SuitShow_dic.Count>0)return;
	}
}

public List<JDSuitShow> m_SuitShow_list
{
	get
	{
		return m_SuitShow_dic.DataList;
	}
}

public JsonDic<JDSuitShow> m_SuitShow_dic
{
	get
	{
		if(_m_SuitShow_dic==null)
		{
			string _data=LoadFile("SuitShow",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_SuitShow_dic=new JsonDic<JDSuitShow>(_data);
		}
		return _m_SuitShow_dic;
	}
}

JsonDic<JDSysError> _m_SysError_dic;
public void SysError_Pre()
{
	if(_m_SysError_dic==null)
	{
		if(m_SysError_dic.Count>0)return;
	}
}

public List<JDSysError> m_SysError_list
{
	get
	{
		return m_SysError_dic.DataList;
	}
}

public JsonDic<JDSysError> m_SysError_dic
{
	get
	{
		if(_m_SysError_dic==null)
		{
			string _data=LoadFile("SysError",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_SysError_dic=new JsonDic<JDSysError>(_data);
		}
		return _m_SysError_dic;
	}
}

JsonDic<JDSystemOpen> _m_SystemOpen_dic;
public void SystemOpen_Pre()
{
	if(_m_SystemOpen_dic==null)
	{
		if(m_SystemOpen_dic.Count>0)return;
	}
}

public List<JDSystemOpen> m_SystemOpen_list
{
	get
	{
		return m_SystemOpen_dic.DataList;
	}
}

public JsonDic<JDSystemOpen> m_SystemOpen_dic
{
	get
	{
		if(_m_SystemOpen_dic==null)
		{
			string _data=LoadFile("SystemOpen",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_SystemOpen_dic=new JsonDic<JDSystemOpen>(_data);
		}
		return _m_SystemOpen_dic;
	}
}

JsonDic<JDSystemOpenmsg> _m_SystemOpenmsg_dic;
public void SystemOpenmsg_Pre()
{
	if(_m_SystemOpenmsg_dic==null)
	{
		if(m_SystemOpenmsg_dic.Count>0)return;
	}
}

public List<JDSystemOpenmsg> m_SystemOpenmsg_list
{
	get
	{
		return m_SystemOpenmsg_dic.DataList;
	}
}

public JsonDic<JDSystemOpenmsg> m_SystemOpenmsg_dic
{
	get
	{
		if(_m_SystemOpenmsg_dic==null)
		{
			string _data=LoadFile("SystemOpenmsg",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_SystemOpenmsg_dic=new JsonDic<JDSystemOpenmsg>(_data);
		}
		return _m_SystemOpenmsg_dic;
	}
}

JsonDic<JDTipsLoading> _m_TipsLoading_dic;
public void TipsLoading_Pre()
{
	if(_m_TipsLoading_dic==null)
	{
		if(m_TipsLoading_dic.Count>0)return;
	}
}

public List<JDTipsLoading> m_TipsLoading_list
{
	get
	{
		return m_TipsLoading_dic.DataList;
	}
}

public JsonDic<JDTipsLoading> m_TipsLoading_dic
{
	get
	{
		if(_m_TipsLoading_dic==null)
		{
			string _data=LoadFile("TipsLoading",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_TipsLoading_dic=new JsonDic<JDTipsLoading>(_data);
		}
		return _m_TipsLoading_dic;
	}
}

JsonDic<JDUnderRobot> _m_UnderRobot_dic;
public void UnderRobot_Pre()
{
	if(_m_UnderRobot_dic==null)
	{
		if(m_UnderRobot_dic.Count>0)return;
	}
}

public List<JDUnderRobot> m_UnderRobot_list
{
	get
	{
		return m_UnderRobot_dic.DataList;
	}
}

public JsonDic<JDUnderRobot> m_UnderRobot_dic
{
	get
	{
		if(_m_UnderRobot_dic==null)
		{
			string _data=LoadFile("UnderRobot",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_UnderRobot_dic=new JsonDic<JDUnderRobot>(_data);
		}
		return _m_UnderRobot_dic;
	}
}

JsonDic<JDUnionPoint> _m_UnionPoint_dic;
public void UnionPoint_Pre()
{
	if(_m_UnionPoint_dic==null)
	{
		if(m_UnionPoint_dic.Count>0)return;
	}
}

public List<JDUnionPoint> m_UnionPoint_list
{
	get
	{
		return m_UnionPoint_dic.DataList;
	}
}

public JsonDic<JDUnionPoint> m_UnionPoint_dic
{
	get
	{
		if(_m_UnionPoint_dic==null)
		{
			string _data=LoadFile("UnionPoint",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_UnionPoint_dic=new JsonDic<JDUnionPoint>(_data);
		}
		return _m_UnionPoint_dic;
	}
}

JsonDic<JDUnionPointAtt> _m_UnionPointAtt_dic;
public void UnionPointAtt_Pre()
{
	if(_m_UnionPointAtt_dic==null)
	{
		if(m_UnionPointAtt_dic.Count>0)return;
	}
}

public List<JDUnionPointAtt> m_UnionPointAtt_list
{
	get
	{
		return m_UnionPointAtt_dic.DataList;
	}
}

public JsonDic<JDUnionPointAtt> m_UnionPointAtt_dic
{
	get
	{
		if(_m_UnionPointAtt_dic==null)
		{
			string _data=LoadFile("UnionPointAtt",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_UnionPointAtt_dic=new JsonDic<JDUnionPointAtt>(_data);
		}
		return _m_UnionPointAtt_dic;
	}
}

JsonDic<JDUnionPointAward> _m_UnionPointAward_dic;
public void UnionPointAward_Pre()
{
	if(_m_UnionPointAward_dic==null)
	{
		if(m_UnionPointAward_dic.Count>0)return;
	}
}

public List<JDUnionPointAward> m_UnionPointAward_list
{
	get
	{
		return m_UnionPointAward_dic.DataList;
	}
}

public JsonDic<JDUnionPointAward> m_UnionPointAward_dic
{
	get
	{
		if(_m_UnionPointAward_dic==null)
		{
			string _data=LoadFile("UnionPointAward",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_UnionPointAward_dic=new JsonDic<JDUnionPointAward>(_data);
		}
		return _m_UnionPointAward_dic;
	}
}

JsonDic<JDachieveGroup> _m_achieveGroup_dic;
public void achieveGroup_Pre()
{
	if(_m_achieveGroup_dic==null)
	{
		if(m_achieveGroup_dic.Count>0)return;
	}
}

public List<JDachieveGroup> m_achieveGroup_list
{
	get
	{
		return m_achieveGroup_dic.DataList;
	}
}

public JsonDic<JDachieveGroup> m_achieveGroup_dic
{
	get
	{
		if(_m_achieveGroup_dic==null)
		{
			string _data=LoadFile("achieveGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_achieveGroup_dic=new JsonDic<JDachieveGroup>(_data);
		}
		return _m_achieveGroup_dic;
	}
}

JsonDic<JDachieveTask> _m_achieveTask_dic;
public void achieveTask_Pre()
{
	if(_m_achieveTask_dic==null)
	{
		if(m_achieveTask_dic.Count>0)return;
	}
}

public List<JDachieveTask> m_achieveTask_list
{
	get
	{
		return m_achieveTask_dic.DataList;
	}
}

public JsonDic<JDachieveTask> m_achieveTask_dic
{
	get
	{
		if(_m_achieveTask_dic==null)
		{
			string _data=LoadFile("achieveTask",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_achieveTask_dic=new JsonDic<JDachieveTask>(_data);
		}
		return _m_achieveTask_dic;
	}
}

JsonDic<JDachieveType> _m_achieveType_dic;
public void achieveType_Pre()
{
	if(_m_achieveType_dic==null)
	{
		if(m_achieveType_dic.Count>0)return;
	}
}

public List<JDachieveType> m_achieveType_list
{
	get
	{
		return m_achieveType_dic.DataList;
	}
}

public JsonDic<JDachieveType> m_achieveType_dic
{
	get
	{
		if(_m_achieveType_dic==null)
		{
			string _data=LoadFile("achieveType",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_achieveType_dic=new JsonDic<JDachieveType>(_data);
		}
		return _m_achieveType_dic;
	}
}

JsonDic<JDactive_payDayAward> _m_active_payDayAward_dic;
public void active_payDayAward_Pre()
{
	if(_m_active_payDayAward_dic==null)
	{
		if(m_active_payDayAward_dic.Count>0)return;
	}
}

public List<JDactive_payDayAward> m_active_payDayAward_list
{
	get
	{
		return m_active_payDayAward_dic.DataList;
	}
}

public JsonDic<JDactive_payDayAward> m_active_payDayAward_dic
{
	get
	{
		if(_m_active_payDayAward_dic==null)
		{
			string _data=LoadFile("active_payDayAward",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_active_payDayAward_dic=new JsonDic<JDactive_payDayAward>(_data);
		}
		return _m_active_payDayAward_dic;
	}
}

JsonDic<JDactive_payDayAward_items> _m_active_payDayAward_items_dic;
public void active_payDayAward_items_Pre()
{
	if(_m_active_payDayAward_items_dic==null)
	{
		if(m_active_payDayAward_items_dic.Count>0)return;
	}
}

public List<JDactive_payDayAward_items> m_active_payDayAward_items_list
{
	get
	{
		return m_active_payDayAward_items_dic.DataList;
	}
}

public JsonDic<JDactive_payDayAward_items> m_active_payDayAward_items_dic
{
	get
	{
		if(_m_active_payDayAward_items_dic==null)
		{
			string _data=LoadFile("active_payDayAward_items",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_active_payDayAward_items_dic=new JsonDic<JDactive_payDayAward_items>(_data);
		}
		return _m_active_payDayAward_items_dic;
	}
}

JsonDic<JDactive_vipDayAward> _m_active_vipDayAward_dic;
public void active_vipDayAward_Pre()
{
	if(_m_active_vipDayAward_dic==null)
	{
		if(m_active_vipDayAward_dic.Count>0)return;
	}
}

public List<JDactive_vipDayAward> m_active_vipDayAward_list
{
	get
	{
		return m_active_vipDayAward_dic.DataList;
	}
}

public JsonDic<JDactive_vipDayAward> m_active_vipDayAward_dic
{
	get
	{
		if(_m_active_vipDayAward_dic==null)
		{
			string _data=LoadFile("active_vipDayAward",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_active_vipDayAward_dic=new JsonDic<JDactive_vipDayAward>(_data);
		}
		return _m_active_vipDayAward_dic;
	}
}

JsonDic<JDani> _m_ani_dic;
public void ani_Pre()
{
	if(_m_ani_dic==null)
	{
		if(m_ani_dic.Count>0)return;
	}
}

public List<JDani> m_ani_list
{
	get
	{
		return m_ani_dic.DataList;
	}
}

public JsonDic<JDani> m_ani_dic
{
	get
	{
		if(_m_ani_dic==null)
		{
			string _data=LoadFile("ani",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_ani_dic=new JsonDic<JDani>(_data);
		}
		return _m_ani_dic;
	}
}

JsonDic<JDarenaBase> _m_arenaBase_dic;
public void arenaBase_Pre()
{
	if(_m_arenaBase_dic==null)
	{
		if(m_arenaBase_dic.Count>0)return;
	}
}

public List<JDarenaBase> m_arenaBase_list
{
	get
	{
		return m_arenaBase_dic.DataList;
	}
}

public JsonDic<JDarenaBase> m_arenaBase_dic
{
	get
	{
		if(_m_arenaBase_dic==null)
		{
			string _data=LoadFile("arenaBase",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_arenaBase_dic=new JsonDic<JDarenaBase>(_data);
		}
		return _m_arenaBase_dic;
	}
}

JsonDic<JDarenaBase1> _m_arenaBase1_dic;
public void arenaBase1_Pre()
{
	if(_m_arenaBase1_dic==null)
	{
		if(m_arenaBase1_dic.Count>0)return;
	}
}

public List<JDarenaBase1> m_arenaBase1_list
{
	get
	{
		return m_arenaBase1_dic.DataList;
	}
}

public JsonDic<JDarenaBase1> m_arenaBase1_dic
{
	get
	{
		if(_m_arenaBase1_dic==null)
		{
			string _data=LoadFile("arenaBase1",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_arenaBase1_dic=new JsonDic<JDarenaBase1>(_data);
		}
		return _m_arenaBase1_dic;
	}
}

JsonDic<JDarenaRank> _m_arenaRank_dic;
public void arenaRank_Pre()
{
	if(_m_arenaRank_dic==null)
	{
		if(m_arenaRank_dic.Count>0)return;
	}
}

public List<JDarenaRank> m_arenaRank_list
{
	get
	{
		return m_arenaRank_dic.DataList;
	}
}

public JsonDic<JDarenaRank> m_arenaRank_dic
{
	get
	{
		if(_m_arenaRank_dic==null)
		{
			string _data=LoadFile("arenaRank",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_arenaRank_dic=new JsonDic<JDarenaRank>(_data);
		}
		return _m_arenaRank_dic;
	}
}

JsonDic<JDarenaRobot> _m_arenaRobot_dic;
public void arenaRobot_Pre()
{
	if(_m_arenaRobot_dic==null)
	{
		if(m_arenaRobot_dic.Count>0)return;
	}
}

public List<JDarenaRobot> m_arenaRobot_list
{
	get
	{
		return m_arenaRobot_dic.DataList;
	}
}

public JsonDic<JDarenaRobot> m_arenaRobot_dic
{
	get
	{
		if(_m_arenaRobot_dic==null)
		{
			string _data=LoadFile("arenaRobot",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_arenaRobot_dic=new JsonDic<JDarenaRobot>(_data);
		}
		return _m_arenaRobot_dic;
	}
}

JsonDic<JDarenaSeason> _m_arenaSeason_dic;
public void arenaSeason_Pre()
{
	if(_m_arenaSeason_dic==null)
	{
		if(m_arenaSeason_dic.Count>0)return;
	}
}

public List<JDarenaSeason> m_arenaSeason_list
{
	get
	{
		return m_arenaSeason_dic.DataList;
	}
}

public JsonDic<JDarenaSeason> m_arenaSeason_dic
{
	get
	{
		if(_m_arenaSeason_dic==null)
		{
			string _data=LoadFile("arenaSeason",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_arenaSeason_dic=new JsonDic<JDarenaSeason>(_data);
		}
		return _m_arenaSeason_dic;
	}
}

JsonDic<JDarenaWAward> _m_arenaWAward_dic;
public void arenaWAward_Pre()
{
	if(_m_arenaWAward_dic==null)
	{
		if(m_arenaWAward_dic.Count>0)return;
	}
}

public List<JDarenaWAward> m_arenaWAward_list
{
	get
	{
		return m_arenaWAward_dic.DataList;
	}
}

public JsonDic<JDarenaWAward> m_arenaWAward_dic
{
	get
	{
		if(_m_arenaWAward_dic==null)
		{
			string _data=LoadFile("arenaWAward",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_arenaWAward_dic=new JsonDic<JDarenaWAward>(_data);
		}
		return _m_arenaWAward_dic;
	}
}

JsonDic<JDarmorPart> _m_armorPart_dic;
public void armorPart_Pre()
{
	if(_m_armorPart_dic==null)
	{
		if(m_armorPart_dic.Count>0)return;
	}
}

public List<JDarmorPart> m_armorPart_list
{
	get
	{
		return m_armorPart_dic.DataList;
	}
}

public JsonDic<JDarmorPart> m_armorPart_dic
{
	get
	{
		if(_m_armorPart_dic==null)
		{
			string _data=LoadFile("armorPart",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_armorPart_dic=new JsonDic<JDarmorPart>(_data);
		}
		return _m_armorPart_dic;
	}
}

JsonDic<JDarmorType> _m_armorType_dic;
public void armorType_Pre()
{
	if(_m_armorType_dic==null)
	{
		if(m_armorType_dic.Count>0)return;
	}
}

public List<JDarmorType> m_armorType_list
{
	get
	{
		return m_armorType_dic.DataList;
	}
}

public JsonDic<JDarmorType> m_armorType_dic
{
	get
	{
		if(_m_armorType_dic==null)
		{
			string _data=LoadFile("armorType",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_armorType_dic=new JsonDic<JDarmorType>(_data);
		}
		return _m_armorType_dic;
	}
}

JsonDic<JDattrGroup> _m_attrGroup_dic;
public void attrGroup_Pre()
{
	if(_m_attrGroup_dic==null)
	{
		if(m_attrGroup_dic.Count>0)return;
	}
}

public List<JDattrGroup> m_attrGroup_list
{
	get
	{
		return m_attrGroup_dic.DataList;
	}
}

public JsonDic<JDattrGroup> m_attrGroup_dic
{
	get
	{
		if(_m_attrGroup_dic==null)
		{
			string _data=LoadFile("attrGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_attrGroup_dic=new JsonDic<JDattrGroup>(_data);
		}
		return _m_attrGroup_dic;
	}
}

JsonDic<JDattrSet> _m_attrSet_dic;
public void attrSet_Pre()
{
	if(_m_attrSet_dic==null)
	{
		if(m_attrSet_dic.Count>0)return;
	}
}

public List<JDattrSet> m_attrSet_list
{
	get
	{
		return m_attrSet_dic.DataList;
	}
}

public JsonDic<JDattrSet> m_attrSet_dic
{
	get
	{
		if(_m_attrSet_dic==null)
		{
			string _data=LoadFile("attrSet",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_attrSet_dic=new JsonDic<JDattrSet>(_data);
		}
		return _m_attrSet_dic;
	}
}

JsonDic<JDautoNamePlayer> _m_autoNamePlayer_dic;
public void autoNamePlayer_Pre()
{
	if(_m_autoNamePlayer_dic==null)
	{
		if(m_autoNamePlayer_dic.Count>0)return;
	}
}

public List<JDautoNamePlayer> m_autoNamePlayer_list
{
	get
	{
		return m_autoNamePlayer_dic.DataList;
	}
}

public JsonDic<JDautoNamePlayer> m_autoNamePlayer_dic
{
	get
	{
		if(_m_autoNamePlayer_dic==null)
		{
			string _data=LoadFile("autoNamePlayer",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_autoNamePlayer_dic=new JsonDic<JDautoNamePlayer>(_data);
		}
		return _m_autoNamePlayer_dic;
	}
}

JsonDic<JDautoNameTeam> _m_autoNameTeam_dic;
public void autoNameTeam_Pre()
{
	if(_m_autoNameTeam_dic==null)
	{
		if(m_autoNameTeam_dic.Count>0)return;
	}
}

public List<JDautoNameTeam> m_autoNameTeam_list
{
	get
	{
		return m_autoNameTeam_dic.DataList;
	}
}

public JsonDic<JDautoNameTeam> m_autoNameTeam_dic
{
	get
	{
		if(_m_autoNameTeam_dic==null)
		{
			string _data=LoadFile("autoNameTeam",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_autoNameTeam_dic=new JsonDic<JDautoNameTeam>(_data);
		}
		return _m_autoNameTeam_dic;
	}
}

JsonDic<JDbase> _m_base_dic;
public void base_Pre()
{
	if(_m_base_dic==null)
	{
		if(m_base_dic.Count>0)return;
	}
}

public List<JDbase> m_base_list
{
	get
	{
		return m_base_dic.DataList;
	}
}

public JsonDic<JDbase> m_base_dic
{
	get
	{
		if(_m_base_dic==null)
		{
			string _data=LoadFile("base",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_base_dic=new JsonDic<JDbase>(_data);
		}
		return _m_base_dic;
	}
}

JsonDic<JDbattleBase> _m_battleBase_dic;
public void battleBase_Pre()
{
	if(_m_battleBase_dic==null)
	{
		if(m_battleBase_dic.Count>0)return;
	}
}

public List<JDbattleBase> m_battleBase_list
{
	get
	{
		return m_battleBase_dic.DataList;
	}
}

public JsonDic<JDbattleBase> m_battleBase_dic
{
	get
	{
		if(_m_battleBase_dic==null)
		{
			string _data=LoadFile("battleBase",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_battleBase_dic=new JsonDic<JDbattleBase>(_data);
		}
		return _m_battleBase_dic;
	}
}

JsonDic<JDbattleMap> _m_battleMap_dic;
public void battleMap_Pre()
{
	if(_m_battleMap_dic==null)
	{
		if(m_battleMap_dic.Count>0)return;
	}
}

public List<JDbattleMap> m_battleMap_list
{
	get
	{
		return m_battleMap_dic.DataList;
	}
}

public JsonDic<JDbattleMap> m_battleMap_dic
{
	get
	{
		if(_m_battleMap_dic==null)
		{
			string _data=LoadFile("battleMap",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_battleMap_dic=new JsonDic<JDbattleMap>(_data);
		}
		return _m_battleMap_dic;
	}
}

JsonDic<JDbattleMatch> _m_battleMatch_dic;
public void battleMatch_Pre()
{
	if(_m_battleMatch_dic==null)
	{
		if(m_battleMatch_dic.Count>0)return;
	}
}

public List<JDbattleMatch> m_battleMatch_list
{
	get
	{
		return m_battleMatch_dic.DataList;
	}
}

public JsonDic<JDbattleMatch> m_battleMatch_dic
{
	get
	{
		if(_m_battleMatch_dic==null)
		{
			string _data=LoadFile("battleMatch",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_battleMatch_dic=new JsonDic<JDbattleMatch>(_data);
		}
		return _m_battleMatch_dic;
	}
}

JsonDic<JDbossExtra> _m_bossExtra_dic;
public void bossExtra_Pre()
{
	if(_m_bossExtra_dic==null)
	{
		if(m_bossExtra_dic.Count>0)return;
	}
}

public List<JDbossExtra> m_bossExtra_list
{
	get
	{
		return m_bossExtra_dic.DataList;
	}
}

public JsonDic<JDbossExtra> m_bossExtra_dic
{
	get
	{
		if(_m_bossExtra_dic==null)
		{
			string _data=LoadFile("bossExtra",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_bossExtra_dic=new JsonDic<JDbossExtra>(_data);
		}
		return _m_bossExtra_dic;
	}
}

JsonDic<JDbossLoot> _m_bossLoot_dic;
public void bossLoot_Pre()
{
	if(_m_bossLoot_dic==null)
	{
		if(m_bossLoot_dic.Count>0)return;
	}
}

public List<JDbossLoot> m_bossLoot_list
{
	get
	{
		return m_bossLoot_dic.DataList;
	}
}

public JsonDic<JDbossLoot> m_bossLoot_dic
{
	get
	{
		if(_m_bossLoot_dic==null)
		{
			string _data=LoadFile("bossLoot",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_bossLoot_dic=new JsonDic<JDbossLoot>(_data);
		}
		return _m_bossLoot_dic;
	}
}

JsonDic<JDbossMap> _m_bossMap_dic;
public void bossMap_Pre()
{
	if(_m_bossMap_dic==null)
	{
		if(m_bossMap_dic.Count>0)return;
	}
}

public List<JDbossMap> m_bossMap_list
{
	get
	{
		return m_bossMap_dic.DataList;
	}
}

public JsonDic<JDbossMap> m_bossMap_dic
{
	get
	{
		if(_m_bossMap_dic==null)
		{
			string _data=LoadFile("bossMap",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_bossMap_dic=new JsonDic<JDbossMap>(_data);
		}
		return _m_bossMap_dic;
	}
}

JsonDic<JDbossRankAward> _m_bossRankAward_dic;
public void bossRankAward_Pre()
{
	if(_m_bossRankAward_dic==null)
	{
		if(m_bossRankAward_dic.Count>0)return;
	}
}

public List<JDbossRankAward> m_bossRankAward_list
{
	get
	{
		return m_bossRankAward_dic.DataList;
	}
}

public JsonDic<JDbossRankAward> m_bossRankAward_dic
{
	get
	{
		if(_m_bossRankAward_dic==null)
		{
			string _data=LoadFile("bossRankAward",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_bossRankAward_dic=new JsonDic<JDbossRankAward>(_data);
		}
		return _m_bossRankAward_dic;
	}
}

JsonDic<JDcarnival> _m_carnival_dic;
public void carnival_Pre()
{
	if(_m_carnival_dic==null)
	{
		if(m_carnival_dic.Count>0)return;
	}
}

public List<JDcarnival> m_carnival_list
{
	get
	{
		return m_carnival_dic.DataList;
	}
}

public JsonDic<JDcarnival> m_carnival_dic
{
	get
	{
		if(_m_carnival_dic==null)
		{
			string _data=LoadFile("carnival",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_carnival_dic=new JsonDic<JDcarnival>(_data);
		}
		return _m_carnival_dic;
	}
}

JsonDic<JDcarnivalStep> _m_carnivalStep_dic;
public void carnivalStep_Pre()
{
	if(_m_carnivalStep_dic==null)
	{
		if(m_carnivalStep_dic.Count>0)return;
	}
}

public List<JDcarnivalStep> m_carnivalStep_list
{
	get
	{
		return m_carnivalStep_dic.DataList;
	}
}

public JsonDic<JDcarnivalStep> m_carnivalStep_dic
{
	get
	{
		if(_m_carnivalStep_dic==null)
		{
			string _data=LoadFile("carnivalStep",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_carnivalStep_dic=new JsonDic<JDcarnivalStep>(_data);
		}
		return _m_carnivalStep_dic;
	}
}

JsonDic<JDcarnivalTask> _m_carnivalTask_dic;
public void carnivalTask_Pre()
{
	if(_m_carnivalTask_dic==null)
	{
		if(m_carnivalTask_dic.Count>0)return;
	}
}

public List<JDcarnivalTask> m_carnivalTask_list
{
	get
	{
		return m_carnivalTask_dic.DataList;
	}
}

public JsonDic<JDcarnivalTask> m_carnivalTask_dic
{
	get
	{
		if(_m_carnivalTask_dic==null)
		{
			string _data=LoadFile("carnivalTask",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_carnivalTask_dic=new JsonDic<JDcarnivalTask>(_data);
		}
		return _m_carnivalTask_dic;
	}
}

JsonDic<JDclub> _m_club_dic;
public void club_Pre()
{
	if(_m_club_dic==null)
	{
		if(m_club_dic.Count>0)return;
	}
}

public List<JDclub> m_club_list
{
	get
	{
		return m_club_dic.DataList;
	}
}

public JsonDic<JDclub> m_club_dic
{
	get
	{
		if(_m_club_dic==null)
		{
			string _data=LoadFile("club",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_club_dic=new JsonDic<JDclub>(_data);
		}
		return _m_club_dic;
	}
}

JsonDic<JDclubBase1> _m_clubBase1_dic;
public void clubBase1_Pre()
{
	if(_m_clubBase1_dic==null)
	{
		if(m_clubBase1_dic.Count>0)return;
	}
}

public List<JDclubBase1> m_clubBase1_list
{
	get
	{
		return m_clubBase1_dic.DataList;
	}
}

public JsonDic<JDclubBase1> m_clubBase1_dic
{
	get
	{
		if(_m_clubBase1_dic==null)
		{
			string _data=LoadFile("clubBase1",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_clubBase1_dic=new JsonDic<JDclubBase1>(_data);
		}
		return _m_clubBase1_dic;
	}
}

JsonDic<JDclubDuty> _m_clubDuty_dic;
public void clubDuty_Pre()
{
	if(_m_clubDuty_dic==null)
	{
		if(m_clubDuty_dic.Count>0)return;
	}
}

public List<JDclubDuty> m_clubDuty_list
{
	get
	{
		return m_clubDuty_dic.DataList;
	}
}

public JsonDic<JDclubDuty> m_clubDuty_dic
{
	get
	{
		if(_m_clubDuty_dic==null)
		{
			string _data=LoadFile("clubDuty",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_clubDuty_dic=new JsonDic<JDclubDuty>(_data);
		}
		return _m_clubDuty_dic;
	}
}

JsonDic<JDclubPray> _m_clubPray_dic;
public void clubPray_Pre()
{
	if(_m_clubPray_dic==null)
	{
		if(m_clubPray_dic.Count>0)return;
	}
}

public List<JDclubPray> m_clubPray_list
{
	get
	{
		return m_clubPray_dic.DataList;
	}
}

public JsonDic<JDclubPray> m_clubPray_dic
{
	get
	{
		if(_m_clubPray_dic==null)
		{
			string _data=LoadFile("clubPray",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_clubPray_dic=new JsonDic<JDclubPray>(_data);
		}
		return _m_clubPray_dic;
	}
}

JsonDic<JDclubRaidAuction> _m_clubRaidAuction_dic;
public void clubRaidAuction_Pre()
{
	if(_m_clubRaidAuction_dic==null)
	{
		if(m_clubRaidAuction_dic.Count>0)return;
	}
}

public List<JDclubRaidAuction> m_clubRaidAuction_list
{
	get
	{
		return m_clubRaidAuction_dic.DataList;
	}
}

public JsonDic<JDclubRaidAuction> m_clubRaidAuction_dic
{
	get
	{
		if(_m_clubRaidAuction_dic==null)
		{
			string _data=LoadFile("clubRaidAuction",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_clubRaidAuction_dic=new JsonDic<JDclubRaidAuction>(_data);
		}
		return _m_clubRaidAuction_dic;
	}
}

JsonDic<JDclubRaidChapter> _m_clubRaidChapter_dic;
public void clubRaidChapter_Pre()
{
	if(_m_clubRaidChapter_dic==null)
	{
		if(m_clubRaidChapter_dic.Count>0)return;
	}
}

public List<JDclubRaidChapter> m_clubRaidChapter_list
{
	get
	{
		return m_clubRaidChapter_dic.DataList;
	}
}

public JsonDic<JDclubRaidChapter> m_clubRaidChapter_dic
{
	get
	{
		if(_m_clubRaidChapter_dic==null)
		{
			string _data=LoadFile("clubRaidChapter",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_clubRaidChapter_dic=new JsonDic<JDclubRaidChapter>(_data);
		}
		return _m_clubRaidChapter_dic;
	}
}

JsonDic<JDclubRaidStage> _m_clubRaidStage_dic;
public void clubRaidStage_Pre()
{
	if(_m_clubRaidStage_dic==null)
	{
		if(m_clubRaidStage_dic.Count>0)return;
	}
}

public List<JDclubRaidStage> m_clubRaidStage_list
{
	get
	{
		return m_clubRaidStage_dic.DataList;
	}
}

public JsonDic<JDclubRaidStage> m_clubRaidStage_dic
{
	get
	{
		if(_m_clubRaidStage_dic==null)
		{
			string _data=LoadFile("clubRaidStage",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_clubRaidStage_dic=new JsonDic<JDclubRaidStage>(_data);
		}
		return _m_clubRaidStage_dic;
	}
}

JsonDic<JDclubTask> _m_clubTask_dic;
public void clubTask_Pre()
{
	if(_m_clubTask_dic==null)
	{
		if(m_clubTask_dic.Count>0)return;
	}
}

public List<JDclubTask> m_clubTask_list
{
	get
	{
		return m_clubTask_dic.DataList;
	}
}

public JsonDic<JDclubTask> m_clubTask_dic
{
	get
	{
		if(_m_clubTask_dic==null)
		{
			string _data=LoadFile("clubTask",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_clubTask_dic=new JsonDic<JDclubTask>(_data);
		}
		return _m_clubTask_dic;
	}
}

JsonDic<JDclubTaskReward> _m_clubTaskReward_dic;
public void clubTaskReward_Pre()
{
	if(_m_clubTaskReward_dic==null)
	{
		if(m_clubTaskReward_dic.Count>0)return;
	}
}

public List<JDclubTaskReward> m_clubTaskReward_list
{
	get
	{
		return m_clubTaskReward_dic.DataList;
	}
}

public JsonDic<JDclubTaskReward> m_clubTaskReward_dic
{
	get
	{
		if(_m_clubTaskReward_dic==null)
		{
			string _data=LoadFile("clubTaskReward",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_clubTaskReward_dic=new JsonDic<JDclubTaskReward>(_data);
		}
		return _m_clubTaskReward_dic;
	}
}

JsonDic<JDcmaps> _m_cmaps_dic;
public void cmaps_Pre()
{
	if(_m_cmaps_dic==null)
	{
		if(m_cmaps_dic.Count>0)return;
	}
}

public List<JDcmaps> m_cmaps_list
{
	get
	{
		return m_cmaps_dic.DataList;
	}
}

public JsonDic<JDcmaps> m_cmaps_dic
{
	get
	{
		if(_m_cmaps_dic==null)
		{
			string _data=LoadFile("cmaps",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_cmaps_dic=new JsonDic<JDcmaps>(_data);
		}
		return _m_cmaps_dic;
	}
}

JsonDic<JDcodepf> _m_codepf_dic;
public void codepf_Pre()
{
	if(_m_codepf_dic==null)
	{
		if(m_codepf_dic.Count>0)return;
	}
}

public List<JDcodepf> m_codepf_list
{
	get
	{
		return m_codepf_dic.DataList;
	}
}

public JsonDic<JDcodepf> m_codepf_dic
{
	get
	{
		if(_m_codepf_dic==null)
		{
			string _data=LoadFile("codepf",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_codepf_dic=new JsonDic<JDcodepf>(_data);
		}
		return _m_codepf_dic;
	}
}

JsonDic<JDconfig> _m_config_dic;
public void config_Pre()
{
	if(_m_config_dic==null)
	{
		if(m_config_dic.Count>0)return;
	}
}

public List<JDconfig> m_config_list
{
	get
	{
		return m_config_dic.DataList;
	}
}

public JsonDic<JDconfig> m_config_dic
{
	get
	{
		if(_m_config_dic==null)
		{
			string _data=LoadFile("config",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_config_dic=new JsonDic<JDconfig>(_data);
		}
		return _m_config_dic;
	}
}

JsonDic<JDdailySign> _m_dailySign_dic;
public void dailySign_Pre()
{
	if(_m_dailySign_dic==null)
	{
		if(m_dailySign_dic.Count>0)return;
	}
}

public List<JDdailySign> m_dailySign_list
{
	get
	{
		return m_dailySign_dic.DataList;
	}
}

public JsonDic<JDdailySign> m_dailySign_dic
{
	get
	{
		if(_m_dailySign_dic==null)
		{
			string _data=LoadFile("dailySign",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_dailySign_dic=new JsonDic<JDdailySign>(_data);
		}
		return _m_dailySign_dic;
	}
}

JsonDic<JDdayTask> _m_dayTask_dic;
public void dayTask_Pre()
{
	if(_m_dayTask_dic==null)
	{
		if(m_dayTask_dic.Count>0)return;
	}
}

public List<JDdayTask> m_dayTask_list
{
	get
	{
		return m_dayTask_dic.DataList;
	}
}

public JsonDic<JDdayTask> m_dayTask_dic
{
	get
	{
		if(_m_dayTask_dic==null)
		{
			string _data=LoadFile("dayTask",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_dayTask_dic=new JsonDic<JDdayTask>(_data);
		}
		return _m_dayTask_dic;
	}
}

JsonDic<JDdayTaskType> _m_dayTaskType_dic;
public void dayTaskType_Pre()
{
	if(_m_dayTaskType_dic==null)
	{
		if(m_dayTaskType_dic.Count>0)return;
	}
}

public List<JDdayTaskType> m_dayTaskType_list
{
	get
	{
		return m_dayTaskType_dic.DataList;
	}
}

public JsonDic<JDdayTaskType> m_dayTaskType_dic
{
	get
	{
		if(_m_dayTaskType_dic==null)
		{
			string _data=LoadFile("dayTaskType",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_dayTaskType_dic=new JsonDic<JDdayTaskType>(_data);
		}
		return _m_dayTaskType_dic;
	}
}

JsonDic<JDdrawBase> _m_drawBase_dic;
public void drawBase_Pre()
{
	if(_m_drawBase_dic==null)
	{
		if(m_drawBase_dic.Count>0)return;
	}
}

public List<JDdrawBase> m_drawBase_list
{
	get
	{
		return m_drawBase_dic.DataList;
	}
}

public JsonDic<JDdrawBase> m_drawBase_dic
{
	get
	{
		if(_m_drawBase_dic==null)
		{
			string _data=LoadFile("drawBase",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_drawBase_dic=new JsonDic<JDdrawBase>(_data);
		}
		return _m_drawBase_dic;
	}
}

JsonDic<JDdrawEffect> _m_drawEffect_dic;
public void drawEffect_Pre()
{
	if(_m_drawEffect_dic==null)
	{
		if(m_drawEffect_dic.Count>0)return;
	}
}

public List<JDdrawEffect> m_drawEffect_list
{
	get
	{
		return m_drawEffect_dic.DataList;
	}
}

public JsonDic<JDdrawEffect> m_drawEffect_dic
{
	get
	{
		if(_m_drawEffect_dic==null)
		{
			string _data=LoadFile("drawEffect",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_drawEffect_dic=new JsonDic<JDdrawEffect>(_data);
		}
		return _m_drawEffect_dic;
	}
}

JsonDic<JDdrawGroup> _m_drawGroup_dic;
public void drawGroup_Pre()
{
	if(_m_drawGroup_dic==null)
	{
		if(m_drawGroup_dic.Count>0)return;
	}
}

public List<JDdrawGroup> m_drawGroup_list
{
	get
	{
		return m_drawGroup_dic.DataList;
	}
}

public JsonDic<JDdrawGroup> m_drawGroup_dic
{
	get
	{
		if(_m_drawGroup_dic==null)
		{
			string _data=LoadFile("drawGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_drawGroup_dic=new JsonDic<JDdrawGroup>(_data);
		}
		return _m_drawGroup_dic;
	}
}

JsonDic<JDenchantBase> _m_enchantBase_dic;
public void enchantBase_Pre()
{
	if(_m_enchantBase_dic==null)
	{
		if(m_enchantBase_dic.Count>0)return;
	}
}

public List<JDenchantBase> m_enchantBase_list
{
	get
	{
		return m_enchantBase_dic.DataList;
	}
}

public JsonDic<JDenchantBase> m_enchantBase_dic
{
	get
	{
		if(_m_enchantBase_dic==null)
		{
			string _data=LoadFile("enchantBase",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_enchantBase_dic=new JsonDic<JDenchantBase>(_data);
		}
		return _m_enchantBase_dic;
	}
}

JsonDic<JDenchantLv> _m_enchantLv_dic;
public void enchantLv_Pre()
{
	if(_m_enchantLv_dic==null)
	{
		if(m_enchantLv_dic.Count>0)return;
	}
}

public List<JDenchantLv> m_enchantLv_list
{
	get
	{
		return m_enchantLv_dic.DataList;
	}
}

public JsonDic<JDenchantLv> m_enchantLv_dic
{
	get
	{
		if(_m_enchantLv_dic==null)
		{
			string _data=LoadFile("enchantLv",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_enchantLv_dic=new JsonDic<JDenchantLv>(_data);
		}
		return _m_enchantLv_dic;
	}
}

JsonDic<JDequipAch> _m_equipAch_dic;
public void equipAch_Pre()
{
	if(_m_equipAch_dic==null)
	{
		if(m_equipAch_dic.Count>0)return;
	}
}

public List<JDequipAch> m_equipAch_list
{
	get
	{
		return m_equipAch_dic.DataList;
	}
}

public JsonDic<JDequipAch> m_equipAch_dic
{
	get
	{
		if(_m_equipAch_dic==null)
		{
			string _data=LoadFile("equipAch",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipAch_dic=new JsonDic<JDequipAch>(_data);
		}
		return _m_equipAch_dic;
	}
}

JsonDic<JDequipAdvGroup> _m_equipAdvGroup_dic;
public void equipAdvGroup_Pre()
{
	if(_m_equipAdvGroup_dic==null)
	{
		if(m_equipAdvGroup_dic.Count>0)return;
	}
}

public List<JDequipAdvGroup> m_equipAdvGroup_list
{
	get
	{
		return m_equipAdvGroup_dic.DataList;
	}
}

public JsonDic<JDequipAdvGroup> m_equipAdvGroup_dic
{
	get
	{
		if(_m_equipAdvGroup_dic==null)
		{
			string _data=LoadFile("equipAdvGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipAdvGroup_dic=new JsonDic<JDequipAdvGroup>(_data);
		}
		return _m_equipAdvGroup_dic;
	}
}

JsonDic<JDequipAdvSet> _m_equipAdvSet_dic;
public void equipAdvSet_Pre()
{
	if(_m_equipAdvSet_dic==null)
	{
		if(m_equipAdvSet_dic.Count>0)return;
	}
}

public List<JDequipAdvSet> m_equipAdvSet_list
{
	get
	{
		return m_equipAdvSet_dic.DataList;
	}
}

public JsonDic<JDequipAdvSet> m_equipAdvSet_dic
{
	get
	{
		if(_m_equipAdvSet_dic==null)
		{
			string _data=LoadFile("equipAdvSet",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipAdvSet_dic=new JsonDic<JDequipAdvSet>(_data);
		}
		return _m_equipAdvSet_dic;
	}
}

JsonDic<JDequipGbCost> _m_equipGbCost_dic;
public void equipGbCost_Pre()
{
	if(_m_equipGbCost_dic==null)
	{
		if(m_equipGbCost_dic.Count>0)return;
	}
}

public List<JDequipGbCost> m_equipGbCost_list
{
	get
	{
		return m_equipGbCost_dic.DataList;
	}
}

public JsonDic<JDequipGbCost> m_equipGbCost_dic
{
	get
	{
		if(_m_equipGbCost_dic==null)
		{
			string _data=LoadFile("equipGbCost",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipGbCost_dic=new JsonDic<JDequipGbCost>(_data);
		}
		return _m_equipGbCost_dic;
	}
}

JsonDic<JDequipInherit> _m_equipInherit_dic;
public void equipInherit_Pre()
{
	if(_m_equipInherit_dic==null)
	{
		if(m_equipInherit_dic.Count>0)return;
	}
}

public List<JDequipInherit> m_equipInherit_list
{
	get
	{
		return m_equipInherit_dic.DataList;
	}
}

public JsonDic<JDequipInherit> m_equipInherit_dic
{
	get
	{
		if(_m_equipInherit_dic==null)
		{
			string _data=LoadFile("equipInherit",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipInherit_dic=new JsonDic<JDequipInherit>(_data);
		}
		return _m_equipInherit_dic;
	}
}

JsonDic<JDequipJG> _m_equipJG_dic;
public void equipJG_Pre()
{
	if(_m_equipJG_dic==null)
	{
		if(m_equipJG_dic.Count>0)return;
	}
}

public List<JDequipJG> m_equipJG_list
{
	get
	{
		return m_equipJG_dic.DataList;
	}
}

public JsonDic<JDequipJG> m_equipJG_dic
{
	get
	{
		if(_m_equipJG_dic==null)
		{
			string _data=LoadFile("equipJG",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipJG_dic=new JsonDic<JDequipJG>(_data);
		}
		return _m_equipJG_dic;
	}
}

JsonDic<JDequipList> _m_equipList_dic;
public void equipList_Pre()
{
	if(_m_equipList_dic==null)
	{
		if(m_equipList_dic.Count>0)return;
	}
}

public List<JDequipList> m_equipList_list
{
	get
	{
		return m_equipList_dic.DataList;
	}
}

public JsonDic<JDequipList> m_equipList_dic
{
	get
	{
		if(_m_equipList_dic==null)
		{
			string _data=LoadFile("equipList",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipList_dic=new JsonDic<JDequipList>(_data);
		}
		return _m_equipList_dic;
	}
}

JsonDic<JDequipLv> _m_equipLv_dic;
public void equipLv_Pre()
{
	if(_m_equipLv_dic==null)
	{
		if(m_equipLv_dic.Count>0)return;
	}
}

public List<JDequipLv> m_equipLv_list
{
	get
	{
		return m_equipLv_dic.DataList;
	}
}

public JsonDic<JDequipLv> m_equipLv_dic
{
	get
	{
		if(_m_equipLv_dic==null)
		{
			string _data=LoadFile("equipLv",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipLv_dic=new JsonDic<JDequipLv>(_data);
		}
		return _m_equipLv_dic;
	}
}

JsonDic<JDequipSuit> _m_equipSuit_dic;
public void equipSuit_Pre()
{
	if(_m_equipSuit_dic==null)
	{
		if(m_equipSuit_dic.Count>0)return;
	}
}

public List<JDequipSuit> m_equipSuit_list
{
	get
	{
		return m_equipSuit_dic.DataList;
	}
}

public JsonDic<JDequipSuit> m_equipSuit_dic
{
	get
	{
		if(_m_equipSuit_dic==null)
		{
			string _data=LoadFile("equipSuit",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipSuit_dic=new JsonDic<JDequipSuit>(_data);
		}
		return _m_equipSuit_dic;
	}
}

JsonDic<JDequipType> _m_equipType_dic;
public void equipType_Pre()
{
	if(_m_equipType_dic==null)
	{
		if(m_equipType_dic.Count>0)return;
	}
}

public List<JDequipType> m_equipType_list
{
	get
	{
		return m_equipType_dic.DataList;
	}
}

public JsonDic<JDequipType> m_equipType_dic
{
	get
	{
		if(_m_equipType_dic==null)
		{
			string _data=LoadFile("equipType",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_equipType_dic=new JsonDic<JDequipType>(_data);
		}
		return _m_equipType_dic;
	}
}

JsonDic<JDerrorCode> _m_errorCode_dic;
public void errorCode_Pre()
{
	if(_m_errorCode_dic==null)
	{
		if(m_errorCode_dic.Count>0)return;
	}
}

public List<JDerrorCode> m_errorCode_list
{
	get
	{
		return m_errorCode_dic.DataList;
	}
}

public JsonDic<JDerrorCode> m_errorCode_dic
{
	get
	{
		if(_m_errorCode_dic==null)
		{
			string _data=LoadFile("errorCode",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_errorCode_dic=new JsonDic<JDerrorCode>(_data);
		}
		return _m_errorCode_dic;
	}
}

JsonDic<JDeveBossMaxLoot> _m_eveBossMaxLoot_dic;
public void eveBossMaxLoot_Pre()
{
	if(_m_eveBossMaxLoot_dic==null)
	{
		if(m_eveBossMaxLoot_dic.Count>0)return;
	}
}

public List<JDeveBossMaxLoot> m_eveBossMaxLoot_list
{
	get
	{
		return m_eveBossMaxLoot_dic.DataList;
	}
}

public JsonDic<JDeveBossMaxLoot> m_eveBossMaxLoot_dic
{
	get
	{
		if(_m_eveBossMaxLoot_dic==null)
		{
			string _data=LoadFile("eveBossMaxLoot",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_eveBossMaxLoot_dic=new JsonDic<JDeveBossMaxLoot>(_data);
		}
		return _m_eveBossMaxLoot_dic;
	}
}

JsonDic<JDevent> _m_event_dic;
public void event_Pre()
{
	if(_m_event_dic==null)
	{
		if(m_event_dic.Count>0)return;
	}
}

public List<JDevent> m_event_list
{
	get
	{
		return m_event_dic.DataList;
	}
}

public JsonDic<JDevent> m_event_dic
{
	get
	{
		if(_m_event_dic==null)
		{
			string _data=LoadFile("event",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_event_dic=new JsonDic<JDevent>(_data);
		}
		return _m_event_dic;
	}
}

JsonDic<JDeventFeast> _m_eventFeast_dic;
public void eventFeast_Pre()
{
	if(_m_eventFeast_dic==null)
	{
		if(m_eventFeast_dic.Count>0)return;
	}
}

public List<JDeventFeast> m_eventFeast_list
{
	get
	{
		return m_eventFeast_dic.DataList;
	}
}

public JsonDic<JDeventFeast> m_eventFeast_dic
{
	get
	{
		if(_m_eventFeast_dic==null)
		{
			string _data=LoadFile("eventFeast",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_eventFeast_dic=new JsonDic<JDeventFeast>(_data);
		}
		return _m_eventFeast_dic;
	}
}

JsonDic<JDeventOgre> _m_eventOgre_dic;
public void eventOgre_Pre()
{
	if(_m_eventOgre_dic==null)
	{
		if(m_eventOgre_dic.Count>0)return;
	}
}

public List<JDeventOgre> m_eventOgre_list
{
	get
	{
		return m_eventOgre_dic.DataList;
	}
}

public JsonDic<JDeventOgre> m_eventOgre_dic
{
	get
	{
		if(_m_eventOgre_dic==null)
		{
			string _data=LoadFile("eventOgre",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_eventOgre_dic=new JsonDic<JDeventOgre>(_data);
		}
		return _m_eventOgre_dic;
	}
}

JsonDic<JDexchangeList> _m_exchangeList_dic;
public void exchangeList_Pre()
{
	if(_m_exchangeList_dic==null)
	{
		if(m_exchangeList_dic.Count>0)return;
	}
}

public List<JDexchangeList> m_exchangeList_list
{
	get
	{
		return m_exchangeList_dic.DataList;
	}
}

public JsonDic<JDexchangeList> m_exchangeList_dic
{
	get
	{
		if(_m_exchangeList_dic==null)
		{
			string _data=LoadFile("exchangeList",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_exchangeList_dic=new JsonDic<JDexchangeList>(_data);
		}
		return _m_exchangeList_dic;
	}
}

JsonDic<JDfx> _m_fx_dic;
public void fx_Pre()
{
	if(_m_fx_dic==null)
	{
		if(m_fx_dic.Count>0)return;
	}
}

public List<JDfx> m_fx_list
{
	get
	{
		return m_fx_dic.DataList;
	}
}

public JsonDic<JDfx> m_fx_dic
{
	get
	{
		if(_m_fx_dic==null)
		{
			string _data=LoadFile("fx",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx_dic=new JsonDic<JDfx>(_data);
		}
		return _m_fx_dic;
	}
}

JsonDic<JDfx1> _m_fx1_dic;
public void fx1_Pre()
{
	if(_m_fx1_dic==null)
	{
		if(m_fx1_dic.Count>0)return;
	}
}

public List<JDfx1> m_fx1_list
{
	get
	{
		return m_fx1_dic.DataList;
	}
}

public JsonDic<JDfx1> m_fx1_dic
{
	get
	{
		if(_m_fx1_dic==null)
		{
			string _data=LoadFile("fx1",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx1_dic=new JsonDic<JDfx1>(_data);
		}
		return _m_fx1_dic;
	}
}

JsonDic<JDfx10> _m_fx10_dic;
public void fx10_Pre()
{
	if(_m_fx10_dic==null)
	{
		if(m_fx10_dic.Count>0)return;
	}
}

public List<JDfx10> m_fx10_list
{
	get
	{
		return m_fx10_dic.DataList;
	}
}

public JsonDic<JDfx10> m_fx10_dic
{
	get
	{
		if(_m_fx10_dic==null)
		{
			string _data=LoadFile("fx10",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx10_dic=new JsonDic<JDfx10>(_data);
		}
		return _m_fx10_dic;
	}
}

JsonDic<JDfx2> _m_fx2_dic;
public void fx2_Pre()
{
	if(_m_fx2_dic==null)
	{
		if(m_fx2_dic.Count>0)return;
	}
}

public List<JDfx2> m_fx2_list
{
	get
	{
		return m_fx2_dic.DataList;
	}
}

public JsonDic<JDfx2> m_fx2_dic
{
	get
	{
		if(_m_fx2_dic==null)
		{
			string _data=LoadFile("fx2",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx2_dic=new JsonDic<JDfx2>(_data);
		}
		return _m_fx2_dic;
	}
}

JsonDic<JDfx3> _m_fx3_dic;
public void fx3_Pre()
{
	if(_m_fx3_dic==null)
	{
		if(m_fx3_dic.Count>0)return;
	}
}

public List<JDfx3> m_fx3_list
{
	get
	{
		return m_fx3_dic.DataList;
	}
}

public JsonDic<JDfx3> m_fx3_dic
{
	get
	{
		if(_m_fx3_dic==null)
		{
			string _data=LoadFile("fx3",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx3_dic=new JsonDic<JDfx3>(_data);
		}
		return _m_fx3_dic;
	}
}

JsonDic<JDfx4> _m_fx4_dic;
public void fx4_Pre()
{
	if(_m_fx4_dic==null)
	{
		if(m_fx4_dic.Count>0)return;
	}
}

public List<JDfx4> m_fx4_list
{
	get
	{
		return m_fx4_dic.DataList;
	}
}

public JsonDic<JDfx4> m_fx4_dic
{
	get
	{
		if(_m_fx4_dic==null)
		{
			string _data=LoadFile("fx4",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx4_dic=new JsonDic<JDfx4>(_data);
		}
		return _m_fx4_dic;
	}
}

JsonDic<JDfx5> _m_fx5_dic;
public void fx5_Pre()
{
	if(_m_fx5_dic==null)
	{
		if(m_fx5_dic.Count>0)return;
	}
}

public List<JDfx5> m_fx5_list
{
	get
	{
		return m_fx5_dic.DataList;
	}
}

public JsonDic<JDfx5> m_fx5_dic
{
	get
	{
		if(_m_fx5_dic==null)
		{
			string _data=LoadFile("fx5",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx5_dic=new JsonDic<JDfx5>(_data);
		}
		return _m_fx5_dic;
	}
}

JsonDic<JDfx6> _m_fx6_dic;
public void fx6_Pre()
{
	if(_m_fx6_dic==null)
	{
		if(m_fx6_dic.Count>0)return;
	}
}

public List<JDfx6> m_fx6_list
{
	get
	{
		return m_fx6_dic.DataList;
	}
}

public JsonDic<JDfx6> m_fx6_dic
{
	get
	{
		if(_m_fx6_dic==null)
		{
			string _data=LoadFile("fx6",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx6_dic=new JsonDic<JDfx6>(_data);
		}
		return _m_fx6_dic;
	}
}

JsonDic<JDfx7> _m_fx7_dic;
public void fx7_Pre()
{
	if(_m_fx7_dic==null)
	{
		if(m_fx7_dic.Count>0)return;
	}
}

public List<JDfx7> m_fx7_list
{
	get
	{
		return m_fx7_dic.DataList;
	}
}

public JsonDic<JDfx7> m_fx7_dic
{
	get
	{
		if(_m_fx7_dic==null)
		{
			string _data=LoadFile("fx7",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx7_dic=new JsonDic<JDfx7>(_data);
		}
		return _m_fx7_dic;
	}
}

JsonDic<JDfx8> _m_fx8_dic;
public void fx8_Pre()
{
	if(_m_fx8_dic==null)
	{
		if(m_fx8_dic.Count>0)return;
	}
}

public List<JDfx8> m_fx8_list
{
	get
	{
		return m_fx8_dic.DataList;
	}
}

public JsonDic<JDfx8> m_fx8_dic
{
	get
	{
		if(_m_fx8_dic==null)
		{
			string _data=LoadFile("fx8",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx8_dic=new JsonDic<JDfx8>(_data);
		}
		return _m_fx8_dic;
	}
}

JsonDic<JDfx9> _m_fx9_dic;
public void fx9_Pre()
{
	if(_m_fx9_dic==null)
	{
		if(m_fx9_dic.Count>0)return;
	}
}

public List<JDfx9> m_fx9_list
{
	get
	{
		return m_fx9_dic.DataList;
	}
}

public JsonDic<JDfx9> m_fx9_dic
{
	get
	{
		if(_m_fx9_dic==null)
		{
			string _data=LoadFile("fx9",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_fx9_dic=new JsonDic<JDfx9>(_data);
		}
		return _m_fx9_dic;
	}
}

JsonDic<JDgem> _m_gem_dic;
public void gem_Pre()
{
	if(_m_gem_dic==null)
	{
		if(m_gem_dic.Count>0)return;
	}
}

public List<JDgem> m_gem_list
{
	get
	{
		return m_gem_dic.DataList;
	}
}

public JsonDic<JDgem> m_gem_dic
{
	get
	{
		if(_m_gem_dic==null)
		{
			string _data=LoadFile("gem",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_gem_dic=new JsonDic<JDgem>(_data);
		}
		return _m_gem_dic;
	}
}

JsonDic<JDgemPos> _m_gemPos_dic;
public void gemPos_Pre()
{
	if(_m_gemPos_dic==null)
	{
		if(m_gemPos_dic.Count>0)return;
	}
}

public List<JDgemPos> m_gemPos_list
{
	get
	{
		return m_gemPos_dic.DataList;
	}
}

public JsonDic<JDgemPos> m_gemPos_dic
{
	get
	{
		if(_m_gemPos_dic==null)
		{
			string _data=LoadFile("gemPos",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_gemPos_dic=new JsonDic<JDgemPos>(_data);
		}
		return _m_gemPos_dic;
	}
}

JsonDic<JDgoblin> _m_goblin_dic;
public void goblin_Pre()
{
	if(_m_goblin_dic==null)
	{
		if(m_goblin_dic.Count>0)return;
	}
}

public List<JDgoblin> m_goblin_list
{
	get
	{
		return m_goblin_dic.DataList;
	}
}

public JsonDic<JDgoblin> m_goblin_dic
{
	get
	{
		if(_m_goblin_dic==null)
		{
			string _data=LoadFile("goblin",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_goblin_dic=new JsonDic<JDgoblin>(_data);
		}
		return _m_goblin_dic;
	}
}

JsonDic<JDgontshi_config> _m_gontshi_config_dic;
public void gontshi_config_Pre()
{
	if(_m_gontshi_config_dic==null)
	{
		if(m_gontshi_config_dic.Count>0)return;
	}
}

public List<JDgontshi_config> m_gontshi_config_list
{
	get
	{
		return m_gontshi_config_dic.DataList;
	}
}

public JsonDic<JDgontshi_config> m_gontshi_config_dic
{
	get
	{
		if(_m_gontshi_config_dic==null)
		{
			string _data=LoadFile("gontshi_config",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_gontshi_config_dic=new JsonDic<JDgontshi_config>(_data);
		}
		return _m_gontshi_config_dic;
	}
}

JsonDic<JDguideMsg> _m_guideMsg_dic;
public void guideMsg_Pre()
{
	if(_m_guideMsg_dic==null)
	{
		if(m_guideMsg_dic.Count>0)return;
	}
}

public List<JDguideMsg> m_guideMsg_list
{
	get
	{
		return m_guideMsg_dic.DataList;
	}
}

public JsonDic<JDguideMsg> m_guideMsg_dic
{
	get
	{
		if(_m_guideMsg_dic==null)
		{
			string _data=LoadFile("guideMsg",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_guideMsg_dic=new JsonDic<JDguideMsg>(_data);
		}
		return _m_guideMsg_dic;
	}
}

JsonDic<JDguidePlot> _m_guidePlot_dic;
public void guidePlot_Pre()
{
	if(_m_guidePlot_dic==null)
	{
		if(m_guidePlot_dic.Count>0)return;
	}
}

public List<JDguidePlot> m_guidePlot_list
{
	get
	{
		return m_guidePlot_dic.DataList;
	}
}

public JsonDic<JDguidePlot> m_guidePlot_dic
{
	get
	{
		if(_m_guidePlot_dic==null)
		{
			string _data=LoadFile("guidePlot",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_guidePlot_dic=new JsonDic<JDguidePlot>(_data);
		}
		return _m_guidePlot_dic;
	}
}

JsonDic<JDguideStep> _m_guideStep_dic;
public void guideStep_Pre()
{
	if(_m_guideStep_dic==null)
	{
		if(m_guideStep_dic.Count>0)return;
	}
}

public List<JDguideStep> m_guideStep_list
{
	get
	{
		return m_guideStep_dic.DataList;
	}
}

public JsonDic<JDguideStep> m_guideStep_dic
{
	get
	{
		if(_m_guideStep_dic==null)
		{
			string _data=LoadFile("guideStep",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_guideStep_dic=new JsonDic<JDguideStep>(_data);
		}
		return _m_guideStep_dic;
	}
}

JsonDic<JDhonor> _m_honor_dic;
public void honor_Pre()
{
	if(_m_honor_dic==null)
	{
		if(m_honor_dic.Count>0)return;
	}
}

public List<JDhonor> m_honor_list
{
	get
	{
		return m_honor_dic.DataList;
	}
}

public JsonDic<JDhonor> m_honor_dic
{
	get
	{
		if(_m_honor_dic==null)
		{
			string _data=LoadFile("honor",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_honor_dic=new JsonDic<JDhonor>(_data);
		}
		return _m_honor_dic;
	}
}

JsonDic<JDhonorAttr> _m_honorAttr_dic;
public void honorAttr_Pre()
{
	if(_m_honorAttr_dic==null)
	{
		if(m_honorAttr_dic.Count>0)return;
	}
}

public List<JDhonorAttr> m_honorAttr_list
{
	get
	{
		return m_honorAttr_dic.DataList;
	}
}

public JsonDic<JDhonorAttr> m_honorAttr_dic
{
	get
	{
		if(_m_honorAttr_dic==null)
		{
			string _data=LoadFile("honorAttr",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_honorAttr_dic=new JsonDic<JDhonorAttr>(_data);
		}
		return _m_honorAttr_dic;
	}
}

JsonDic<JDinviteRewardCode> _m_inviteRewardCode_dic;
public void inviteRewardCode_Pre()
{
	if(_m_inviteRewardCode_dic==null)
	{
		if(m_inviteRewardCode_dic.Count>0)return;
	}
}

public List<JDinviteRewardCode> m_inviteRewardCode_list
{
	get
	{
		return m_inviteRewardCode_dic.DataList;
	}
}

public JsonDic<JDinviteRewardCode> m_inviteRewardCode_dic
{
	get
	{
		if(_m_inviteRewardCode_dic==null)
		{
			string _data=LoadFile("inviteRewardCode",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_inviteRewardCode_dic=new JsonDic<JDinviteRewardCode>(_data);
		}
		return _m_inviteRewardCode_dic;
	}
}

JsonDic<JDinviteRewardFb> _m_inviteRewardFb_dic;
public void inviteRewardFb_Pre()
{
	if(_m_inviteRewardFb_dic==null)
	{
		if(m_inviteRewardFb_dic.Count>0)return;
	}
}

public List<JDinviteRewardFb> m_inviteRewardFb_list
{
	get
	{
		return m_inviteRewardFb_dic.DataList;
	}
}

public JsonDic<JDinviteRewardFb> m_inviteRewardFb_dic
{
	get
	{
		if(_m_inviteRewardFb_dic==null)
		{
			string _data=LoadFile("inviteRewardFb",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_inviteRewardFb_dic=new JsonDic<JDinviteRewardFb>(_data);
		}
		return _m_inviteRewardFb_dic;
	}
}

JsonDic<JDiptables> _m_iptables_dic;
public void iptables_Pre()
{
	if(_m_iptables_dic==null)
	{
		if(m_iptables_dic.Count>0)return;
	}
}

public List<JDiptables> m_iptables_list
{
	get
	{
		return m_iptables_dic.DataList;
	}
}

public JsonDic<JDiptables> m_iptables_dic
{
	get
	{
		if(_m_iptables_dic==null)
		{
			string _data=LoadFile("iptables",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_iptables_dic=new JsonDic<JDiptables>(_data);
		}
		return _m_iptables_dic;
	}
}

JsonDic<JDitem> _m_item_dic;
public void item_Pre()
{
	if(_m_item_dic==null)
	{
		if(m_item_dic.Count>0)return;
	}
}

public List<JDitem> m_item_list
{
	get
	{
		return m_item_dic.DataList;
	}
}

public JsonDic<JDitem> m_item_dic
{
	get
	{
		if(_m_item_dic==null)
		{
			string _data=LoadFile("item",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_item_dic=new JsonDic<JDitem>(_data);
		}
		return _m_item_dic;
	}
}

JsonDic<JDitemBox> _m_itemBox_dic;
public void itemBox_Pre()
{
	if(_m_itemBox_dic==null)
	{
		if(m_itemBox_dic.Count>0)return;
	}
}

public List<JDitemBox> m_itemBox_list
{
	get
	{
		return m_itemBox_dic.DataList;
	}
}

public JsonDic<JDitemBox> m_itemBox_dic
{
	get
	{
		if(_m_itemBox_dic==null)
		{
			string _data=LoadFile("itemBox",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_itemBox_dic=new JsonDic<JDitemBox>(_data);
		}
		return _m_itemBox_dic;
	}
}

JsonDic<JDitemGroup> _m_itemGroup_dic;
public void itemGroup_Pre()
{
	if(_m_itemGroup_dic==null)
	{
		if(m_itemGroup_dic.Count>0)return;
	}
}

public List<JDitemGroup> m_itemGroup_list
{
	get
	{
		return m_itemGroup_dic.DataList;
	}
}

public JsonDic<JDitemGroup> m_itemGroup_dic
{
	get
	{
		if(_m_itemGroup_dic==null)
		{
			string _data=LoadFile("itemGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_itemGroup_dic=new JsonDic<JDitemGroup>(_data);
		}
		return _m_itemGroup_dic;
	}
}

JsonDic<JDitemGroupInfo> _m_itemGroupInfo_dic;
public void itemGroupInfo_Pre()
{
	if(_m_itemGroupInfo_dic==null)
	{
		if(m_itemGroupInfo_dic.Count>0)return;
	}
}

public List<JDitemGroupInfo> m_itemGroupInfo_list
{
	get
	{
		return m_itemGroupInfo_dic.DataList;
	}
}

public JsonDic<JDitemGroupInfo> m_itemGroupInfo_dic
{
	get
	{
		if(_m_itemGroupInfo_dic==null)
		{
			string _data=LoadFile("itemGroupInfo",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_itemGroupInfo_dic=new JsonDic<JDitemGroupInfo>(_data);
		}
		return _m_itemGroupInfo_dic;
	}
}

JsonDic<JDitemMakeList> _m_itemMakeList_dic;
public void itemMakeList_Pre()
{
	if(_m_itemMakeList_dic==null)
	{
		if(m_itemMakeList_dic.Count>0)return;
	}
}

public List<JDitemMakeList> m_itemMakeList_list
{
	get
	{
		return m_itemMakeList_dic.DataList;
	}
}

public JsonDic<JDitemMakeList> m_itemMakeList_dic
{
	get
	{
		if(_m_itemMakeList_dic==null)
		{
			string _data=LoadFile("itemMakeList",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_itemMakeList_dic=new JsonDic<JDitemMakeList>(_data);
		}
		return _m_itemMakeList_dic;
	}
}

JsonDic<JDitemQuality> _m_itemQuality_dic;
public void itemQuality_Pre()
{
	if(_m_itemQuality_dic==null)
	{
		if(m_itemQuality_dic.Count>0)return;
	}
}

public List<JDitemQuality> m_itemQuality_list
{
	get
	{
		return m_itemQuality_dic.DataList;
	}
}

public JsonDic<JDitemQuality> m_itemQuality_dic
{
	get
	{
		if(_m_itemQuality_dic==null)
		{
			string _data=LoadFile("itemQuality",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_itemQuality_dic=new JsonDic<JDitemQuality>(_data);
		}
		return _m_itemQuality_dic;
	}
}

JsonDic<JDitemType> _m_itemType_dic;
public void itemType_Pre()
{
	if(_m_itemType_dic==null)
	{
		if(m_itemType_dic.Count>0)return;
	}
}

public List<JDitemType> m_itemType_list
{
	get
	{
		return m_itemType_dic.DataList;
	}
}

public JsonDic<JDitemType> m_itemType_dic
{
	get
	{
		if(_m_itemType_dic==null)
		{
			string _data=LoadFile("itemType",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_itemType_dic=new JsonDic<JDitemType>(_data);
		}
		return _m_itemType_dic;
	}
}

JsonDic<JDjuedou> _m_juedou_dic;
public void juedou_Pre()
{
	if(_m_juedou_dic==null)
	{
		if(m_juedou_dic.Count>0)return;
	}
}

public List<JDjuedou> m_juedou_list
{
	get
	{
		return m_juedou_dic.DataList;
	}
}

public JsonDic<JDjuedou> m_juedou_dic
{
	get
	{
		if(_m_juedou_dic==null)
		{
			string _data=LoadFile("juedou",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_juedou_dic=new JsonDic<JDjuedou>(_data);
		}
		return _m_juedou_dic;
	}
}

JsonDic<JDjuedouGroup> _m_juedouGroup_dic;
public void juedouGroup_Pre()
{
	if(_m_juedouGroup_dic==null)
	{
		if(m_juedouGroup_dic.Count>0)return;
	}
}

public List<JDjuedouGroup> m_juedouGroup_list
{
	get
	{
		return m_juedouGroup_dic.DataList;
	}
}

public JsonDic<JDjuedouGroup> m_juedouGroup_dic
{
	get
	{
		if(_m_juedouGroup_dic==null)
		{
			string _data=LoadFile("juedouGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_juedouGroup_dic=new JsonDic<JDjuedouGroup>(_data);
		}
		return _m_juedouGroup_dic;
	}
}

JsonDic<JDjuedouLevel> _m_juedouLevel_dic;
public void juedouLevel_Pre()
{
	if(_m_juedouLevel_dic==null)
	{
		if(m_juedouLevel_dic.Count>0)return;
	}
}

public List<JDjuedouLevel> m_juedouLevel_list
{
	get
	{
		return m_juedouLevel_dic.DataList;
	}
}

public JsonDic<JDjuedouLevel> m_juedouLevel_dic
{
	get
	{
		if(_m_juedouLevel_dic==null)
		{
			string _data=LoadFile("juedouLevel",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_juedouLevel_dic=new JsonDic<JDjuedouLevel>(_data);
		}
		return _m_juedouLevel_dic;
	}
}

JsonDic<JDjuedouOgre> _m_juedouOgre_dic;
public void juedouOgre_Pre()
{
	if(_m_juedouOgre_dic==null)
	{
		if(m_juedouOgre_dic.Count>0)return;
	}
}

public List<JDjuedouOgre> m_juedouOgre_list
{
	get
	{
		return m_juedouOgre_dic.DataList;
	}
}

public JsonDic<JDjuedouOgre> m_juedouOgre_dic
{
	get
	{
		if(_m_juedouOgre_dic==null)
		{
			string _data=LoadFile("juedouOgre",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_juedouOgre_dic=new JsonDic<JDjuedouOgre>(_data);
		}
		return _m_juedouOgre_dic;
	}
}

JsonDic<JDladderAward> _m_ladderAward_dic;
public void ladderAward_Pre()
{
	if(_m_ladderAward_dic==null)
	{
		if(m_ladderAward_dic.Count>0)return;
	}
}

public List<JDladderAward> m_ladderAward_list
{
	get
	{
		return m_ladderAward_dic.DataList;
	}
}

public JsonDic<JDladderAward> m_ladderAward_dic
{
	get
	{
		if(_m_ladderAward_dic==null)
		{
			string _data=LoadFile("ladderAward",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_ladderAward_dic=new JsonDic<JDladderAward>(_data);
		}
		return _m_ladderAward_dic;
	}
}

JsonDic<JDladderBase> _m_ladderBase_dic;
public void ladderBase_Pre()
{
	if(_m_ladderBase_dic==null)
	{
		if(m_ladderBase_dic.Count>0)return;
	}
}

public List<JDladderBase> m_ladderBase_list
{
	get
	{
		return m_ladderBase_dic.DataList;
	}
}

public JsonDic<JDladderBase> m_ladderBase_dic
{
	get
	{
		if(_m_ladderBase_dic==null)
		{
			string _data=LoadFile("ladderBase",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_ladderBase_dic=new JsonDic<JDladderBase>(_data);
		}
		return _m_ladderBase_dic;
	}
}

JsonDic<JDladderNewSort> _m_ladderNewSort_dic;
public void ladderNewSort_Pre()
{
	if(_m_ladderNewSort_dic==null)
	{
		if(m_ladderNewSort_dic.Count>0)return;
	}
}

public List<JDladderNewSort> m_ladderNewSort_list
{
	get
	{
		return m_ladderNewSort_dic.DataList;
	}
}

public JsonDic<JDladderNewSort> m_ladderNewSort_dic
{
	get
	{
		if(_m_ladderNewSort_dic==null)
		{
			string _data=LoadFile("ladderNewSort",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_ladderNewSort_dic=new JsonDic<JDladderNewSort>(_data);
		}
		return _m_ladderNewSort_dic;
	}
}

JsonDic<JDladderPlayer> _m_ladderPlayer_dic;
public void ladderPlayer_Pre()
{
	if(_m_ladderPlayer_dic==null)
	{
		if(m_ladderPlayer_dic.Count>0)return;
	}
}

public List<JDladderPlayer> m_ladderPlayer_list
{
	get
	{
		return m_ladderPlayer_dic.DataList;
	}
}

public JsonDic<JDladderPlayer> m_ladderPlayer_dic
{
	get
	{
		if(_m_ladderPlayer_dic==null)
		{
			string _data=LoadFile("ladderPlayer",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_ladderPlayer_dic=new JsonDic<JDladderPlayer>(_data);
		}
		return _m_ladderPlayer_dic;
	}
}

JsonDic<JDlevel> _m_level_dic;
public void level_Pre()
{
	if(_m_level_dic==null)
	{
		if(m_level_dic.Count>0)return;
	}
}

public List<JDlevel> m_level_list
{
	get
	{
		return m_level_dic.DataList;
	}
}

public JsonDic<JDlevel> m_level_dic
{
	get
	{
		if(_m_level_dic==null)
		{
			string _data=LoadFile("level",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_level_dic=new JsonDic<JDlevel>(_data);
		}
		return _m_level_dic;
	}
}

JsonDic<JDmarketArena> _m_marketArena_dic;
public void marketArena_Pre()
{
	if(_m_marketArena_dic==null)
	{
		if(m_marketArena_dic.Count>0)return;
	}
}

public List<JDmarketArena> m_marketArena_list
{
	get
	{
		return m_marketArena_dic.DataList;
	}
}

public JsonDic<JDmarketArena> m_marketArena_dic
{
	get
	{
		if(_m_marketArena_dic==null)
		{
			string _data=LoadFile("marketArena",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_marketArena_dic=new JsonDic<JDmarketArena>(_data);
		}
		return _m_marketArena_dic;
	}
}

JsonDic<JDmarketItems> _m_marketItems_dic;
public void marketItems_Pre()
{
	if(_m_marketItems_dic==null)
	{
		if(m_marketItems_dic.Count>0)return;
	}
}

public List<JDmarketItems> m_marketItems_list
{
	get
	{
		return m_marketItems_dic.DataList;
	}
}

public JsonDic<JDmarketItems> m_marketItems_dic
{
	get
	{
		if(_m_marketItems_dic==null)
		{
			string _data=LoadFile("marketItems",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_marketItems_dic=new JsonDic<JDmarketItems>(_data);
		}
		return _m_marketItems_dic;
	}
}

JsonDic<JDmarketMoney> _m_marketMoney_dic;
public void marketMoney_Pre()
{
	if(_m_marketMoney_dic==null)
	{
		if(m_marketMoney_dic.Count>0)return;
	}
}

public List<JDmarketMoney> m_marketMoney_list
{
	get
	{
		return m_marketMoney_dic.DataList;
	}
}

public JsonDic<JDmarketMoney> m_marketMoney_dic
{
	get
	{
		if(_m_marketMoney_dic==null)
		{
			string _data=LoadFile("marketMoney",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_marketMoney_dic=new JsonDic<JDmarketMoney>(_data);
		}
		return _m_marketMoney_dic;
	}
}

JsonDic<JDmarketRefresh> _m_marketRefresh_dic;
public void marketRefresh_Pre()
{
	if(_m_marketRefresh_dic==null)
	{
		if(m_marketRefresh_dic.Count>0)return;
	}
}

public List<JDmarketRefresh> m_marketRefresh_list
{
	get
	{
		return m_marketRefresh_dic.DataList;
	}
}

public JsonDic<JDmarketRefresh> m_marketRefresh_dic
{
	get
	{
		if(_m_marketRefresh_dic==null)
		{
			string _data=LoadFile("marketRefresh",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_marketRefresh_dic=new JsonDic<JDmarketRefresh>(_data);
		}
		return _m_marketRefresh_dic;
	}
}

JsonDic<JDmarketType> _m_marketType_dic;
public void marketType_Pre()
{
	if(_m_marketType_dic==null)
	{
		if(m_marketType_dic.Count>0)return;
	}
}

public List<JDmarketType> m_marketType_list
{
	get
	{
		return m_marketType_dic.DataList;
	}
}

public JsonDic<JDmarketType> m_marketType_dic
{
	get
	{
		if(_m_marketType_dic==null)
		{
			string _data=LoadFile("marketType",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_marketType_dic=new JsonDic<JDmarketType>(_data);
		}
		return _m_marketType_dic;
	}
}

JsonDic<JDmedal> _m_medal_dic;
public void medal_Pre()
{
	if(_m_medal_dic==null)
	{
		if(m_medal_dic.Count>0)return;
	}
}

public List<JDmedal> m_medal_list
{
	get
	{
		return m_medal_dic.DataList;
	}
}

public JsonDic<JDmedal> m_medal_dic
{
	get
	{
		if(_m_medal_dic==null)
		{
			string _data=LoadFile("medal",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_medal_dic=new JsonDic<JDmedal>(_data);
		}
		return _m_medal_dic;
	}
}

JsonDic<JDmedalAttr> _m_medalAttr_dic;
public void medalAttr_Pre()
{
	if(_m_medalAttr_dic==null)
	{
		if(m_medalAttr_dic.Count>0)return;
	}
}

public List<JDmedalAttr> m_medalAttr_list
{
	get
	{
		return m_medalAttr_dic.DataList;
	}
}

public JsonDic<JDmedalAttr> m_medalAttr_dic
{
	get
	{
		if(_m_medalAttr_dic==null)
		{
			string _data=LoadFile("medalAttr",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_medalAttr_dic=new JsonDic<JDmedalAttr>(_data);
		}
		return _m_medalAttr_dic;
	}
}

JsonDic<JDmodel> _m_model_dic;
public void model_Pre()
{
	if(_m_model_dic==null)
	{
		if(m_model_dic.Count>0)return;
	}
}

public List<JDmodel> m_model_list
{
	get
	{
		return m_model_dic.DataList;
	}
}

public JsonDic<JDmodel> m_model_dic
{
	get
	{
		if(_m_model_dic==null)
		{
			string _data=LoadFile("model",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_model_dic=new JsonDic<JDmodel>(_data);
		}
		return _m_model_dic;
	}
}

JsonDic<JDpaybuy> _m_paybuy_dic;
public void paybuy_Pre()
{
	if(_m_paybuy_dic==null)
	{
		if(m_paybuy_dic.Count>0)return;
	}
}

public List<JDpaybuy> m_paybuy_list
{
	get
	{
		return m_paybuy_dic.DataList;
	}
}

public JsonDic<JDpaybuy> m_paybuy_dic
{
	get
	{
		if(_m_paybuy_dic==null)
		{
			string _data=LoadFile("paybuy",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_paybuy_dic=new JsonDic<JDpaybuy>(_data);
		}
		return _m_paybuy_dic;
	}
}

JsonDic<JDpayment> _m_payment_dic;
public void payment_Pre()
{
	if(_m_payment_dic==null)
	{
		if(m_payment_dic.Count>0)return;
	}
}

public List<JDpayment> m_payment_list
{
	get
	{
		return m_payment_dic.DataList;
	}
}

public JsonDic<JDpayment> m_payment_dic
{
	get
	{
		if(_m_payment_dic==null)
		{
			string _data=LoadFile("payment",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_payment_dic=new JsonDic<JDpayment>(_data);
		}
		return _m_payment_dic;
	}
}

JsonDic<JDpayment_en> _m_payment_en_dic;
public void payment_en_Pre()
{
	if(_m_payment_en_dic==null)
	{
		if(m_payment_en_dic.Count>0)return;
	}
}

public List<JDpayment_en> m_payment_en_list
{
	get
	{
		return m_payment_en_dic.DataList;
	}
}

public JsonDic<JDpayment_en> m_payment_en_dic
{
	get
	{
		if(_m_payment_en_dic==null)
		{
			string _data=LoadFile("payment_en",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_payment_en_dic=new JsonDic<JDpayment_en>(_data);
		}
		return _m_payment_en_dic;
	}
}

JsonDic<JDpayment_tw> _m_payment_tw_dic;
public void payment_tw_Pre()
{
	if(_m_payment_tw_dic==null)
	{
		if(m_payment_tw_dic.Count>0)return;
	}
}

public List<JDpayment_tw> m_payment_tw_list
{
	get
	{
		return m_payment_tw_dic.DataList;
	}
}

public JsonDic<JDpayment_tw> m_payment_tw_dic
{
	get
	{
		if(_m_payment_tw_dic==null)
		{
			string _data=LoadFile("payment_tw",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_payment_tw_dic=new JsonDic<JDpayment_tw>(_data);
		}
		return _m_payment_tw_dic;
	}
}

JsonDic<JDpayweal> _m_payweal_dic;
public void payweal_Pre()
{
	if(_m_payweal_dic==null)
	{
		if(m_payweal_dic.Count>0)return;
	}
}

public List<JDpayweal> m_payweal_list
{
	get
	{
		return m_payweal_dic.DataList;
	}
}

public JsonDic<JDpayweal> m_payweal_dic
{
	get
	{
		if(_m_payweal_dic==null)
		{
			string _data=LoadFile("payweal",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_payweal_dic=new JsonDic<JDpayweal>(_data);
		}
		return _m_payweal_dic;
	}
}

JsonDic<JDpetBase> _m_petBase_dic;
public void petBase_Pre()
{
	if(_m_petBase_dic==null)
	{
		if(m_petBase_dic.Count>0)return;
	}
}

public List<JDpetBase> m_petBase_list
{
	get
	{
		return m_petBase_dic.DataList;
	}
}

public JsonDic<JDpetBase> m_petBase_dic
{
	get
	{
		if(_m_petBase_dic==null)
		{
			string _data=LoadFile("petBase",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_petBase_dic=new JsonDic<JDpetBase>(_data);
		}
		return _m_petBase_dic;
	}
}

JsonDic<JDpetConfig> _m_petConfig_dic;
public void petConfig_Pre()
{
	if(_m_petConfig_dic==null)
	{
		if(m_petConfig_dic.Count>0)return;
	}
}

public List<JDpetConfig> m_petConfig_list
{
	get
	{
		return m_petConfig_dic.DataList;
	}
}

public JsonDic<JDpetConfig> m_petConfig_dic
{
	get
	{
		if(_m_petConfig_dic==null)
		{
			string _data=LoadFile("petConfig",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_petConfig_dic=new JsonDic<JDpetConfig>(_data);
		}
		return _m_petConfig_dic;
	}
}

JsonDic<JDpetLv> _m_petLv_dic;
public void petLv_Pre()
{
	if(_m_petLv_dic==null)
	{
		if(m_petLv_dic.Count>0)return;
	}
}

public List<JDpetLv> m_petLv_list
{
	get
	{
		return m_petLv_dic.DataList;
	}
}

public JsonDic<JDpetLv> m_petLv_dic
{
	get
	{
		if(_m_petLv_dic==null)
		{
			string _data=LoadFile("petLv",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_petLv_dic=new JsonDic<JDpetLv>(_data);
		}
		return _m_petLv_dic;
	}
}

JsonDic<JDpetRank> _m_petRank_dic;
public void petRank_Pre()
{
	if(_m_petRank_dic==null)
	{
		if(m_petRank_dic.Count>0)return;
	}
}

public List<JDpetRank> m_petRank_list
{
	get
	{
		return m_petRank_dic.DataList;
	}
}

public JsonDic<JDpetRank> m_petRank_dic
{
	get
	{
		if(_m_petRank_dic==null)
		{
			string _data=LoadFile("petRank",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_petRank_dic=new JsonDic<JDpetRank>(_data);
		}
		return _m_petRank_dic;
	}
}

JsonDic<JDraid> _m_raid_dic;
public void raid_Pre()
{
	if(_m_raid_dic==null)
	{
		if(m_raid_dic.Count>0)return;
	}
}

public List<JDraid> m_raid_list
{
	get
	{
		return m_raid_dic.DataList;
	}
}

public JsonDic<JDraid> m_raid_dic
{
	get
	{
		if(_m_raid_dic==null)
		{
			string _data=LoadFile("raid",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_raid_dic=new JsonDic<JDraid>(_data);
		}
		return _m_raid_dic;
	}
}

JsonDic<JDrandAttr> _m_randAttr_dic;
public void randAttr_Pre()
{
	if(_m_randAttr_dic==null)
	{
		if(m_randAttr_dic.Count>0)return;
	}
}

public List<JDrandAttr> m_randAttr_list
{
	get
	{
		return m_randAttr_dic.DataList;
	}
}

public JsonDic<JDrandAttr> m_randAttr_dic
{
	get
	{
		if(_m_randAttr_dic==null)
		{
			string _data=LoadFile("randAttr",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_randAttr_dic=new JsonDic<JDrandAttr>(_data);
		}
		return _m_randAttr_dic;
	}
}

JsonDic<JDrecord> _m_record_dic;
public void record_Pre()
{
	if(_m_record_dic==null)
	{
		if(m_record_dic.Count>0)return;
	}
}

public List<JDrecord> m_record_list
{
	get
	{
		return m_record_dic.DataList;
	}
}

public JsonDic<JDrecord> m_record_dic
{
	get
	{
		if(_m_record_dic==null)
		{
			string _data=LoadFile("record",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_record_dic=new JsonDic<JDrecord>(_data);
		}
		return _m_record_dic;
	}
}

JsonDic<JDregister> _m_register_dic;
public void register_Pre()
{
	if(_m_register_dic==null)
	{
		if(m_register_dic.Count>0)return;
	}
}

public List<JDregister> m_register_list
{
	get
	{
		return m_register_dic.DataList;
	}
}

public JsonDic<JDregister> m_register_dic
{
	get
	{
		if(_m_register_dic==null)
		{
			string _data=LoadFile("register",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_register_dic=new JsonDic<JDregister>(_data);
		}
		return _m_register_dic;
	}
}

JsonDic<JDrewardCLogin> _m_rewardCLogin_dic;
public void rewardCLogin_Pre()
{
	if(_m_rewardCLogin_dic==null)
	{
		if(m_rewardCLogin_dic.Count>0)return;
	}
}

public List<JDrewardCLogin> m_rewardCLogin_list
{
	get
	{
		return m_rewardCLogin_dic.DataList;
	}
}

public JsonDic<JDrewardCLogin> m_rewardCLogin_dic
{
	get
	{
		if(_m_rewardCLogin_dic==null)
		{
			string _data=LoadFile("rewardCLogin",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardCLogin_dic=new JsonDic<JDrewardCLogin>(_data);
		}
		return _m_rewardCLogin_dic;
	}
}

JsonDic<JDrewardDPay> _m_rewardDPay_dic;
public void rewardDPay_Pre()
{
	if(_m_rewardDPay_dic==null)
	{
		if(m_rewardDPay_dic.Count>0)return;
	}
}

public List<JDrewardDPay> m_rewardDPay_list
{
	get
	{
		return m_rewardDPay_dic.DataList;
	}
}

public JsonDic<JDrewardDPay> m_rewardDPay_dic
{
	get
	{
		if(_m_rewardDPay_dic==null)
		{
			string _data=LoadFile("rewardDPay",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardDPay_dic=new JsonDic<JDrewardDPay>(_data);
		}
		return _m_rewardDPay_dic;
	}
}

JsonDic<JDrewardFPay> _m_rewardFPay_dic;
public void rewardFPay_Pre()
{
	if(_m_rewardFPay_dic==null)
	{
		if(m_rewardFPay_dic.Count>0)return;
	}
}

public List<JDrewardFPay> m_rewardFPay_list
{
	get
	{
		return m_rewardFPay_dic.DataList;
	}
}

public JsonDic<JDrewardFPay> m_rewardFPay_dic
{
	get
	{
		if(_m_rewardFPay_dic==null)
		{
			string _data=LoadFile("rewardFPay",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardFPay_dic=new JsonDic<JDrewardFPay>(_data);
		}
		return _m_rewardFPay_dic;
	}
}

JsonDic<JDrewardFund> _m_rewardFund_dic;
public void rewardFund_Pre()
{
	if(_m_rewardFund_dic==null)
	{
		if(m_rewardFund_dic.Count>0)return;
	}
}

public List<JDrewardFund> m_rewardFund_list
{
	get
	{
		return m_rewardFund_dic.DataList;
	}
}

public JsonDic<JDrewardFund> m_rewardFund_dic
{
	get
	{
		if(_m_rewardFund_dic==null)
		{
			string _data=LoadFile("rewardFund",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardFund_dic=new JsonDic<JDrewardFund>(_data);
		}
		return _m_rewardFund_dic;
	}
}

JsonDic<JDrewardLevel> _m_rewardLevel_dic;
public void rewardLevel_Pre()
{
	if(_m_rewardLevel_dic==null)
	{
		if(m_rewardLevel_dic.Count>0)return;
	}
}

public List<JDrewardLevel> m_rewardLevel_list
{
	get
	{
		return m_rewardLevel_dic.DataList;
	}
}

public JsonDic<JDrewardLevel> m_rewardLevel_dic
{
	get
	{
		if(_m_rewardLevel_dic==null)
		{
			string _data=LoadFile("rewardLevel",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardLevel_dic=new JsonDic<JDrewardLevel>(_data);
		}
		return _m_rewardLevel_dic;
	}
}

JsonDic<JDrewardOnline> _m_rewardOnline_dic;
public void rewardOnline_Pre()
{
	if(_m_rewardOnline_dic==null)
	{
		if(m_rewardOnline_dic.Count>0)return;
	}
}

public List<JDrewardOnline> m_rewardOnline_list
{
	get
	{
		return m_rewardOnline_dic.DataList;
	}
}

public JsonDic<JDrewardOnline> m_rewardOnline_dic
{
	get
	{
		if(_m_rewardOnline_dic==null)
		{
			string _data=LoadFile("rewardOnline",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardOnline_dic=new JsonDic<JDrewardOnline>(_data);
		}
		return _m_rewardOnline_dic;
	}
}

JsonDic<JDrewardTLogin> _m_rewardTLogin_dic;
public void rewardTLogin_Pre()
{
	if(_m_rewardTLogin_dic==null)
	{
		if(m_rewardTLogin_dic.Count>0)return;
	}
}

public List<JDrewardTLogin> m_rewardTLogin_list
{
	get
	{
		return m_rewardTLogin_dic.DataList;
	}
}

public JsonDic<JDrewardTLogin> m_rewardTLogin_dic
{
	get
	{
		if(_m_rewardTLogin_dic==null)
		{
			string _data=LoadFile("rewardTLogin",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardTLogin_dic=new JsonDic<JDrewardTLogin>(_data);
		}
		return _m_rewardTLogin_dic;
	}
}

JsonDic<JDrewardTPay> _m_rewardTPay_dic;
public void rewardTPay_Pre()
{
	if(_m_rewardTPay_dic==null)
	{
		if(m_rewardTPay_dic.Count>0)return;
	}
}

public List<JDrewardTPay> m_rewardTPay_list
{
	get
	{
		return m_rewardTPay_dic.DataList;
	}
}

public JsonDic<JDrewardTPay> m_rewardTPay_dic
{
	get
	{
		if(_m_rewardTPay_dic==null)
		{
			string _data=LoadFile("rewardTPay",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardTPay_dic=new JsonDic<JDrewardTPay>(_data);
		}
		return _m_rewardTPay_dic;
	}
}

JsonDic<JDrewardTable> _m_rewardTable_dic;
public void rewardTable_Pre()
{
	if(_m_rewardTable_dic==null)
	{
		if(m_rewardTable_dic.Count>0)return;
	}
}

public List<JDrewardTable> m_rewardTable_list
{
	get
	{
		return m_rewardTable_dic.DataList;
	}
}

public JsonDic<JDrewardTable> m_rewardTable_dic
{
	get
	{
		if(_m_rewardTable_dic==null)
		{
			string _data=LoadFile("rewardTable",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardTable_dic=new JsonDic<JDrewardTable>(_data);
		}
		return _m_rewardTable_dic;
	}
}

JsonDic<JDrewardVipExp> _m_rewardVipExp_dic;
public void rewardVipExp_Pre()
{
	if(_m_rewardVipExp_dic==null)
	{
		if(m_rewardVipExp_dic.Count>0)return;
	}
}

public List<JDrewardVipExp> m_rewardVipExp_list
{
	get
	{
		return m_rewardVipExp_dic.DataList;
	}
}

public JsonDic<JDrewardVipExp> m_rewardVipExp_dic
{
	get
	{
		if(_m_rewardVipExp_dic==null)
		{
			string _data=LoadFile("rewardVipExp",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_rewardVipExp_dic=new JsonDic<JDrewardVipExp>(_data);
		}
		return _m_rewardVipExp_dic;
	}
}

JsonDic<JDruneAttr> _m_runeAttr_dic;
public void runeAttr_Pre()
{
	if(_m_runeAttr_dic==null)
	{
		if(m_runeAttr_dic.Count>0)return;
	}
}

public List<JDruneAttr> m_runeAttr_list
{
	get
	{
		return m_runeAttr_dic.DataList;
	}
}

public JsonDic<JDruneAttr> m_runeAttr_dic
{
	get
	{
		if(_m_runeAttr_dic==null)
		{
			string _data=LoadFile("runeAttr",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeAttr_dic=new JsonDic<JDruneAttr>(_data);
		}
		return _m_runeAttr_dic;
	}
}

JsonDic<JDruneAttrBase> _m_runeAttrBase_dic;
public void runeAttrBase_Pre()
{
	if(_m_runeAttrBase_dic==null)
	{
		if(m_runeAttrBase_dic.Count>0)return;
	}
}

public List<JDruneAttrBase> m_runeAttrBase_list
{
	get
	{
		return m_runeAttrBase_dic.DataList;
	}
}

public JsonDic<JDruneAttrBase> m_runeAttrBase_dic
{
	get
	{
		if(_m_runeAttrBase_dic==null)
		{
			string _data=LoadFile("runeAttrBase",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeAttrBase_dic=new JsonDic<JDruneAttrBase>(_data);
		}
		return _m_runeAttrBase_dic;
	}
}

JsonDic<JDruneAttrGroup> _m_runeAttrGroup_dic;
public void runeAttrGroup_Pre()
{
	if(_m_runeAttrGroup_dic==null)
	{
		if(m_runeAttrGroup_dic.Count>0)return;
	}
}

public List<JDruneAttrGroup> m_runeAttrGroup_list
{
	get
	{
		return m_runeAttrGroup_dic.DataList;
	}
}

public JsonDic<JDruneAttrGroup> m_runeAttrGroup_dic
{
	get
	{
		if(_m_runeAttrGroup_dic==null)
		{
			string _data=LoadFile("runeAttrGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeAttrGroup_dic=new JsonDic<JDruneAttrGroup>(_data);
		}
		return _m_runeAttrGroup_dic;
	}
}

JsonDic<JDruneAttrInc> _m_runeAttrInc_dic;
public void runeAttrInc_Pre()
{
	if(_m_runeAttrInc_dic==null)
	{
		if(m_runeAttrInc_dic.Count>0)return;
	}
}

public List<JDruneAttrInc> m_runeAttrInc_list
{
	get
	{
		return m_runeAttrInc_dic.DataList;
	}
}

public JsonDic<JDruneAttrInc> m_runeAttrInc_dic
{
	get
	{
		if(_m_runeAttrInc_dic==null)
		{
			string _data=LoadFile("runeAttrInc",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeAttrInc_dic=new JsonDic<JDruneAttrInc>(_data);
		}
		return _m_runeAttrInc_dic;
	}
}

JsonDic<JDruneList> _m_runeList_dic;
public void runeList_Pre()
{
	if(_m_runeList_dic==null)
	{
		if(m_runeList_dic.Count>0)return;
	}
}

public List<JDruneList> m_runeList_list
{
	get
	{
		return m_runeList_dic.DataList;
	}
}

public JsonDic<JDruneList> m_runeList_dic
{
	get
	{
		if(_m_runeList_dic==null)
		{
			string _data=LoadFile("runeList",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeList_dic=new JsonDic<JDruneList>(_data);
		}
		return _m_runeList_dic;
	}
}

JsonDic<JDruneOpen> _m_runeOpen_dic;
public void runeOpen_Pre()
{
	if(_m_runeOpen_dic==null)
	{
		if(m_runeOpen_dic.Count>0)return;
	}
}

public List<JDruneOpen> m_runeOpen_list
{
	get
	{
		return m_runeOpen_dic.DataList;
	}
}

public JsonDic<JDruneOpen> m_runeOpen_dic
{
	get
	{
		if(_m_runeOpen_dic==null)
		{
			string _data=LoadFile("runeOpen",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeOpen_dic=new JsonDic<JDruneOpen>(_data);
		}
		return _m_runeOpen_dic;
	}
}

JsonDic<JDruneRandAttr> _m_runeRandAttr_dic;
public void runeRandAttr_Pre()
{
	if(_m_runeRandAttr_dic==null)
	{
		if(m_runeRandAttr_dic.Count>0)return;
	}
}

public List<JDruneRandAttr> m_runeRandAttr_list
{
	get
	{
		return m_runeRandAttr_dic.DataList;
	}
}

public JsonDic<JDruneRandAttr> m_runeRandAttr_dic
{
	get
	{
		if(_m_runeRandAttr_dic==null)
		{
			string _data=LoadFile("runeRandAttr",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeRandAttr_dic=new JsonDic<JDruneRandAttr>(_data);
		}
		return _m_runeRandAttr_dic;
	}
}

JsonDic<JDruneRandGroup> _m_runeRandGroup_dic;
public void runeRandGroup_Pre()
{
	if(_m_runeRandGroup_dic==null)
	{
		if(m_runeRandGroup_dic.Count>0)return;
	}
}

public List<JDruneRandGroup> m_runeRandGroup_list
{
	get
	{
		return m_runeRandGroup_dic.DataList;
	}
}

public JsonDic<JDruneRandGroup> m_runeRandGroup_dic
{
	get
	{
		if(_m_runeRandGroup_dic==null)
		{
			string _data=LoadFile("runeRandGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeRandGroup_dic=new JsonDic<JDruneRandGroup>(_data);
		}
		return _m_runeRandGroup_dic;
	}
}

JsonDic<JDruneRankUp> _m_runeRankUp_dic;
public void runeRankUp_Pre()
{
	if(_m_runeRankUp_dic==null)
	{
		if(m_runeRankUp_dic.Count>0)return;
	}
}

public List<JDruneRankUp> m_runeRankUp_list
{
	get
	{
		return m_runeRankUp_dic.DataList;
	}
}

public JsonDic<JDruneRankUp> m_runeRankUp_dic
{
	get
	{
		if(_m_runeRankUp_dic==null)
		{
			string _data=LoadFile("runeRankUp",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeRankUp_dic=new JsonDic<JDruneRankUp>(_data);
		}
		return _m_runeRankUp_dic;
	}
}

JsonDic<JDruneSell> _m_runeSell_dic;
public void runeSell_Pre()
{
	if(_m_runeSell_dic==null)
	{
		if(m_runeSell_dic.Count>0)return;
	}
}

public List<JDruneSell> m_runeSell_list
{
	get
	{
		return m_runeSell_dic.DataList;
	}
}

public JsonDic<JDruneSell> m_runeSell_dic
{
	get
	{
		if(_m_runeSell_dic==null)
		{
			string _data=LoadFile("runeSell",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_runeSell_dic=new JsonDic<JDruneSell>(_data);
		}
		return _m_runeSell_dic;
	}
}

JsonDic<JDse> _m_se_dic;
public void se_Pre()
{
	if(_m_se_dic==null)
	{
		if(m_se_dic.Count>0)return;
	}
}

public List<JDse> m_se_list
{
	get
	{
		return m_se_dic.DataList;
	}
}

public JsonDic<JDse> m_se_dic
{
	get
	{
		if(_m_se_dic==null)
		{
			string _data=LoadFile("se",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_se_dic=new JsonDic<JDse>(_data);
		}
		return _m_se_dic;
	}
}

JsonDic<JDsoul> _m_soul_dic;
public void soul_Pre()
{
	if(_m_soul_dic==null)
	{
		if(m_soul_dic.Count>0)return;
	}
}

public List<JDsoul> m_soul_list
{
	get
	{
		return m_soul_dic.DataList;
	}
}

public JsonDic<JDsoul> m_soul_dic
{
	get
	{
		if(_m_soul_dic==null)
		{
			string _data=LoadFile("soul",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_soul_dic=new JsonDic<JDsoul>(_data);
		}
		return _m_soul_dic;
	}
}

JsonDic<JDsoulAttrEffect> _m_soulAttrEffect_dic;
public void soulAttrEffect_Pre()
{
	if(_m_soulAttrEffect_dic==null)
	{
		if(m_soulAttrEffect_dic.Count>0)return;
	}
}

public List<JDsoulAttrEffect> m_soulAttrEffect_list
{
	get
	{
		return m_soulAttrEffect_dic.DataList;
	}
}

public JsonDic<JDsoulAttrEffect> m_soulAttrEffect_dic
{
	get
	{
		if(_m_soulAttrEffect_dic==null)
		{
			string _data=LoadFile("soulAttrEffect",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_soulAttrEffect_dic=new JsonDic<JDsoulAttrEffect>(_data);
		}
		return _m_soulAttrEffect_dic;
	}
}

JsonDic<JDsoulSet> _m_soulSet_dic;
public void soulSet_Pre()
{
	if(_m_soulSet_dic==null)
	{
		if(m_soulSet_dic.Count>0)return;
	}
}

public List<JDsoulSet> m_soulSet_list
{
	get
	{
		return m_soulSet_dic.DataList;
	}
}

public JsonDic<JDsoulSet> m_soulSet_dic
{
	get
	{
		if(_m_soulSet_dic==null)
		{
			string _data=LoadFile("soulSet",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_soulSet_dic=new JsonDic<JDsoulSet>(_data);
		}
		return _m_soulSet_dic;
	}
}

JsonDic<JDstage> _m_stage_dic;
public void stage_Pre()
{
	if(_m_stage_dic==null)
	{
		if(m_stage_dic.Count>0)return;
	}
}

public List<JDstage> m_stage_list
{
	get
	{
		return m_stage_dic.DataList;
	}
}

public JsonDic<JDstage> m_stage_dic
{
	get
	{
		if(_m_stage_dic==null)
		{
			string _data=LoadFile("stage",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_stage_dic=new JsonDic<JDstage>(_data);
		}
		return _m_stage_dic;
	}
}

JsonDic<JDstageLots> _m_stageLots_dic;
public void stageLots_Pre()
{
	if(_m_stageLots_dic==null)
	{
		if(m_stageLots_dic.Count>0)return;
	}
}

public List<JDstageLots> m_stageLots_list
{
	get
	{
		return m_stageLots_dic.DataList;
	}
}

public JsonDic<JDstageLots> m_stageLots_dic
{
	get
	{
		if(_m_stageLots_dic==null)
		{
			string _data=LoadFile("stageLots",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_stageLots_dic=new JsonDic<JDstageLots>(_data);
		}
		return _m_stageLots_dic;
	}
}

JsonDic<JDstageReset> _m_stageReset_dic;
public void stageReset_Pre()
{
	if(_m_stageReset_dic==null)
	{
		if(m_stageReset_dic.Count>0)return;
	}
}

public List<JDstageReset> m_stageReset_list
{
	get
	{
		return m_stageReset_dic.DataList;
	}
}

public JsonDic<JDstageReset> m_stageReset_dic
{
	get
	{
		if(_m_stageReset_dic==null)
		{
			string _data=LoadFile("stageReset",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_stageReset_dic=new JsonDic<JDstageReset>(_data);
		}
		return _m_stageReset_dic;
	}
}

JsonDic<JDstarlv> _m_starlv_dic;
public void starlv_Pre()
{
	if(_m_starlv_dic==null)
	{
		if(m_starlv_dic.Count>0)return;
	}
}

public List<JDstarlv> m_starlv_list
{
	get
	{
		return m_starlv_dic.DataList;
	}
}

public JsonDic<JDstarlv> m_starlv_dic
{
	get
	{
		if(_m_starlv_dic==null)
		{
			string _data=LoadFile("starlv",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_starlv_dic=new JsonDic<JDstarlv>(_data);
		}
		return _m_starlv_dic;
	}
}

JsonDic<JDstory> _m_story_dic;
public void story_Pre()
{
	if(_m_story_dic==null)
	{
		if(m_story_dic.Count>0)return;
	}
}

public List<JDstory> m_story_list
{
	get
	{
		return m_story_dic.DataList;
	}
}

public JsonDic<JDstory> m_story_dic
{
	get
	{
		if(_m_story_dic==null)
		{
			string _data=LoadFile("story",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_story_dic=new JsonDic<JDstory>(_data);
		}
		return _m_story_dic;
	}
}

JsonDic<JDstoryWish> _m_storyWish_dic;
public void storyWish_Pre()
{
	if(_m_storyWish_dic==null)
	{
		if(m_storyWish_dic.Count>0)return;
	}
}

public List<JDstoryWish> m_storyWish_list
{
	get
	{
		return m_storyWish_dic.DataList;
	}
}

public JsonDic<JDstoryWish> m_storyWish_dic
{
	get
	{
		if(_m_storyWish_dic==null)
		{
			string _data=LoadFile("storyWish",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_storyWish_dic=new JsonDic<JDstoryWish>(_data);
		}
		return _m_storyWish_dic;
	}
}

JsonDic<JDtask> _m_task_dic;
public void task_Pre()
{
	if(_m_task_dic==null)
	{
		if(m_task_dic.Count>0)return;
	}
}

public List<JDtask> m_task_list
{
	get
	{
		return m_task_dic.DataList;
	}
}

public JsonDic<JDtask> m_task_dic
{
	get
	{
		if(_m_task_dic==null)
		{
			string _data=LoadFile("task",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_task_dic=new JsonDic<JDtask>(_data);
		}
		return _m_task_dic;
	}
}

JsonDic<JDtaskGroup> _m_taskGroup_dic;
public void taskGroup_Pre()
{
	if(_m_taskGroup_dic==null)
	{
		if(m_taskGroup_dic.Count>0)return;
	}
}

public List<JDtaskGroup> m_taskGroup_list
{
	get
	{
		return m_taskGroup_dic.DataList;
	}
}

public JsonDic<JDtaskGroup> m_taskGroup_dic
{
	get
	{
		if(_m_taskGroup_dic==null)
		{
			string _data=LoadFile("taskGroup",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_taskGroup_dic=new JsonDic<JDtaskGroup>(_data);
		}
		return _m_taskGroup_dic;
	}
}

JsonDic<JDtaskType> _m_taskType_dic;
public void taskType_Pre()
{
	if(_m_taskType_dic==null)
	{
		if(m_taskType_dic.Count>0)return;
	}
}

public List<JDtaskType> m_taskType_list
{
	get
	{
		return m_taskType_dic.DataList;
	}
}

public JsonDic<JDtaskType> m_taskType_dic
{
	get
	{
		if(_m_taskType_dic==null)
		{
			string _data=LoadFile("taskType",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_taskType_dic=new JsonDic<JDtaskType>(_data);
		}
		return _m_taskType_dic;
	}
}

JsonDic<JDtopAttr> _m_topAttr_dic;
public void topAttr_Pre()
{
	if(_m_topAttr_dic==null)
	{
		if(m_topAttr_dic.Count>0)return;
	}
}

public List<JDtopAttr> m_topAttr_list
{
	get
	{
		return m_topAttr_dic.DataList;
	}
}

public JsonDic<JDtopAttr> m_topAttr_dic
{
	get
	{
		if(_m_topAttr_dic==null)
		{
			string _data=LoadFile("topAttr",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_topAttr_dic=new JsonDic<JDtopAttr>(_data);
		}
		return _m_topAttr_dic;
	}
}

JsonDic<JDtopLv> _m_topLv_dic;
public void topLv_Pre()
{
	if(_m_topLv_dic==null)
	{
		if(m_topLv_dic.Count>0)return;
	}
}

public List<JDtopLv> m_topLv_list
{
	get
	{
		return m_topLv_dic.DataList;
	}
}

public JsonDic<JDtopLv> m_topLv_dic
{
	get
	{
		if(_m_topLv_dic==null)
		{
			string _data=LoadFile("topLv",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_topLv_dic=new JsonDic<JDtopLv>(_data);
		}
		return _m_topLv_dic;
	}
}

JsonDic<JDvip> _m_vip_dic;
public void vip_Pre()
{
	if(_m_vip_dic==null)
	{
		if(m_vip_dic.Count>0)return;
	}
}

public List<JDvip> m_vip_list
{
	get
	{
		return m_vip_dic.DataList;
	}
}

public JsonDic<JDvip> m_vip_dic
{
	get
	{
		if(_m_vip_dic==null)
		{
			string _data=LoadFile("vip",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_vip_dic=new JsonDic<JDvip>(_data);
		}
		return _m_vip_dic;
	}
}

JsonDic<JDweaponType> _m_weaponType_dic;
public void weaponType_Pre()
{
	if(_m_weaponType_dic==null)
	{
		if(m_weaponType_dic.Count>0)return;
	}
}

public List<JDweaponType> m_weaponType_list
{
	get
	{
		return m_weaponType_dic.DataList;
	}
}

public JsonDic<JDweaponType> m_weaponType_dic
{
	get
	{
		if(_m_weaponType_dic==null)
		{
			string _data=LoadFile("weaponType",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_weaponType_dic=new JsonDic<JDweaponType>(_data);
		}
		return _m_weaponType_dic;
	}
}

JsonDic<JDwingList> _m_wingList_dic;
public void wingList_Pre()
{
	if(_m_wingList_dic==null)
	{
		if(m_wingList_dic.Count>0)return;
	}
}

public List<JDwingList> m_wingList_list
{
	get
	{
		return m_wingList_dic.DataList;
	}
}

public JsonDic<JDwingList> m_wingList_dic
{
	get
	{
		if(_m_wingList_dic==null)
		{
			string _data=LoadFile("wingList",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_wingList_dic=new JsonDic<JDwingList>(_data);
		}
		return _m_wingList_dic;
	}
}

JsonDic<JDwingLv> _m_wingLv_dic;
public void wingLv_Pre()
{
	if(_m_wingLv_dic==null)
	{
		if(m_wingLv_dic.Count>0)return;
	}
}

public List<JDwingLv> m_wingLv_list
{
	get
	{
		return m_wingLv_dic.DataList;
	}
}

public JsonDic<JDwingLv> m_wingLv_dic
{
	get
	{
		if(_m_wingLv_dic==null)
		{
			string _data=LoadFile("wingLv",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_wingLv_dic=new JsonDic<JDwingLv>(_data);
		}
		return _m_wingLv_dic;
	}
}

JsonDic<JDwtree> _m_wtree_dic;
public void wtree_Pre()
{
	if(_m_wtree_dic==null)
	{
		if(m_wtree_dic.Count>0)return;
	}
}

public List<JDwtree> m_wtree_list
{
	get
	{
		return m_wtree_dic.DataList;
	}
}

public JsonDic<JDwtree> m_wtree_dic
{
	get
	{
		if(_m_wtree_dic==null)
		{
			string _data=LoadFile("wtree",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_wtree_dic=new JsonDic<JDwtree>(_data);
		}
		return _m_wtree_dic;
	}
}

JsonDic<JDwtreeDayBox> _m_wtreeDayBox_dic;
public void wtreeDayBox_Pre()
{
	if(_m_wtreeDayBox_dic==null)
	{
		if(m_wtreeDayBox_dic.Count>0)return;
	}
}

public List<JDwtreeDayBox> m_wtreeDayBox_list
{
	get
	{
		return m_wtreeDayBox_dic.DataList;
	}
}

public JsonDic<JDwtreeDayBox> m_wtreeDayBox_dic
{
	get
	{
		if(_m_wtreeDayBox_dic==null)
		{
			string _data=LoadFile("wtreeDayBox",true);
			if(string.IsNullOrEmpty(_data))
			{
				return null;
			}
			_m_wtreeDayBox_dic=new JsonDic<JDwtreeDayBox>(_data);
		}
		return _m_wtreeDayBox_dic;
	}
}


}
