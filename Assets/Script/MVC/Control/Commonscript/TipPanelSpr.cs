using UnityEngine;
using System.Collections;

public class TipPanelSpr : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	public UILabel content;
	
	public EventDispatcher sureBtn;
	
	void Start () 
	{
	   sureBtn.Press += sureBtnFunc;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void ShowText(string str)
	{
		content.text = str;
	}
	
	private void sureBtnFunc(GameObject go,bool isPress)
	{
		if(isPress)
		{
			sureBtn.Press -= sureBtnFunc;
			Destroy(gameObject);
		}
	}
}
