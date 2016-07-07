using UnityEngine;
using System.Collections;

//Spawns infinite lanes. As the player moves forward, lanes continue to spawn based on a pre-set distance.

public class Spawner : MonoBehaviour {

	//Apply this public variable to the spawner Game object.
	//All lanes become children of the spawnerParent.
	public Transform spawnerParent;

    public float spawnStartOffset;       
	public GameObject[] lanePreFabs;
	public GameObject Player;
	public float spawnHorizon = 100f;
	//Should be a positive value. The game will automatically determine if the vehicle should be moving left or right.
	private float nextLaneOffset = 0f; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		while (nextLaneOffset < spawnHorizon + Player.transform.position.z)
		{
			GameObject instance;
			//Randomly instantiate a type of lane based on pre-fabs
			int laneType = (int) Random.Range(0, lanePreFabs.Length);
			//Special case: The first lane is always a grass lane.
			if (nextLaneOffset == 0) laneType = 0;
			//Attach the instant as a child of the spawnerParent.
			instance = Instantiate(lanePreFabs[laneType]);
			instance.transform.parent = spawnerParent;
			
			//Place the newly prefabbed lane in the correct area.
			//print ("Creating new lane at " + nextLaneOffset);
			Vector3 lanePosition = new Vector3(0, 0, nextLaneOffset + spawnStartOffset); 
			nextLaneOffset += instance.transform.localScale.z;
			instance.transform.position = lanePosition;
		}	
		
	}
}
