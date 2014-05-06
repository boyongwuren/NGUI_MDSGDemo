using UnityEngine;
using System.Collections;

public class ItemVo
{
	private int _id = 0;
	
	public int id
	{
		get 
		{
			return _id;
		}
		
		set 
		{
			_id = value;
			
			if(_id>=ItemRang.EQUIP_START_INDEX&&_id<=ItemRang.EQUIP_END_INDEX)
			{
				isEquip = true;
			}
		}
	}
	
	public int itemNum = 0;
	
	//item in pack position
	public int itemGrid = 0;
	
	public bool isEquip = false;
}
