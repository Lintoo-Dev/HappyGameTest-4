using UnityEngine;
using System.Collections;

public class CleanSmile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D Coll)
	{
			Destroy (Coll.gameObject,1);
	}
}
