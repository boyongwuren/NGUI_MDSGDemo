using UnityEngine;
using System.Collections;

public class CameraTool 
{

    private static CameraTool _instance;
	
	public Camera ca;
	
	public static CameraTool instance
	{
		get 
		{
			if(_instance == null)
			{
				_instance = new CameraTool();
			}
			
			return _instance;
		}
		
		set
		{
			
		}
	}
	
	
	public bool mouseIsInGo(GameObject go)
	{
		Vector3 postion = ca.ScreenToWorldPoint(Input.mousePosition);
		Vector3 panelPosition = go.transform.position;
		
		Bounds b = NGUIMath.CalculateAbsoluteWidgetBounds(go.transform);
		
		if(postion.x>b.center.x-b.extents.x&&postion.x<b.center.x+b.extents.x&&postion.y>b.center.y-b.extents.y&&postion.y<b.center.y+b.extents.y)
		{
			return true;
		}
		
		return false;
	}
	
	
	public Vector3 MousePosition()
	{
		return ca.ScreenToWorldPoint(Input.mousePosition);
	}
	
	
	
}
