using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

	public float speed {get; set;}
	public bool direction {get; set;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vehicleDirection;
		if(direction) 	vehicleDirection = Vector3.right; 
		else 		  	vehicleDirection = Vector3.left;
		transform.position += vehicleDirection  * speed * Time.deltaTime;
	}
}
