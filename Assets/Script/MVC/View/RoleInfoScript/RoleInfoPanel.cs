using UnityEngine;
using System.Collections;

public class RoleInfoPanel : MonoBehaviour {
	
	public EquipContent equipContent;
	
	private ArrayList _evos;
	
	public UISlider expSlider;
	
	public LabelContent labelContent;
	
	public RoleItemContent roleContent;
	
	// Use this for initialization
	void Start () 
	{
		roleContent.Roles = TempDataFactroy.createRoles();
		
		roleContent.ChangeSelectItem += HandleRoleContentChangeSelectItem;
		
		HandleRoleContentChangeSelectItem((BaseVo)roleContent.Roles[1]);
		
		DragIconManager.instance.DropItemFunc += DropItemFunc;
	}

	void HandleRoleContentChangeSelectItem (BaseVo vo)
	{
		labelContent.Bvo = vo;
		 
		expSlider.sliderValue = (float)(vo.exp/vo.maxExp);
		equipContent.Evos = TempDataFactroy.createEquip();
		roleContent.selectItem(vo);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	private void DropItemFunc(ItemVo vo)
	{
		if(CameraTool.instance.mouseIsInGo(gameObject))
		{
			if(HasThisItem(vo) == false)
			{
				if(vo.isEquip == true)
				{
					
				}else
				{
					TipManager.getInstance().CreateTipPanel("该物品不是装备类型，不能穿戴");
				}
			}
		}else
		{
			
		}
	}
	
	
	private bool HasThisItem(ItemVo checkVo)
	{
		for(int i = 0;i<_evos.Count;i++)
		{
			ItemVo vo = (ItemVo)_evos[i];
			if(vo.id == checkVo.id)
			{
				return true;
			}
		}
		
		return false;
	}
	
	
	
	
}
