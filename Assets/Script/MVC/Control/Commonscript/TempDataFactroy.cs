using UnityEngine;
using System.Collections;

public class TempDataFactroy 
{

//中文注释
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static ArrayList createRoles()
	{
		ArrayList roles = new ArrayList();
		
		BaseVo vo = new BaseVo();
		vo.name = "item_0";
		vo.id = 0;
		vo.magicId = 981111;
		vo.exp = 11;
		roles.Add(vo);
		
		 
		vo = new BaseVo();
		vo.name = "item_1";
		vo.id = 1;
		vo.magicId = 780010;
		vo.exp = 130;
		roles.Add(vo);
		
		vo = new BaseVo();
		vo.name = "item_2";
		vo.id = 2;
		roles.Add(vo);
		
		vo = new BaseVo();
		vo.name = "item_3";
		vo.id = 3;
		vo.magicId = 784520;
		vo.exp = 190;
		roles.Add(vo);
		
		vo = new BaseVo();
		vo.name = "item_4";
		vo.id = 4;
		vo.magicId = 412510;
		vo.exp = 72;
		roles.Add(vo);
		
		vo = new BaseVo();
		vo.name = "item_5";
		vo.id = 5;
		vo.magicId = 789410;
		vo.exp = 58;
		roles.Add(vo);
		
		vo = new BaseVo();
		vo.name = "item_6";
		vo.id = 6;
		vo.exp = 150;
		vo.magicId = 541000;
		roles.Add(vo);
		
		vo = new BaseVo();
		vo.name = "item_7";
		vo.id = 7;
		vo.exp = 100;
		vo.magicId = 800100;
		roles.Add(vo);
		
		vo = new BaseVo();
		vo.name = "item_8";
		vo.id = 8;
		vo.magicId = 100300;
		roles.Add(vo);
		
		vo = new BaseVo();
		vo.name = "item_9";
		vo.id = 9;
		vo.magicId = 100200;
		vo.exp = 90;
		roles.Add(vo);
		
		vo = new BaseVo();
		vo.name = "item_10";
		vo.id = 10;
		vo.magicId = 100500;
		roles.Add(vo);
		
		return roles;
	}
	
	
	public static EquipVo[] createEquip()
	{
		ArrayList id = new ArrayList();
		id.Add(100002);
		id.Add(100100);
		id.Add(100107);
		id.Add(100200);
		id.Add(100205);
		id.Add(100300);
		id.Add(100304);
		id.Add(100400);
		id.Add(100402);
		id.Add(101100);
		id.Add(101200);
		id.Add(101300);
		id.Add(101307);
		id.Add(101003);
		id.Add(101005);
		
		System.Random r = new System.Random();
		int index = 0;
		
		 EquipVo vo1 = new EquipVo();
		
         index = (int)r.Next(0,id.Count);		
	     vo1.id = (int)id[index];
		 id.RemoveAt(index);
	
		  EquipVo vo2 = new EquipVo();
	       index = (int)r.Next(0,id.Count);		
	     vo2.id = (int)id[index];
		 id.RemoveAt(index);
		
		  EquipVo vo3 = new EquipVo();
	       index = (int)r.Next(0,id.Count);		
	     vo3.id = (int)id[index];
		 id.RemoveAt(index);
		
		  EquipVo vo4 = new EquipVo();
	       index = (int)r.Next(0,id.Count);		
	     vo4.id = (int)id[index];
		 id.RemoveAt(index);
		
		  EquipVo vo5 = new EquipVo();
	      index = (int)r.Next(0,id.Count);		
	     vo5.id = (int)id[index];
		 id.RemoveAt(index);
		
		  EquipVo vo6 = new EquipVo();
	       index = (int)r.Next(0,id.Count);		
	     vo6.id = (int)id[index];
		 id.RemoveAt(index);
	
		  EquipVo [] evos = {vo1,vo2,vo3,vo4,vo5,vo6};
		 
		  return evos;
	}
}
