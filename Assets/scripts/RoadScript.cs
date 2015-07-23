using UnityEngine;
using System.Collections;

public class RoadScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D Coll)
	{
		if (this.name == "EndRoad") 
		{



		}


		if (Coll.gameObject.tag == "Telega") 
		{
			return;
		}

		if (Coll.gameObject.tag == "Smile") 
		{
			Destroy(Coll.gameObject);
			ScoreWorker.time -= 1;

			if(Game.game_hard >= 4)
				ScoreWorker.time -= 2;

			if(Game.game_hard >= 8)
				ScoreWorker.time -= 2;

			// Если включен хардкорный режим
			if(Game.mode == Game.game_modes.hard_core)
			{
				ScoreWorker.time = 0;
			}
		}

		if (Coll.gameObject.tag == "BonusTag") 
		{
			ScoreWorker.time -= 5;


			Destroy(Coll.gameObject);
		}


	}

}
