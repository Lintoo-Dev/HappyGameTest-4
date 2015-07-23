using UnityEngine;
using System.Collections;

public class levelSelectHHandler : MonoBehaviour {

	void startGame(string colliderName){
		if (colliderName == "NormalGame") {
			Game.mode = 2;
			Application.LoadLevel(2);
		}
		if (colliderName == "FreeGame") {
			Game.mode = 0;
			Application.LoadLevel(2);
		}
		if (colliderName == "HardcoreGame") {
			Game.mode = 1;
			Application.LoadLevel(2);
		}
		
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];
			Vector3 pos = Camera.main.ScreenToWorldPoint (touch.position);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit.collider.name == "NewGame") {
				Application.LoadLevel(1);
			}
		}
		#endif
		#if UNITY_STANDALONE_WIN
		if (Input.GetMouseButton(0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
			if (hit.collider.name != null) {
				startGame(hit.collider.name);
			}
		}
		
		#endif
	}
}
