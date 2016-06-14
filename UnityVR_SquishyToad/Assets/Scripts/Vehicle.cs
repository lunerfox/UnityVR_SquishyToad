using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

	public float speed {get; set;}
	public bool direction {get; set;}
	public float lifetime {get; set;}

	// Use this for initialization
	void Start () {
		Invoke("removeVehicle", lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vehicleDirection;
		if(direction) 	vehicleDirection = Vector3.right; 
		else 		  	vehicleDirection = Vector3.left;
		transform.position += vehicleDirection  * speed * Time.deltaTime;
	}

	void removeVehicle() {
		Destroy(gameObject);
	}


}
