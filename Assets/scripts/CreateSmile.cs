using UnityEngine;
using System.Collections;


public class CreateSmile : MonoBehaviour {
	

	private float create_timer = 0;
	private float sound_timer = 0;

	private AudioSource smileCreateSound;

	// позиция в которой создался объект
	private int last_smile_create_pos;
	private int smile_create_pos_count = 3;


	// Исходник объектов
	private GameObject original_grusha;
	private GameObject original_banan;
	private GameObject original_apple;
	private GameObject original_bonus;

	private Vector2 smileCreatePos;
	private Vector2 smileCreatePos2;
	private Vector2 smileCreatePos3;
	// Use this for initialization
	void Start () {

		smileCreateSound = GameObject.Find ("SmileCreateSound").GetComponent<AudioSource> ();

		original_grusha = GameObject.Find ("Grusha");
		original_banan = GameObject.Find ("Banan");
		original_apple = GameObject.Find ("Apple");
		original_bonus = GameObject.Find ("Bonus");

		smileCreatePos = GameObject.Find ("SmileCreatePos").gameObject.transform.position;
		smileCreatePos2 = GameObject.Find ("SmileCreatePos2").gameObject.transform.position;
		smileCreatePos3 = GameObject.Find ("SmileCreatePos3").gameObject.transform.position;

		original_grusha.SetActive(false);
		original_banan.SetActive(false);
		original_apple.SetActive(false);
		original_bonus.SetActive(false);

		last_smile_create_pos = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Game.is_pause)
			return;

		//original_smile.transform.position = new Vector2 (0, 0);

		create_timer += Time.deltaTime;
		sound_timer += Time.deltaTime;

		if (create_timer <= 0.09)
			return;

		GameObject obj = original_banan;

		int rnd_num = Random.Range (0, 4);

		if(rnd_num == 0)
			obj = original_grusha;
		if(rnd_num == 1)
			obj = original_banan;
		if(rnd_num == 2)
			obj = original_apple;


		if(Random.Range (0, 30) == 4)
			obj = original_bonus;



		Vector3 pos = transform.position;

		pos.z = 1;

		obj.transform.position = pos;



		#if UNITY_ANDROID

		if (Input.touchCount == 0) 
		{
			return;
		}


		Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			
			
		RaycastHit2D touch_obj = Physics2D.Raycast(ray.origin, ray.direction);


		#endif




		if(
			#if UNITY_STANDALONE_WIN
			Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
            #endif

			#if UNITY_ANDROID 
			touch_obj != null
			#endif
			)

		{

		

			for(int i=0; i < 1; i++)
			{

				GameObject new_obj = Instantiate(obj);


				if(last_smile_create_pos == 1)
				  new_obj.transform.position = smileCreatePos;

				if(last_smile_create_pos == 2)
					new_obj.transform.position = smileCreatePos2;

				if(last_smile_create_pos == 3)
					new_obj.transform.position = smileCreatePos3;

				last_smile_create_pos++;

				if(last_smile_create_pos > smile_create_pos_count)
					last_smile_create_pos = 1;


				new_obj.SetActive(true);

				//Vector2 p = new_obj.transform.position;



				//new_obj.gameObject.transform.position.y += 10;

			  Rigidbody2D rb = new_obj.GetComponent<Rigidbody2D>();

			  rb.velocity = new Vector2(0,-15);

			}

			if(sound_timer > 0.06)
			{
			  smileCreateSound.Play();
			  sound_timer = 0;
			}
			
			//if(!smileCreateSound.isPlaying)
			  
	

			create_timer = 0;
			
		}


		
	}
}
