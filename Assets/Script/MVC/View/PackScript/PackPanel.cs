using UnityEngine;
using System.Collections;

public class PackPanel : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	public GameObject itemContent;
	
	public GameObject lockContent;
	
	public UILabel maxContent;
	
	public EventDispatcher closeBtn;
	
	public EventDispatcher zhengLiBtn;
	
	private int _packOpenLen;
	
	private ArrayList _items;
	
	private ArrayList _itemSpss;
	
	public static Camera ca;
	
	private  int CELL_WIDTH = 52;
	
	private  int CELL_HEIGH = 53;
	
	private int MAX_PER_LINE = 6;
	
	private const int FULL_PACK = -1;
	
	void Start () 
	{
	    _items = PackDataFactory.instance.createPackData();
		_packOpenLen = PackDataFactory.instance.packOpenLen();
		
		PackOpenLen();
		
		renderItems();
		
		closeBtn.Press += ClickCloseFunc;
		zhengLiBtn.Press += ZhengLiFunc;
		
		DragIconManager.instance.DropItemFunc += DropItemFunc;
		
	}


	// Update is called once per frame
	void Update ()
	{
	 
	}
	
	private void ClickCloseFunc(GameObject go,bool isPress)
	{
	   PanelManager.instance.RemovePanel(PanelNameConst.PACK_PANEL);
	}
	
	void OnDestroy()
	{
		closeBtn.Press -= ClickCloseFunc;
		zhengLiBtn.Press -= ZhengLiFunc;
		DragIconManager.instance.DropItemFunc -= DropItemFunc;
	}
	
	
	
	private void ZhengLiFunc(GameObject go,bool isPress)
	{
		for(int i = 0;i<_items.Count;i++)
		{
			ItemVo vo = _items[i] as ItemVo;
			vo.itemGrid = i;
		}
		
		renderItems();
	}
	
	
	
	private void renderItems()
	{
		deleteItems();
		 
		
		Object o = Resources.Load("BaseItem");
		GameObject go;
		for(int i = 0;i<_items.Count;i++)
		{
			ItemVo vo = _items[i] as ItemVo;
			go = Instantiate(o) as GameObject;
			
			Vector3 initPositon = go.transform.localPosition;
			Vector3 initScale = go.transform.localScale;
			
			BaseItem bi = go.GetComponent<BaseItem>();
			bi.itemVo = vo;
			
			go.transform.parent = itemContent.transform;
			go.transform.localScale = initScale;
			go.transform.localPosition = initPositon;
			
			int tempy = (int)vo.itemGrid/MAX_PER_LINE;
			int tempx = vo.itemGrid%MAX_PER_LINE;
			
			go.transform.localPosition = new Vector3(tempx*CELL_WIDTH,-tempy*CELL_HEIGH,initPositon.z);
			
			_itemSpss.Add(go);
		}
		
		//UIGrid g = itemContent.GetComponent<UIGrid>();
		//g.repositionNow = true;
	}
	
	private void deleteItems()
	{
		if(_itemSpss != null)
		{
			for(int i = 0;i<_itemSpss.Count;i++)
			{
				Destroy((GameObject)_itemSpss[i]);
			}
		}
		
		
		_itemSpss = new ArrayList();
	}
	
	private void PackOpenLen()
	{
		int i = 0;
		Transform tf;
		for(i =0 ;i<lockContent.transform.childCount;i++)
		{
			tf = lockContent.transform.GetChild(i);
			
			tf.gameObject.active = true;
		}
		
		for(i = 0;i<_packOpenLen;i++)
		{
			tf = lockContent.transform.GetChild(i);
			
			tf.gameObject.active = false;    
		}
		
		ItemLenAndOpenLen();
	}
	
	private void ItemLenAndOpenLen()
	{
		maxContent.text = "背包容量"+_items.Count+"/"+_packOpenLen;
	}
	
	void DropItemFunc(ItemVo vo)
	{
		if(CameraTool.instance.mouseIsInGo(gameObject))
		{
			print("mous is in panel inner");
			GameObject orilgGo;
			
			orilgGo = hasItemInPack(vo);
			
			if(orilgGo != null)
			{
				Vector3 mousePostion = CameraTool.instance.MousePosition();
				mousePostion = itemContent.transform.InverseTransformPoint(mousePostion);
				
				print("mousePostionmousePostion = "+mousePostion);
				if(mousePostion.x>-CELL_WIDTH/2&&mousePostion.x<MAX_PER_LINE*CELL_WIDTH&&mousePostion.y<CELL_HEIGH/2&&mousePostion.y>-MAX_PER_LINE*CELL_HEIGH)
				{
					print("mouseUp is in ItemContent ");
					
					int cellX = (int)Mathf.Ceil((mousePostion.x+CELL_WIDTH/2)/CELL_WIDTH);
					int cellY =  (int)Mathf.Ceil((Mathf.Abs(mousePostion.y)+CELL_HEIGH/2)/CELL_HEIGH);
					
					 
					 
					print("cellX = "+cellX+"  cellY= "+cellY);
					
					int clickLen = (cellY-1)*MAX_PER_LINE+cellX; 
					
					if(clickLen>_packOpenLen)
					{
						print("not open grid ");
					}else
					{
						print("clickLen = "+clickLen+"  childCount = "+_itemSpss.Count);
						
						GameObject switchGo = findItemSprInGrid(clickLen-1);
						orilgGo = findItemSprInGrid(vo.itemGrid);
						if(switchGo != null)
						{
							print("switch grid");
							ItemVo switchVo = switchGo.GetComponent<BaseItem>().itemVo;
							int switchGrid = switchVo.itemGrid;
							switchVo.itemGrid = vo.itemGrid;
							vo.itemGrid = switchGrid;
							
							setPositon(switchGo,switchVo.itemGrid);
							setPositon(orilgGo,vo.itemGrid);
								
								
						}else
						{
							print("change grid position");
							vo.itemGrid = clickLen-1;
							setPositon(orilgGo,vo.itemGrid);
						}
					}
					
				}else 
				{
					print("mouseUp not in ItemContent");
					//delete item 
				}
			}else
			{
				//addItem
				print("addItem");
				AddItem(vo);
				
			}
			

		}else 
		{
			//delete item
			print("delete item");
			deleteItem(vo);
		}
	}
	
	private GameObject findItemSprInGrid(int grid)
	{
		GameObject go;
		ItemVo vo;
		for(int i = 0;i<_itemSpss.Count;i++)
		{
			go = (GameObject)_itemSpss[i];
			vo = go.GetComponent<BaseItem>().itemVo;
			if(vo.itemGrid == grid)
			{
				return go;
			}
		}
		
		return null;
	}
	
	
	private GameObject hasItemInPack(ItemVo findVo)
	{
		GameObject go;
		ItemVo vo;
		for(int i = 0;i<_itemSpss.Count;i++)
		{
			go = (GameObject)_itemSpss[i];
			vo = go.GetComponent<BaseItem>().itemVo;
			if(vo.id == findVo.id)
			{
				return go;
			}
		}
		
		return null;
	}
	
	private void AddItem(ItemVo addVo)
	{
		int index = FindEmpetGridIndex();
		if(index == FULL_PACK)
		{
			//pack is full
			print("pack is full");
			TipManager.getInstance().CreateTipPanel("背包满，无法添加物品");
		}else
		{
			addVo.itemGrid = index;
		   _items.Add(addVo);
		   renderItems();
			
			ItemLenAndOpenLen();
		}
		
	}
	
	private void deleteItem(ItemVo deleteVo)
	{
		if(hasItemInPack(deleteVo) != null)
		{
		   _items.Remove(deleteVo);
		   renderItems();
			ItemLenAndOpenLen();
			TipManager.getInstance().CreateTipPanel("删除物品成功!!");
		}
	
	}
	
	
	private void setPositon(GameObject go,int grid)
	{
		int tempy = (int)grid/MAX_PER_LINE;
	    int tempx = grid%MAX_PER_LINE;
		go.transform.localPosition = new Vector3(tempx*CELL_WIDTH,-tempy*CELL_HEIGH,go.transform.localPosition.z);
	}
	
	private int FindEmpetGridIndex()
	{
		for(int i = 0;i<_packOpenLen;i++)
		{
		   GameObject go = findItemSprInGrid(i);
			if(go == null)
			{
				return i;
			}
		}
		
		return FULL_PACK;
		
	}
	
	
}
