using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public bool IsGameOver { get; set;}
	public uint HighScore {get; set;}
	public int CurLevel {get; set;}

	public void ResetGame() {
		Application.LoadLevel("Main");
	}

	public void BackToMenu() {
		Application.LoadLevel("SplashScreen");
	}
			
}
