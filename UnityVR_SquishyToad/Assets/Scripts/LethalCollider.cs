using UnityEngine;
using System.Collections;

public class LethalCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		GameState gameState = FindObjectOfType<GameState>();
		Player player = collision.gameObject.GetComponent<Player>();
		//If the car collides with the player and the game is not over
		//Make game over.
		if(player && !gameState.IsGameOver)
		{
			print("Game Over!");
			gameState.IsGameOver = true;
			AudioSource squish = GetComponent<AudioSource>();
			squish.Play();
		}
	}
}
