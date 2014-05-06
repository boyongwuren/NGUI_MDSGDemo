using UnityEngine;
using System.Collections;

public class LabelContent : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	public UILabel liftLabel;
	
	public UILabel wlLabel;
	
	public UILabel clLabel;
	
	public UILabel zyLabel;
	
	public UILabel jgLabel;
	
	public UILabel mjLabel;
	
	public UILabel wfLabel;
	
	public UILabel cfLabel;
	
	public UILabel jjLabel;
	
	private BaseVo vo;
	
	public BaseVo Bvo
	{
		get
		{
			return vo;
		}
		
		set
		{
			vo = value;
			
			Lift = vo.life+"";
			WuGong = vo.wuGongNum+"";
			CeGong = vo.ceGongNum+"";
			ZhiYe = RoleProfession.getProNameByType(vo.roleType);
			JunGong = vo.junGongNum+"";
			MinJie = vo.minJieNum+"";
			WuFang = vo.wuFangNum+"";
			CeFang = vo.ceFangNum+"";
			JueJi = vo.magicId+"";
		}
	}
	
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public string Lift
	{
		get 
		{
			return "";
		}
		
		set 
		{
			liftLabel.text = value;
		}
	}
	
	public string WuGong
	{
		get
		{
			return "";
		}
		
		set 
		{
			wlLabel.text = value;
		}
	}
	
	public string CeGong
	{
		get
		{
			return "";
		}
		
		set 
		{
			clLabel.text = value;
		}
	}
	
	public string ZhiYe
	{
		get
		{
			return "";
		}
		
		set 
		{
			zyLabel.text = value;
		}
	}
	
    public string JunGong
	{
		get
		{
			return "";
		}
		
		set 
		{
			jgLabel.text = value;
		}
	}
	
	public string MinJie
	{
		get
		{
			return "";
		}
		
		set 
		{
			mjLabel.text = value;
		}
	}
	
	public string WuFang
	{
		get
		{
			return "";
		}
		
		set 
		{
			wfLabel.text = value;
		}
	}
	
	public string CeFang
	{
		get
		{
			return "";
		}
		
		set 
		{
			cfLabel.text = value;
		}
	}
	
	public string JueJi
	{
		get
		{
			return "";
		}
		
		set 
		{
			jjLabel.text = value;
		}
	}
}
