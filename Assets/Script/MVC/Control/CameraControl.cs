using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	public Transform DragPanel;
	
	public Transform UIPanelParent;
	
	public Transform TipPanelParent;
	
	void Start () 
	{
	   DragIconManager.instance.DragPanel = DragPanel;
	   DragIconManager.instance.ca = camera;
	   CameraTool.instance.ca = camera;
	   PanelManager.instance.parentPanel = UIPanelParent;
	   TipManager.getInstance().TipPanelParent = TipPanelParent;
	}
	
	//Update is called once per frame
	void Update () 
	{
	    DragIconManager.instance.UpData();
	}
}
