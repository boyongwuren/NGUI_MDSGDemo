using UnityEngine;
using System.Collections;

public class EquipItem : BaseItem {

	// Use this for initialization
   
	
	private EquipVo evo;
	 
	
	//override void Start()
	//{
		
	//}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public EquipVo Evo
	{
		get
		{
			return evo;
		}
		
		set
		{
			evo = value;
		 
			itemVo = value;
		}
	}
	

	
}
