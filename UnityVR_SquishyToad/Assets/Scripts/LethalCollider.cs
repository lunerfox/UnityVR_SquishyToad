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
		Player player = collision.gameObject.GetComponent<Player>();
		if(player)
		{
			GameState gameState = FindObjectOfType<GameState>();
			gameState.IsGameOver = true;
		}
	}
}
