using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] vehiclePrefabs;
	public float heightOffset;
	public float startOffset;

	// Use this for initialization
	void Start () {
		Vector3 position = transform.position;
		position += heightOffset * Vector3.up;
		position += startOffset * Vector3.right;
		int CarType = Random.Range(0, vehiclePrefabs.Length);
		GameObject vehicleObject = Instantiate(vehiclePrefabs[CarType]);
		vehicleObject.transform.position = position;
		vehicleObject.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
