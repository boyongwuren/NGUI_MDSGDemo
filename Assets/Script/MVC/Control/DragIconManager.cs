using UnityEngine;
using System.Collections;

public class DragIconManager  
{
	public delegate void NGUIHanderDrop(ItemVo vo);
	
	public Transform DragPanel;
	
	public Camera ca;

    private static DragIconManager _instance;
	
	private ItemVo _dragVo;
	
	private UIAtlas _curAtlas;
	
	private GameObject _dragGo;
	
	private bool _needUpData = false;
	
	public static DragIconManager instance
	{
		get 
		{
			if(_instance == null)
			{
				_instance = new DragIconManager();
			}
			
			return _instance;
		}
		
		set
		{
			
		}
	}
	
	
	
	public bool needUpData
	{
		get
		{
			return _needUpData;
		}
		
		set 
		{
			_needUpData = value;
		}
	}
	

	
	public void SetDragInfo(ItemVo vo,UIAtlas atlas)
	{
		_dragVo = vo;
		
		_curAtlas = atlas;
		
		_dragGo = new GameObject();
		_dragGo.transform.parent = DragPanel;
		_dragGo.name = "DragGo";
		_dragGo.layer = 8;
		
		Debug.Log("_curAtlas = "+_curAtlas);
		UISprite sprite = _dragGo.AddComponent<UISprite>();
		sprite.atlas = _curAtlas;
		sprite.spriteName = _dragVo.id+"";
		sprite.MakePixelPerfect();
		UpData();
		
		needUpData = true;
		
	}
	
	
	
	public void UpData()
	{
		if(needUpData)
		{
			Vector3 positon = ca.ScreenToWorldPoint(Input.mousePosition);
			_dragGo.transform.position = positon;
			positon = _dragGo.transform.localPosition;
			_dragGo.transform.localPosition = new Vector3(positon.x,positon.y,0);
			
			if(Input.GetKeyUp(KeyCode.Mouse0))
			{
				StopDrag();
			}
		}
		
	}
	
	public event NGUIHanderDrop DropItemFunc;
	
	private void StopDrag()
	{
		needUpData = false;
		GameObject.Destroy(_dragGo);
		
		if(DropItemFunc != null)
		{
			DropItemFunc(_dragVo);
		}
	}

	
}
