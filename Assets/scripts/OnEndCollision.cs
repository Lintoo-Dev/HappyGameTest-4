using UnityEngine;
using System.Collections;

public class OnEndCollision : MonoBehaviour {


	void Update()
	{

	}

	void OnCollisionEnter2D(Collision2D Coll)
	{
	   if(Coll.gameObject.name == "Telega")
		Destroy (Coll.gameObject);
	}

}
