using UnityEngine;
using System.Collections;

public class TownInfoPanel : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	public TogButton soundBtn;
	
	void Start () 
	{
	    soundBtn.GetComponent<EventDispatcher>().Press += soundClickFunc;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	private void soundClickFunc(GameObject go,bool isPress)
	{
		print("isPress = "+isPress);
		if(isPress)
		{
			soundBtn.setIsOpen(!soundBtn.getIsOpen());
		}
	}
}
