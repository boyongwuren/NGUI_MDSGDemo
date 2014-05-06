using UnityEngine;
using System.Collections;

public class MapPanel : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	private EventDispatcher ed;
	
	public UnitComponent uc;
	
	public UISprite testSpr;
	
	public Camera ca;
	
	void Start () 
	{
	   ed = transform.GetComponent<EventDispatcher>();
		
	   ed.Press += mapClickFunc;
		
		///print("mapPanel has renderer = "+gameObject.renderer);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	private void mapClickFunc(GameObject go,bool isPress)
	{
		if(isPress)
		{
			Vector3 v = ca.ScreenToWorldPoint(Input.mousePosition);
			uc.runHeroFunc(v);
			
			print("mouse = "+Input.mousePosition);
			print("width = "+Screen.width+"		height = "+Screen.height);
		}
	}
	
	public void moveMapFunc(Vector2 v)
	{
		
		Vector2 vv = new Vector2(uc.transform.localPosition.x,uc.transform.localPosition.y);
		float tempx = vv.x - v.x;
		float tempy = vv.y - v.y;
		
		tempx = transform.localPosition.x + tempx;
		tempy = transform.localPosition.y + tempy;
		
		Vector3 v3 = new Vector3(tempx,transform.localPosition.y,transform.localPosition.z);
		
		if(uc.transform.localPosition.x>625&&uc.transform.localPosition.x<(2500-625))
		{
			
			
			transform.localPosition = v3;
			if(transform.localPosition.x >-625)
			{
				
				transform.localPosition = new Vector3(-625,transform.localPosition.y,transform.localPosition.z);
			}
			
			if(transform.localPosition.x < -625 - 1250)
			{
				transform.localPosition = new Vector3(-625-1250,transform.localPosition.y,transform.localPosition.z);
			}
		
		
		}
		
		return;
		
		 
		v3 = ca.ScreenToWorldPoint(new Vector3(0,Screen.height,0));
		if(v3.x<transform.position.x)
		{
			transform.position = new Vector3(v3.x,transform.position.y,transform.position.z);
		}
		
		v3 = ca.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));
		
		Vector3 tempVV = transform.InverseTransformPoint(new Vector3(transform.position.x+2500,transform.position.y,transform.position.z));
		
		if(tempVV.x <v3.x)
		{
			transform.position = new Vector3(tempVV.x,transform.position.y,transform.position.z);
		}
		
		return;
		
		v3 = ca.ScreenToWorldPoint(new Vector3(1250+625 - 2500,Screen.height,0));
		
		print("ca.ScreenToWorldPoint(new Vector3(1250 - 2500,Screen.height,0))"+v3.x);
		//if(transform.position.x<v3.x)
		//{
			transform.position = new Vector3(v3.x,transform.position.y,transform.position.z);
		//} 
		
		v3 = ca.WorldToScreenPoint(transform.position);
		print("ca.WorldToScreenPoint(transform.position) = "+v3.x);
		
		print("pixelWidth = "+ca.pixelWidth +"    pixelHeight = "+ca.pixelHeight);
		
		Rect r = ca.pixelRect;
		
		print("Camera displays from " + r.xMin + " to " + r.xMax + " pixel");
		
		v3 = ca.WorldToScreenPoint(testSpr.transform.position);
		
		print(" ca.WorldToScreenPoint(testSpr.transform.position) "+v3.x);

	}
	
	
	
}
