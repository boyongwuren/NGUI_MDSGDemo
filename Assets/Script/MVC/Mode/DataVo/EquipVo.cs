using UnityEngine;
using System.Collections;

public class EquipVo : ItemVo 
{
	private int equipType = 0;
	
	 public void CaulateEquipType()
	{
		if(id>=ItemRang.BINGFU_STAER&&id<ItemRang.BINGFU_END)
		{
			equipType = EquipType.BINGFU;
		}else if(id>=ItemRang.TOUKUI_STAER&&id<ItemRang.TOUKUI_END)
		{
			equipType = EquipType.TOUKUI;
		}else if(id>=ItemRang.WUPIN_STAER&&id<ItemRang.WIPIN_END)
		{
			equipType = EquipType.WUPIN;
		}else if(id>=ItemRang.XINGHUN_STAER&&id<ItemRang.XINGHUN_END)
		{
			equipType = EquipType.XINGHUN;
		}else if(id>=ItemRang.ZHANJIA_STAER&&id<ItemRang.ZHANJIA_END)
		{
			equipType = EquipType.ZHANJIA;
		}else if(id>=ItemRang.ZHANXUE_STAER&&id<ItemRang.ZHANXUE_END)
		{
			equipType = EquipType.ZHANXUE;
		}
	}
	 
}
