using UnityEngine;
using System.Collections;


public class UnitComponent : MonoBehaviour {

//中文注释
	// Use this for initialization
	
	private EventDispatcher ed;
	public UISpriteAnimation ani;
	private Vector2 targetPoint;
	private bool needRun = false;
	public Camera ca;
	
	
	public float speed = 2.0f;
	
	void Start () 
	{
	    ed = transform.GetComponent<EventDispatcher>();
		ed.Press += OnClickFunc;
		
		//ani = transform.GetComponent<UISpriteAnimation>();
	}
	
	public void runHeroFunc(Vector3 vv)
	{
		 
		
		  Vector2 v = new Vector2(vv.x,vv.y);
		
		   if(ani.namePrefix != "run")
			{
				ani.namePrefix = "run";
			}
			
			if(needRun == false)
			{
				needRun = true;
				 
			    Vector3 oldP = transform.localPosition;
			
			    transform.position = vv;
			
			    targetPoint = new Vector2(transform.localPosition.x,transform.localPosition.y);
			
			    transform.localPosition = oldP;
				
				//targetPoint = new Vector2(v.x,v.y);
				
				//transform.position = new Vector3(targetPoint.x,targetPoint.y,transform.position.z);
			}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	    
		
		
		if(needRun == true) 
		{
			float moveDir = 1.0f;
			if(transform.localPosition.x>targetPoint.x)
			{   
				moveDir = -1.0f; 
			}
			
			float moveDirY = 1.0f;
			if(transform.localPosition.y>targetPoint.y)
			{
				moveDirY = -1.0f;
			}
			
		 
			

			
			Vector2 tempV =  Vector2.MoveTowards(new Vector3(transform.localPosition.x,transform.localPosition.y,0),targetPoint,speed);
			
			
			SendMessageUpwards("moveMapFunc",tempV);
			
			transform.localPosition = new Vector3(tempV.x,tempV.y,transform.localPosition.z);
			
			    int dir;
				if(transform.localPosition.x >targetPoint.x)
				{
					dir = -1;
				}else
				{
					dir = 1;
				}
				
				float sx = transform.localScale.x;
				sx = Mathf.Abs(sx)*dir;
				transform.localScale = new Vector3(sx,transform.localScale.y,transform.localScale.z);
			
	 
			
			if(Mathf.Abs(transform.localPosition.y - targetPoint.y) <speed && Mathf.Abs(transform.localPosition.x - targetPoint.x) <speed)
			{
				needRun = false;
			    ani.namePrefix = "stand";
			}
		}
		
		
	}
	
	private void OnClickFunc(GameObject go,bool isPress)
	{
		if(isPress)
		{
			ani.namePrefix = "run";
		}
	}
		
}
