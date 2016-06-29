using UnityEngine;
using System.Collections;

public class FireWall : MonoBehaviour {

	//Base speed of how quickly the fire advances (In m/s). Multiplied on a per-level basis
	public float FireVelocity;
	//How much distance the Frog must travel to increase the fire's speed
	public int DistancePerLevel;
	//Max Velocity (difficulty) allowed by the game (In m/s)
	public float MaxVelocity;
	//How far does the frog have to be engulfed in order to lose?
	public float engulfDistance;

	private int prevLevel;
	private int level;
	private GameObject player;
	private GameState state;

	// Use this for initialization
	void Start () {
		prevLevel = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Gather the player object
		player = GameObject.Find("player");
		state = GameObject.FindObjectOfType<GameState>();
		if(!state.IsGameOver) {
			//Makes the Fire Container object laterally follow the player.
			FollowPlayer();
			//Makes the Fire Container object creep towards the player while the game is not over.
			CreepForward();
			//Check if the fire is engulfing the player If so, game over.
			if(isPlayerInside()) {
				state.IsGameOver = true;
				state.HighScore = (uint) transform.position.z;
				//print("You lose!");
			}
			//Informs the player when the level has gone up.
			if (prevLevel != level) {LevelChanged();}
		}


	}

	void FollowPlayer() {
		Vector3 delta = player.transform.position - transform.position;
		Vector3 projectedDelta = Vector3.Project(delta, Vector3.left);
		transform.position += projectedDelta; 	
	}

	void CreepForward() {
		level = (int) player.transform.position.z/DistancePerLevel + 1;
		float speed = FireVelocity * level;
		if (speed > MaxVelocity) speed = MaxVelocity;
		Vector3 FireCreep = Vector3.forward * speed * Time.deltaTime;
		transform.position += FireCreep;
	}

	void LevelChanged() {
        AudioSource LevelUp = GetComponent<AudioSource>();
        LevelUp.Play();
		print("Level " + level + " | Speed increased.");
		prevLevel = level;
		state.CurLevel = level;
	}

	bool isPlayerInside() {
		if(player.transform.position.z < transform.position.z - engulfDistance) 	return true;
		else 																		return false;
	}
}
