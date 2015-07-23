using UnityEngine;
using System.Collections;

public class endPointScript : MonoBehaviour {
	public static GameObject telegaStartPosition;

	AudioSource NewScoreSound;

	


	/*


	public static class ScoreUpShow
	{
		public static TextMesh label;

		public static int up_value;

		public static float show_time = (float)1.24;

		public static bool is_show;

		public static float timer;

	}

	*/

	// Use this for initialization
	void Start () {
		telegaStartPosition = GameObject.Find ("TelegaStartPos");
		NewScoreSound = GameObject.Find ("NewScoreSound").GetComponent<AudioSource> ();

		/*
		ScoreUpShow.label = GameObject.Find ("ScoreUpCount").GetComponent<TextMesh> ();
		ScoreUpShow.up_value = 0;
		ScoreUpShow.is_show = false;
		ScoreUpShow.timer = 0;
		*/

	}

	/*
	void show_scoreup_count()
	{
		ScoreUpShow.timer = 0;

		ScoreUpShow.is_show = true;

	}
*/


	// Update is called once per frame
	/*
	void Update () 
	{
		if (Game.is_pause)
			return;

		// Вывод количества прибавленных очков
		if (!ScoreUpShow.is_show) 
		{
			return;
		} 

		else 
		{

		}



		if (ScoreUpShow.timer > ScoreUpShow.show_time )
	   {
			ScoreUpShow.label.text = "";
			ScoreUpShow.timer = 0;
			ScoreUpShow.is_show = false;
			ScoreUpShow.up_value = 0;
			return;
	   } 

		else 
		{
			ScoreUpShow.label.text = "+" + ScoreUpShow.up_value;
		}

		ScoreUpShow.timer += Time.deltaTime;

		//-------------------------------------------------



	}

*/

	void AddScore(int c)
	{
		ScoreWorker.score += c;
	}



	
	void OnCollisionEnter2D(Collision2D Coll)
	{
		if (Coll.gameObject.tag == "Telega" || Coll.gameObject.tag == "Wheel") {

			GameObject telegaObj = GameObject.Find("Telega");

			Destroy (Coll.gameObject);

			/*

			Rigidbody2D rb = telegaObj.GetComponent<Rigidbody2D>();

			telegaObj.transform.position = telegaStartPosition.transform.position;

			telegaObj.transform.rotation = telegaStartPosition.transform.rotation;
			rb.velocity = new Vector2(-3,0);
			*/
		} 

		if (Coll.gameObject.tag == "Smile" || Coll.gameObject.tag == "BonusTag")
		{
			AddScore(1);

			if(ScoreWorker.time <= 45)
			{
			   if(Game.game_hard <=5)
			     ScoreWorker.time += (float)1.32;

				if(Game.game_hard > 5)
					ScoreWorker.time += (float)0.83;
				
			}

			else
			{
				ScoreWorker.time += (float)0.21;
			}


			if(ScoreWorker.time > 70)
				ScoreWorker.time = 50;
			
			Destroy(Coll.gameObject);

			NewScoreSound.Play();

	

			if(Coll.gameObject.tag == "BonusTag")
			{
				ScoreWorker.time += (float)3;
			}

		


		}


	}

}
