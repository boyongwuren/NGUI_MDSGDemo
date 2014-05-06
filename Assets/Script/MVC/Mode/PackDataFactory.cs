using UnityEngine;
using System.Collections;

public class PackDataFactory 
{
 
	private static PackDataFactory _instance;
	
	private ArrayList _items = new ArrayList();
	
	private int _openLen;
 
	
	public static PackDataFactory instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = new PackDataFactory();
			}
			return _instance;
		}
		
		set
		{
			
		}
	}
	
	
	public ArrayList createPackData()
	{
		_openLen = Random.Range(0,36);
		
		int i = 0;
		ArrayList gridIndexs = new ArrayList();
		for(i = 0;i<_openLen;i++)
		{
			gridIndexs.Add(i);
		}
		
		_items = new ArrayList();
		
		int itemLen = Random.Range(0,_openLen);
		
		for(i = 0;i<itemLen;i++)
		{
			ItemVo vo = new ItemVo();
			vo.id = Random.Range(ItemRang.ITEM_START_INDEX,ItemRang.ITEM_END_INDEX);
			
			int itemGridIndex = Random.Range(0,gridIndexs.Count-1);
			
			int itemGrid = (int)gridIndexs[itemGridIndex];
			
			gridIndexs.RemoveAt(itemGridIndex);
			
			vo.itemGrid = itemGrid;
			vo.id = ItemIDRang.PACK_ITEM_ID_START + i; 
			
			_items.Add(vo);
		}
		
		return _items;
	}
	
	public int packOpenLen()
	{
		return _openLen;
	}
	
	
	
}
