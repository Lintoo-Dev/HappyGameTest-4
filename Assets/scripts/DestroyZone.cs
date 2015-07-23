using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour {



	void OnCollisionEnter2D(Collision2D Coll)
	{
			Destroy (Coll.gameObject);
	}
}
