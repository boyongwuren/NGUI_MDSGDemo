using UnityEngine;
using System.Collections;

public class TipManager{

	// Use this for initializatio
	
	private MouseTip CloneMouseTip;
	
	TipManager()
	{	
		 
	}
 
	private static TipManager _instance;
	
	public static TipManager getInstance()
	{
		if(_instance == null)
		{
			//Debug.Log("instance ok ");
			_instance = new TipManager();
		}
		
		return _instance;
	}
	
	public MouseTip createMouseTip(string str,string parentName)
	{
		GameObject go = (GameObject)GameObject.Instantiate(Resources.Load("Prefab/MouseTip"));
		CloneMouseTip = go.GetComponent<MouseTip>();
		
		CloneMouseTip.setTipString(str);
		
		GameObject parentPanel = GameObject.Find(parentName);
		
		CloneMouseTip.transform.parent = parentPanel.transform;
		
		CloneMouseTip.transform.localScale = new Vector3(1,1,1);
		
		return CloneMouseTip;
	}
	
	public void destroyMouseTip()
	{
		if(CloneMouseTip)
		{
			GameObject.Destroy(CloneMouseTip.gameObject);
		}
	}
	
	
	public Transform TipPanelParent;
	
	public void CreateTipPanel(string msg)
	{
		GameObject prefab = Resources.Load(URLConst.TIP_PANEL_SPR,typeof(GameObject)) as GameObject;
		GameObject tipPanel = NGUITools.AddChild(TipPanelParent.gameObject, prefab);
		tipPanel.transform.localScale = prefab.transform.localScale;
		tipPanel.transform.localPosition = prefab.transform.localPosition;
		
		TipPanelSpr tps = tipPanel.GetComponent<TipPanelSpr>();
		tps.ShowText(msg);
	}
	
	
	
	 
}
