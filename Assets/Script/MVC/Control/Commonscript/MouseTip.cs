using UnityEngine;
using System.Collections;

public class MouseTip : MonoBehaviour {
	
	public UISlicedSprite bg;
	
	public UILabel label;
	
	private Camera NguiCa;
	// Use this for initialization
	void Start () 
	{
	     GameObject o = GameObject.Find("NGUICamera");
		 NguiCa = (Camera)o.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	   Vector3 v = NguiCa.ScreenToWorldPoint(Input.mousePosition);
	
		//v = NguiCa.ViewportToWorldPoint(v);
		//transform.gameObject.\
		
		//v = transform.InverseTransformPoint(v);
		//v.y += 6;
		v.y += 0.1f;
		//transform.localPosition = v;
		transform.position = v;
	}
	
	public void setTipString(string str)
	{ 
		label.text = str;
		Vector2 v = label.relativeSize;
		bg.transform.localScale = new Vector3(v.x*label.transform.localScale.x+10,label.transform.localScale.y,1);
		
		if(NguiCa == null)
		{
			 GameObject o = GameObject.Find("NGUICamera");
		     NguiCa = (Camera)o.GetComponent<Camera>();
		}
		
		Update();
	}   
}
