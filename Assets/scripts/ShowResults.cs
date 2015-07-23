using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class ShowResults : MonoBehaviour {

	public int score;

	private TextMesh  ResultLabel;
	private TextMesh  DescLabel;

	private float timer;

	private bool is_wait;

	private int best_record = 0;

	// Use this for initialization
	void Start () 
	{
		score = ScoreWorker.score;

		ResultLabel = GameObject.Find ("Score").GetComponent<TextMesh> ();
		DescLabel =   GameObject.Find ("Description").GetComponent<TextMesh> ();

		timer = (float)1.9;
		is_wait = true;
		
		

		int curr_max_score = 0;



		string r = Keeper.get_param ("MaxScore");
			
		curr_max_score = Convert.ToInt32 (r);




		if (curr_max_score < score) 
		{
			curr_max_score = score;
		}





		Keeper.set_param ("MaxScore", Convert.ToString (curr_max_score));

		best_record =  Convert.ToInt32(Keeper.get_param ("MaxScore"));

		//best_record = Convert.ToInt32 (max_score);
		//best_record = max_score;



	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (is_wait == true) 
		{
			ResultLabel.text = "Game over";
			DescLabel.text = "Wait " + (int)timer;

			timer -= Time.deltaTime;

			if(timer <= 0)
			{
				is_wait = false;
			}

			return;
		}

		ResultLabel.text = "You scored: " + score + "\nYou best record: " + Convert.ToString(best_record);


		#if UNITY_STANDALONE_WIN

		DescLabel.text = "Press Enter to play again\nor press Esc to exit main menu";


		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			Game.game_hard = -1;
			Game.time = 0;

			ScoreWorker.score = 0;
			Application.LoadLevel(1);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.LoadLevel(0);
		}
        #endif




		#if UNITY_ANDROID

		DescLabel.text = "Tap the screen\nto open main menu";

		if (Input.touchCount != 0) 
		{
			Game.game_hard = -1;
			Game.time = 0;
			
			ScoreWorker.score = 0;
			Application.LoadLevel(0);
		}


		#endif


	}
}
