using UnityEngine;
using System.Collections;

public class EventDispatcher: MonoBehaviour   
{   
  
    public delegate void EventHandler (GameObject e);   
    public delegate void CollisionHandler (GameObject e, Collision c);   
	
	public delegate void NguiHandler(GameObject go,bool b);
	
	public delegate void NGUIHanderDrag(GameObject go,Vector2 v);
	
	public delegate void NGUIHanderDrop(GameObject go,GameObject target);
  
    public event EventHandler MouseOver;   
    void OnMouseOver ()   
    {   
        if (MouseOver != null)   
            MouseOver (this.gameObject);   
    }   
  
    public event EventHandler MouseDown;   
    void OnMouseDown ()   
    {   
        if (MouseDown != null)   
            MouseDown (this.gameObject);   
    }   
  
    public event EventHandler MouseEnter;   
    void OnMouseEnter ()   
    {   
        if (MouseEnter != null)   
            MouseEnter (this.gameObject);   
    }   
  
  
    public event EventHandler MouseExit;   
    void OnMouseExit ()   
    {   
        if (MouseExit != null)   
            MouseExit (this.gameObject);   
    }   
  
    public event EventHandler BecameVisible;   
    void OnBecameVisible ()   
    {   
        if (BecameVisible != null)   
            BecameVisible (this.gameObject);   
    }   
  
    public event EventHandler BecameInvisible;   
    void OnBecameInvisible ()   
    {   
        if (BecameInvisible != null)   
            BecameInvisible (this.gameObject);   
    }   
  
    public event CollisionHandler CollisionEnter;   
    void OnCollisionEnter (Collision c)   
    {   
        if (CollisionEnter != null)   
            CollisionEnter (this.gameObject, c);   
    }   
  
    public event CollisionHandler CollisionExit;   
    void OnCollisionExit (Collision c)   
    {   
        if (CollisionExit != null)   
            CollisionExit (this.gameObject, c);   
    }   
	
	
	//ngui Event 
	 
	public event NguiHandler Hover;
	public void OnHover (bool isOver)
	{
		if(Hover != null) 
		{
			Hover(this.gameObject,isOver);
		}
	}
	
	public event NguiHandler Press;
	public void OnPress (bool isPress)
	{
		if(Press != null)
		{
			Press(this.gameObject,isPress);
		}
	}
	
	public event NGUIHanderDrag Drag;
	void OnDrag(Vector2 v)
	{
		if(Drag != null)
		{
			Drag(this.gameObject,v);
		}
	}
	
    public event NGUIHanderDrop Drop;
	void OnDrop(GameObject go)
	{
		if(Drop != null)
		{
			Drop(this.gameObject,go);
		}
	}
       
}  
