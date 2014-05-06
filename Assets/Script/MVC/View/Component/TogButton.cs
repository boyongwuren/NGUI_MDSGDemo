using UnityEngine;
using System.Collections;

public class TogButton : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	public UIImageButton openBtn;
	
	public UIImageButton closeBtn;
	
	private bool isOpen = true;
	
	void Start () 
	{
	   setIsOpen(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void setIsOpen(bool b)
	{
//		print("isOpen = "+isOpen);
		isOpen = b;
		NGUITools.SetActive(openBtn.gameObject,b);
		NGUITools.SetActive(closeBtn.gameObject,!b);
	}
	
	public bool getIsOpen()
	{
		return isOpen;
	}
	
	
}
