using UnityEngine;
using System.Collections;

public class RoleItemContent : MonoBehaviour 
{

//中文注释
	// Use this for initialization
	
	public delegate void ChangeSelectItemHandler(BaseVo vo);
	public event ChangeSelectItemHandler ChangeSelectItem;
	
	private const int showLen = 10;
	
	private ArrayList roles;
	
	private ArrayList roleItems;
	
	private int curPage = 0;
	
	private int maxPage = 0;
	
	public UIImageButton upBtn;
	
	public UIImageButton downBtn;
	
	void Start () 
	{
	   upBtn.GetComponent<EventDispatcher>().Press += upPress;
	   downBtn.GetComponent<EventDispatcher>().Press += downPress;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public ArrayList Roles
	{
		get 
		{
			return roles;
		}
		
		set
		{
			roles = value;
			
			//print("roleItem set value ");
			curPage = 1;
			maxPage = (int)roles.Count/showLen+1;
			
			renderItem(); 
		}
	}
	
	private void renderItem()
	{
		int i;
		if(roleItems != null)
		{ 
			for(i = 0;i<roleItems.Count;i++)
			{
				GameObject tempGo = (GameObject)roleItems[i];
				tempGo.GetComponent<EventDispatcher>().Press -= roleItemClick;
				Destroy(tempGo);
			}
		}
		
		//print("begin render roleItem");
		roleItems = new ArrayList();
		
		int startIndex = (curPage-1)*showLen;
		int endIndex = curPage*showLen;
		if(endIndex>roles.Count)
		{
			endIndex = roles.Count;
		}
		
		BaseVo[] tempList = new BaseVo[showLen];
		
		//print("endIndex - startIndex = "+(endIndex - startIndex));
		roles.CopyTo(startIndex,tempList,0,endIndex - startIndex);
		
		int itemHeight = 35;
		for(i = 0;i<endIndex - startIndex;i++)
		{
			GameObject roleItem = (GameObject)Instantiate(Resources.Load("Prefab/roleItem",typeof(GameObject)) as GameObject);
			RoleItem ri = roleItem.GetComponent<RoleItem>();
			object tempo = tempList[i];
			ri.Evo = (BaseVo)tempo;
			  
			roleItem.transform.parent = transform;
			roleItem.transform.localScale = new Vector3(1,1,1);
			roleItem.transform.localPosition = new Vector3(0,itemHeight*i*-1,0);
			
			roleItems.Add(roleItem);
			roleItem.GetComponent<EventDispatcher>().Press += roleItemClick;
		}
		
	}
	
	private void roleItemClick(GameObject go,bool isPress)
	{
		if(isPress)
		{
			//hideAll();
			RoleItem roleItem = go.GetComponent<RoleItem>();
			//roleItem.IsSelect = true;
			if(ChangeSelectItem != null)
			{
				ChangeSelectItem(roleItem.Evo);
			}
		}
	}
	
	private void hideAll()
	{
		 
		for(int i = 0;i<roleItems.Count;i++)
		{
			GameObject go = (GameObject)roleItems[i];
			RoleItem roleItem = go.GetComponent<RoleItem>();
			roleItem.IsSelect = false;
		}
	}
	
	public void selectItem(BaseVo vo)
	{
		hideAll();
		for(int i = 0;i<roleItems.Count;i++)
		{
			GameObject go = (GameObject)roleItems[i];
			RoleItem ritem = go.GetComponent<RoleItem>();
			if(vo.id == ritem.Evo.id)
			{
				 
				ritem.IsSelect = true;
				return;
			}
		}
	}
	
	public void upPress(GameObject go,bool isPress)
	{
		if(isPress)
		{
			curPage--;
			if(curPage<1)
			{
				curPage = 1;
			}
			
			renderItem();
		}
	}
	
	public void downPress(GameObject go,bool isPress)
	{
		if(isPress)
		{
			curPage++;
			if(curPage>maxPage)
			{
				curPage = maxPage;
			}
			 
			renderItem();
		}
	}
}
