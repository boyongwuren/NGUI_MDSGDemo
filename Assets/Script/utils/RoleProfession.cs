using UnityEngine;
using System.Collections;

public class RoleProfession 
{
	public static int Pro_1 = 1;
	
	public static int Pro_2 = 2;
	
	public static int Pro_3 = 3;
	
	public static int Pro_4 = 4;
	
	public static int Pro_5 = 5;
	
	public static string[] professionName = new string[]{"","mj","ss","zh","sj","ms"};
	
	public static string getProNameByType(int roleType)
	{
		return professionName[roleType];
	}
 
}
