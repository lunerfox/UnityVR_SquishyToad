using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour {

	public float speed {get; set;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right  * speed * Time.deltaTime;
	}
}
