using UnityEngine;
using System.Collections;

public class FireDestroyer : MonoBehaviour {

	//Should be a negative value.
	public float destroyDistance;

	void Start()
	{
		//Brings the destroyer back some distance
		transform.position.Set(0, 0, destroyDistance);
	}

	void OnTriggerEnter(Collider collider)
	{
		//print("Triggered");
		Destroy(collider.gameObject);
	}
}
