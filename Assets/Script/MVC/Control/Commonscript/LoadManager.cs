using UnityEngine;
using System.Collections;

public class LoadManager 
{
     public delegate void LoadOverCallBack(Texture2D pic);   
     
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	public static IEnumerator LoadBitMap(string url,LoadOverCallBack func){
		//Debug.Log("gotoLoadPic" +url);
		WWW loader = new WWW(url);
		
		
		yield return loader;
		
		//Debug.Log("loaderManger loader pic ok");
		func(loader.texture);
		
	}
	
	
}
