using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] vehiclePrefabs;

	// Use this for initialization
	void Start () {
		Instantiate(vehiclePrefabs[0], transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
