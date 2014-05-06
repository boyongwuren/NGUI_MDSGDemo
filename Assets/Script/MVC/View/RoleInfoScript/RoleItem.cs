using UnityEngine;
using System.Collections;

public class RoleItem : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	public Transform selectSpr;
	
	public Transform noSelectSpr;
	
	public UILabel label;
	
	public BaseVo vo;
	
	private bool isSelect;
	
	void Start () 
	{
	    IsSelect = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public bool IsSelect
	{
		get
		{
			return isSelect;
		}
		
		set 
		{
			isSelect = value;
			
			NGUITools.SetActive(noSelectSpr.gameObject,!isSelect);
	        NGUITools.SetActive(selectSpr.gameObject,isSelect);
		}
	}
	
	public BaseVo Evo
	{
		get 
		{
			return vo;
		}
		
		set 
		{
			vo = value;
			
			label.text = vo.name;
		}
	}
}
