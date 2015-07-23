using UnityEngine;
using System.Collections;
using System;

public class ScoreWorker : MonoBehaviour {

	public static int score = 0;
	public static float time;
	public string paramName;

	
	public static float start_time = 26;


	private TextMesh score_label;

	// Use this for initialization
	void Start () 
	{
		time = start_time;

	}
	
	// Update is called once per frame
	void Update () {

		// Если время вышло
		if (time <= 0 && Game.mode != Game.game_modes.free) 
		{
			time = 0;
			Application.LoadLevel(3);
		}


		TextMesh []m = GetComponents<TextMesh>();

		for (int i=0; i < m.Length; i++) 
		{
			if(m[i].name == "Score")
			{
				m[i].text = Convert.ToString(score);
			}


			if(m[i].name == "Time")
			{
				if(Game.mode != Game.game_modes.free)
				    m[i].text = Convert.ToString((int)time);
				else
					m[i].text = "∞";

			}
		}


		time -= (Time.deltaTime / 4);

	}
}
