using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		
		#if UNITY_ANDROID
		
		if (Input.touchCount > 0) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			
			
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
			
			if(hit != null)
			{
				
				if(hit.collider.name == "menu")
				{
				
					Application.LoadLevel(0);
				}
				
				
			}
		}
		#endif


	
	}
}
