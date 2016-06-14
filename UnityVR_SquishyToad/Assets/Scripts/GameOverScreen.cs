using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	//Set Screen distance from the player's view
	public float DistanceFromPlayer;
	private Player player;
	private Canvas gameOverUI;
	private GameState gameState;

	// Use this for initialization
	void Start () {
		gameState = GameObject.FindObjectOfType<GameState>();
		player = GameObject.FindObjectOfType<Player>();
		gameOverUI = GetComponent<Canvas>();
		gameOverUI.enabled = false;
	}
	
	// Update is called once per frame
	// The Game Over screen should follow the player's position and look direction, essentially creating a
	// Heads up display (HUD). 
	void LateUpdate () {
		if(gameState.IsGameOver) {
			gameOverUI.enabled = true;
			//Update the rotation of the Game Over Screen
			transform.rotation = Quaternion.LookRotation(player.LookDirection());
			//Update the position of the Game Over Screen
			transform.position = player.transform.position + (player.LookDirection() * DistanceFromPlayer);
		}
	}
}
