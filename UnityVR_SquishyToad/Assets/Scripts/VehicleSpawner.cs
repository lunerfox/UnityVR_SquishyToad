using UnityEngine;
using System.Collections;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] vehiclePrefabs;
	public float heightOffset;
	public float startOffset;
	public float laneSpeed;
	public float lifeDistance;
	public int minSpawnInterval;
	public int maxSpawnInterval;

	private bool direction;
	private GameObject vehicleObject;
	private Player player;
	private GameState gameState;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		gameState = FindObjectOfType<GameState>();
		//pick a direction that all vehicles from this lane travel at.
		if(Random.Range(0, 2) == 1) 	direction = true;
		else 							direction = false;
		print("Direction Set to " + direction);
		//Create a vehicle.
		StartCoroutine("SpawnVehicle");
	}

	IEnumerator SpawnVehicle() {
		while(!gameState.IsGameOver) {
			instantiateVehicle();
			yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void instantiateVehicle() {
		int CarType = Random.Range(0, vehiclePrefabs.Length);
		vehicleObject = Instantiate(vehiclePrefabs[CarType]);

		Vehicle vehicleScript = vehicleObject.GetComponent<Vehicle>();
		vehicleScript.speed = laneSpeed;
		vehicleScript.direction = direction;
		vehicleScript.lifetime = lifeDistance/laneSpeed;

		vehicleObject.transform.position = getPositionOffset();
		vehicleObject.transform.parent = transform;
		if(direction) vehicleObject.transform.Rotate(0, 180, 0);


	}

	Vector3 getPositionOffset() {
		Vector3 playerOffset = new Vector3(player.transform.position.x, 0, 0);
		Vector3 position = transform.position;
		position += heightOffset * Vector3.up;
		if(direction) 	position += playerOffset + (startOffset * Vector3.right);
		else 			position += playerOffset + (startOffset * Vector3.left);
		return position;
	}
}
