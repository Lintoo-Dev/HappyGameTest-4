using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public int active_item = 0;

	private int items_count = 2;

	private TextMesh NewGame;
	private TextMesh BestScore;
	private TextMesh Exit;

	// Use this for initialization
	void Start () {
		ScoreWorker.time = ScoreWorker.start_time;
		NewGame = GameObject.Find("NewGame").GetComponent<TextMesh>();
		BestScore = GameObject.Find("BestScore").GetComponent<TextMesh>();
		Exit = GameObject.Find("Exit").GetComponent<TextMesh>();


		BestScore.text = "Best score: " + Keeper.get_param ("MaxScore");;

	}


	void playCheckSound()
	{
		AudioSource s = GameObject.Find("checkSound").GetComponent<AudioSource>();

		s.Play ();

	}



	
	// Update is called once per frame
	void Update () 
	{
		#if UNITY_ANDROID

		if (Input.touchCount > 0) {
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			
			
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			if(hit != null)
			{

				if(hit.collider.name == "NewGame")
				{
					playCheckSound();
					ScoreWorker.time = ScoreWorker.start_time;
					ScoreWorker.score = 0;
					Application.LoadLevel(1);
				}

				if(hit.collider.name == "Exit")
				{
					playCheckSound();
					Application.Quit();
				}


			}
		}
		#endif

		
		#if UNITY_STANDALONE_WIN
	
		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			if(active_item == 0)
			{
				ScoreWorker.time = ScoreWorker.start_time;
				ScoreWorker.score = 0;
				Application.LoadLevel(1);
			}

			if(active_item == 1)
			{
				Application.Quit();
			}

		}


		if (Input.GetKeyDown (KeyCode.W)) 
		{
			active_item--;

			if(active_item < 0)
				active_item = items_count-1;
			playCheckSound();
		}

		if (Input.GetKeyDown (KeyCode.S)) 
		{
			active_item++;
			
			if(active_item > items_count-1)
				active_item = 0;

			playCheckSound();
		}



		if (active_item == 0) 
		{
			NewGame.color = Color.magenta;

		}
		else
			NewGame.color = Color.white;




		if (active_item == 1) 
		{
			Exit.color = Color.magenta;
		}
		else
			Exit.color = Color.white;





		#endif
		

	
	}
}
