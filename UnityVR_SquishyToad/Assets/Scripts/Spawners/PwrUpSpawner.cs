using UnityEngine;
using System.Collections;

//Spawns power-ups in lanes where this script is attached.

public class PwrUpSpawner : MonoBehaviour {

	public GameObject[] pwrUpPrefabs; 	//Array of power-ups available
	public float spawnChance; 			//Range: 0 to 1, probability of a lane spawning a power-up
	public float spawnChanceLevelMod;	//Range: 0 to 1, Modifier for spawn chance as the level increases
	//public int maxPwrUp;				//Maximum power ups in a lane (if the lane is spawned with power ups)
	public int playerDistOffset;		//Maximum distance that the power up should be away from the player
	public float PwrUpHeightOffset;		//Height offset to bring the geometry up from the ground

	private GameState gameState;
	private Player player;
	private GameObject pwrUp;

	// Use this for initialization
	void Start () {
		//print("Started pwrUp Script");
		player = FindObjectOfType<Player>();
		gameState = FindObjectOfType<GameState>();
		//Determine Spawn probability
		float spawnProb = spawnChance + (spawnChanceLevelMod * gameState.CurLevel);
		if(Random.value < spawnProb) {
			instantiatePwrUp();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void instantiatePwrUp() {
		if(!gameState.IsGameOver) {
			print("Created Power Up");
			int PwrUpType = Random.Range(0, pwrUpPrefabs.Length);
			pwrUp = Instantiate(pwrUpPrefabs[PwrUpType]);
			pwrUp.transform.position = getPositionOffset();
		}
	}

	Vector3 getPositionOffset() {
		Vector3 playerOffset = new Vector3(player.transform.position.x, 0, 0);
		Vector3 position = transform.position;
		//Determine the distance offset based on playerDistOffset
		int actualDistOffset = Random.Range(-playerDistOffset, playerDistOffset);
		position += actualDistOffset * Vector3.right;
		position += PwrUpHeightOffset * Vector3.up;
		//print(position);
		return position;
	}

}
