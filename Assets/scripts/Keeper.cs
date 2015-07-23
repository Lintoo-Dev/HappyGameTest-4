using UnityEngine;
using System.Collections;
using System.IO;





public class Keeper : MonoBehaviour 
{
	public static string folder = "azaza/";

	private static bool is_start = false;

	private static void Start()
	{
		Keeper.folder = Application.persistentDataPath  + "/";
		Debug.Log (Keeper.folder);
	}
	
	


	
	public static string get_param(string name)
	{
		if (!is_start) {
			Start ();
			is_start = true;
		}

		if (!File.Exists (Keeper.folder + name))
			File.WriteAllText (Keeper.folder + name, "0");
				
		return File.ReadAllText(Keeper.folder + name);
	}
	
	public static void set_param(string name, string v)
	{
		if (!is_start) {
			Start ();
			is_start = true;
		}


		if (!File.Exists (Keeper.folder + name))
			File.WriteAllText (Keeper.folder + name, "0");
		
		
		File.WriteAllText(Keeper.folder + name, v);
		
		
	}


}
