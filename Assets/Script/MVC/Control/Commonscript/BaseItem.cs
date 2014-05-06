using UnityEngine;
using System.Collections;

public class BaseItem : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	private ItemVo _itemVo;
	
	protected Transform lightSpr;
	
	private GameObject iconParent;
	
	private UISprite iconSpr;
	
	private EventDispatcher ed;
	
	private UIWidget[] wis;
	
	private Color initColor;
	
	private bool isDrag = false;
	
	private UIAtlas _curAtlas;
	
	void Start () 
	{
	    lightSpr = transform.FindChild("lightSpr");  
	    NGUITools.SetActive(lightSpr.gameObject,false);
		ed = transform.GetComponent<EventDispatcher>();
		ed.Drag += DragFunc;
		ed.Drop += DropFunc;
		ed.Press += PressFunc;
		
		wis = transform.GetComponentsInChildren<UIWidget>();
		initColor = wis[0].color;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public ItemVo itemVo
	{
		get 
		{
			return _itemVo;
		}
		
		set
		{
			_itemVo = value;
			
			if(iconParent == null)
			{
				_curAtlas = Resources.Load(URLConst.ITEM_URL,typeof(UIAtlas)) as UIAtlas;
				iconParent = new GameObject();
				iconParent.layer = 8;
				iconParent.transform.parent = transform; 
				iconSpr = iconParent.AddComponent<UISprite>();
				iconSpr.atlas = _curAtlas;
				
				iconParent.transform.localPosition = new Vector3(0,0,-1);
			}
			
			
			iconSpr.spriteName = _itemVo.id+""; 
			iconSpr.MakePixelPerfect();
		}
	}
	
	public void OnHover (bool isOver)
	{
		NGUITools.SetActive(lightSpr.gameObject,isOver);
	}
	
	private void DragFunc(GameObject go,Vector2 o)
	{
		if(isDrag == false)
		{
			isDrag = true;
			print("has aways drag?");
		    for(int i = 0;i<wis.Length;i++)
			{
				wis[i].color = Color.gray;
			}	
			
			 DragIconManager.instance.SetDragInfo(itemVo,_curAtlas);
			
		}
		
	}
	
	private void DropFunc(GameObject go,GameObject o)
	{
		for(int i = 0;i<wis.Length;i++)
		{
			wis[i].color = initColor;
		}
	}
	
	private void PressFunc(GameObject go,bool isPress)
	{
		if(!isPress)
		{
			print("isPress == fasle;");
			for(int i = 0;i<wis.Length;i++)
			{
				wis[i].color = initColor;
			}
			
			isDrag = false;
		}
	}
}
