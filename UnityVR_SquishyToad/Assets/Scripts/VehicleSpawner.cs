using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] vehiclePrefabs;
	public float heightOffset;
	public float startOffset;
	public float laneSpeed;
	public float lifeDistance;
	private bool direction;
	private GameObject vehicleObject;

	// Use this for initialization
	void Start () {
		//pick a direction that all vehicles from this lane travel at.
		if(Random.Range(0, 2) == 1) 	direction = true;
		else 							direction = false;
		print("Direction Set to " + direction);
		//Create a vehicle.
		instantiateVehicle();
	}
	
	// Update is called once per frame
	void Update () {
		if(!vehicleObject) instantiateVehicle();
	}

	void instantiateVehicle() {
		int CarType = Random.Range(0, vehiclePrefabs.Length);
		vehicleObject = Instantiate(vehiclePrefabs[CarType]);
		vehicleObject.transform.position = getPositionOffset();
		vehicleObject.transform.parent = transform;

		Vehicle vehicleScript = vehicleObject.GetComponent<Vehicle>();
		vehicleScript.speed = laneSpeed;
		vehicleScript.direction = direction;
		vehicleScript.lifetime = lifeDistance/laneSpeed;
	}

	Vector3 getPositionOffset() {
		Vector3 position = transform.position;
		position += heightOffset * Vector3.up;
		if(direction) 	position += startOffset * Vector3.right;
		else 			position += startOffset * Vector3.left;
		return position;
	}
}
