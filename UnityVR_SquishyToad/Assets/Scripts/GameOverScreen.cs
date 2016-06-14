using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	private Player player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	// The Game Over screen should follow the player's position and look direction, essentially creating a
	// Heads up display (HUD). 
	void LateUpdate () {
		//Update the rotation of the Game Over Screen
		transform.rotation = Quaternion.LookRotation(Vector3.up, player.LookDirection());
		//Update the position of the Game Over Screen	
	}
}
