using UnityEngine;
using System.Collections;

public class PanelManager 
{

   private static PanelManager _instance;
	
	public static PanelManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = new PanelManager();
			}
			
			return _instance;
		}
	}
	
	
	private Hashtable panelTabel = new Hashtable();
	private Hashtable panelIsShow = new Hashtable();
	public Transform parentPanel;
	
	public void AddPanel(string panelName)
	{
		Debug.Log("panelName = "+panelName);
		GameObject panel;
		panel = (GameObject)panelTabel[panelName];
		if(panel != null)
		{
			if(panelIsShow.Contains(panelName))
			{
				bool isShow = (bool)panelIsShow[panelName];
				if(isShow)
				{
					//hidePanel
					DoRemovePanel(panel,panelName);
				}else
				{
					//showpanel
					//panelparentPanel.transform;
				}
			}
		}else
		{
			GameObject originalGo = null;
			
			if(panelName == PanelNameConst.ROLE_INFO_PANEL)
			{
				Debug.Log("add role info panel see see");
				originalGo = Resources.Load(URLConst.ROLE_INFO_URL,typeof(GameObject)) as GameObject;

			}else if(panelName == PanelNameConst.PACK_PANEL)
			{
				originalGo = Resources.Load(URLConst.PACK_URL,typeof(GameObject)) as GameObject;
			}
			
				if(originalGo != null)
				{
					Debug.Log("role info panel is not null");
					panel = NGUITools.AddChild(parentPanel.gameObject,originalGo);
				    panel.transform.localPosition = originalGo.transform.localPosition;
					panel.transform.localScale = new Vector3(1,1,1);
					panelIsShow.Add(panelName,true);
					panelTabel.Add(panelName,panel);
				}
			
		}
	}
	
	public void RemovePanel(string panelName)
	{
		GameObject panel = (GameObject)panelTabel[panelName];
		if(panel != null)
		{
			DoRemovePanel(panel,panelName);
		}
	}
	
	private void DoRemovePanel(GameObject panel,string panelName)
	{
		GameObject.Destroy(panel);
		panelIsShow.Remove(panelName);
		panelTabel.Remove(panelName);
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
