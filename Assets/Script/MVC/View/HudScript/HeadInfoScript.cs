using UnityEngine;
using System.Collections;

public class HeadInfoScript : MonoBehaviour {
	
	public UILabel levelLable;
	
	public UILabel nameLabel;
	
	public UILabel lifeLabel;
	
	public UILabel tiLiLabel;
	
	public UILabel MoneyLabel;
	
	public UILabel EMoneyLanel;
	
	public UILabel ZEMoneyLabel;
	
	public UISprite VipSpr;
	
	public UITexture headIcon;
	
	private UserVo uvo;
	
	
	// Use this for initialization
	void Start () 
	{
	    uvo = new UserVo();
		
		levelLable.text = uvo.level+"";
		
		nameLabel.text = uvo.name;
		
		lifeLabel.text = uvo.life+"";
		
		tiLiLabel.text = uvo.tiLiNum+"";
		
		MoneyLabel.text = uvo.money+"";
		
		EMoneyLanel.text = uvo.emoney+"";
		
		ZEMoneyLabel.text = uvo.zEmoney+"";
		
		MoneyLabel.GetComponent<EventDispatcher>().Hover += moneyLabelHover;
		
		EMoneyLanel.GetComponent<EventDispatcher>().Hover += moneyLabelHover;
		
		ZEMoneyLabel.GetComponent<EventDispatcher>().Hover += moneyLabelHover;
		
		if(uvo.vipLevel>0)
		{
			NGUITools.SetActive(VipSpr.gameObject,true);
			
			VipSpr.spriteName = "vip"+uvo.vipLevel;
			
		}else
		{
			NGUITools.SetActive(VipSpr.gameObject,false);
		}
		
		//print("init loader pic"+Application.dataPath);
		//StartCoroutine(LoadManager.LoadBitMap("http://images.earthcam.com/ec_metros/ourcams/fridays.jpg",headPicLoadOver));
		//StartCoroutine(LoadManager.LoadBitMap("file://" + Application.dataPath + "/../pic/icon/head/1.png",headPicLoadOver));
		 
	}
	
	public void headPicLoadOver(Texture2D pic)
	{
		//print("loaderPicOver = " + pic.ToString());
		//headIcon.renderer.material.mainTexture = pic;
		headIcon.material.mainTexture = pic; 
		headIcon.MakePixelPerfect();
	}
	
	private void moneyLabelHover(GameObject go,bool isOver)
	{
		if(isOver)
		{ 
			string tipStr = "None";
			
			if(go.name == MoneyLabel.name)
			{
				tipStr = "TongQian";
			}else if(go.name == EMoneyLanel.name)
			{
				tipStr = "YuanBao";
			}else if(go.name == ZEMoneyLabel.name)
			{
				tipStr = "Zeng";
			}
			
		    TipManager.getInstance().createMouseTip(tipStr,"Anchor");
		}else
		{
			TipManager.getInstance().destroyMouseTip();
		}
	    
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
}
