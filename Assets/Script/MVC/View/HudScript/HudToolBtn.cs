using UnityEngine;
using System.Collections;

public class HudToolBtn : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	public UIImageButton deplayButton;
	
	public UIImageButton factionButton;
	
	public UIImageButton friendButton;
	
	public UIImageButton geneButton;
	
	public UIImageButton packButton;
	
	public UIImageButton partnerButton;
	
	public UIImageButton qiButton;
	
	public UIButton roleButton;
	
	public UIImageButton sitButton;
	
	public UIImageButton upGradeButton;
	
	
	void Start ()
	{
	    deplayButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
	    factionButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
	    friendButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
		packButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
		partnerButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
		qiButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
		roleButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
		sitButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
		upGradeButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
		geneButton.GetComponent<EventDispatcher>().Hover += overTipFunc;
		
		roleButton.GetComponent<EventDispatcher>().Press += pressBtnFunc;
		packButton.GetComponent<EventDispatcher>().Press += pressBtnFunc;;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void overTipFunc(GameObject go,bool isOver)
	{
		if(isOver)
		{
			string tipStr = "None";
			if(go.name == deplayButton.name)
			{
			    tipStr = "buZhen";
			}else if(go.name == factionButton.name)
			{
				 tipStr = "bangPai";
			}else if(go.name == friendButton.name)
			{
				tipStr = "haoYou";
			}else if(go.name == packButton.name)
			{
			    tipStr = "beiBao";
			}else if(go.name == qiButton.name)
			{
				tipStr = "lieMing";
			}else if(go.name == roleButton.name)
			{
				 tipStr = "jueSe";
			}else if(go.name == sitButton.name)
			{
				 tipStr = "daZuo";
			}else if(go.name == geneButton.name)
			{
				tipStr = "gene";
			}else if(go.name == partnerButton.name)
			{
				tipStr = "jiangXingLu";
			}else if(go.name == upGradeButton.name)
			{
				 tipStr = "qiangHua";
			} 
			 
			TipManager.getInstance().createMouseTip(tipStr,"Anchor");
		}else
		{
			TipManager.getInstance().destroyMouseTip();
		}
	}
	
	void pressBtnFunc(GameObject go,bool ispress)
	{
		if(ispress == true)
		{
			if(go.name == roleButton.name)
			{
				PanelManager.instance.AddPanel(PanelNameConst.ROLE_INFO_PANEL);
			}else if(go.name == packButton.name)
			{
				PanelManager.instance.AddPanel(PanelNameConst.PACK_PANEL);
			}
			
			TipManager.getInstance().destroyMouseTip();
		}
	}
	
}
