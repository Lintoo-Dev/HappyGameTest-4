using UnityEngine;
using System.Collections;

public class TelegaAdder : MonoBehaviour {

	private float time;
	private float create_time;
	

	GameObject or_telega;

	// Use this for initialization
	void Start () {
		time = 3;
		or_telega = GameObject.Find ("Telega");
		or_telega.SetActive (false);
	}
	

	
	// Update is called once per frame
	void Update () {
	    if (Game.is_pause)
			return;

		time += Time.deltaTime;

		if (Game.game_hard == 0) {
			create_time = 4.5f;
		}

		if (Game.game_hard >= 3) {
			create_time = 3;
		}

		if (Game.game_hard >= 5) {
			create_time = 2;
		}

		if (time > create_time) {
			GameObject new_obj = Instantiate(or_telega);

			new_obj.transform.position = endPointScript.telegaStartPosition.transform.position;
			new_obj.SetActive(true);
			new_obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-5,0);
			Game.is_tlist_update = true;
			time = 0;

		}

	}
}
