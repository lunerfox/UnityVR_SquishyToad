using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] vehiclePrefabs;
	public float heightOffset;
	public float startOffset;
	public float laneSpeed;

	// Use this for initialization
	void Start () {
		instantiateVehicle();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void instantiateVehicle() {
		int CarType = Random.Range(0, vehiclePrefabs.Length);
		GameObject vehicleObject = Instantiate(vehiclePrefabs[CarType]);
		vehicleObject.transform.position = getPositionOffset();
		vehicleObject.transform.parent = transform;
		vehicleObject.GetComponent<Vehicle>().speed = laneSpeed;
	}

	Vector3 getPositionOffset() {
		Vector3 position = transform.position;
		position += heightOffset * Vector3.up;
		position += startOffset * Vector3.right;
		return position;
	}
}
