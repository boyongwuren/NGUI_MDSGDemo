using UnityEngine;
using System.Collections;

public class EquipContent : MonoBehaviour {
	
	public EquipItem bingFu;
	
	public EquipItem touKui;
	
	public EquipItem zhanXue;
	
	public EquipItem zhanHun;
	
	public EquipItem kuiJIa;
	
	public EquipItem wuQi;
	
	private EquipVo[] evos;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public EquipVo[] Evos
	{
		get
		{
			return evos;
		}
		
		set
		{
			evos = value;
			
			touKui.Evo = evos[0];
			zhanXue.Evo = evos[1];
			bingFu.Evo = evos[2];
			zhanHun.Evo = evos[3];
			kuiJIa.Evo = evos[4];
			wuQi.Evo = evos[5];
		}
	}
	
	
}
