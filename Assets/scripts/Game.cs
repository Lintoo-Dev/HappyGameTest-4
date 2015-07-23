using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public static int game_hard = -1;

	public static float time = 0;

	public static int mode;

	public static class game_modes
	{
		public static int free = 0;
		public static int hard_core = 1;
		public static int normal = 2;
	}


	public static bool is_tlist_update;

	public static bool is_pause;

	// Use this for initialization
	void Start () {
		//mode = game_modes.normal;

		setGameHard (0);
		is_tlist_update = false;
		time = 0;
		is_pause = false;
	}


	// Установить скорость для всех тележек
	void setSpeed(float s)
	{
		GameObject []t_list = GameObject.FindGameObjectsWithTag ("Telega");

		for (int j=0; j < t_list.Length; j++) 
		{

			WheelJoint2D [] wheels = t_list[j].GetComponents<WheelJoint2D> ();

			for (int i=0; i < wheels.Length; i++) {
				var motor = wheels [i].motor;
				motor.motorSpeed = s;
				wheels [i].motor = motor;
			}
		}
		
	}
	

	 void setGameHard(int level)
	{
		game_hard = level;

		Debug.Log (game_hard);

		if (game_hard == 0) 
			setSpeed(150);

		if (game_hard == 1) 
			setSpeed(200);

		if (game_hard == 2) 
			setSpeed(250);

		if (game_hard == 3) 
			setSpeed(300);

		if (game_hard == 4) 
			setSpeed(350);

		if (game_hard == 5) 
			setSpeed(500);

		if (game_hard == 6) 
			setSpeed(560);
		
		if (game_hard == 7) 
			setSpeed(620);
		
		if (game_hard == 8) 
			setSpeed(1050);
		
		if (game_hard == 9) 
			setSpeed(1100);
		
		if (game_hard == 10) 
			setSpeed(1450);

		
		

	}


	// Эта функция с течением времени увеличивает скорость тележек
	void Update () {
		if (is_pause)
			return;


		time += Time.deltaTime;

		if (is_tlist_update == true) {
			setGameHard(game_hard);
			is_tlist_update = false;
		}


		if (time >= 0 && time <= 6 && game_hard != 0)
			setGameHard(0);


		if (time >= 9 && time <= 18 && game_hard != 1) 
			setGameHard(1);

		if (time >= 19 && time <= 23 && game_hard != 2) 
			setGameHard(2);

		if (time >= 24 && time <= 30 && game_hard != 3) 
			setGameHard(3);

		if (time >= 31 && time <= 42 && game_hard != 4) 
			setGameHard(4);

		if (time >= 43 && time <= 50 && game_hard != 5) 
			setGameHard(5);

		if (time >= 51 && time <= 60 && game_hard != 6) 
			setGameHard(6);

		if (time >= 61 && time <= 69 && game_hard != 7) 
			setGameHard(7);

		if (time >= 70 && time <= 78 && game_hard != 8) 
			setGameHard(8);

		if (time >= 79 && time <= 85 && game_hard != 9) 
			setGameHard(9);

		if (time >= 86  && game_hard != 10) 
			setGameHard(10);
		
		

	
	}
}
