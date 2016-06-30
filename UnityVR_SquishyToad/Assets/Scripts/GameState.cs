using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public bool IsGameOver { get; set;}
	public uint HighScore {get; set;}
	public int CurLevel {get; set;}

    //TODO: Separate power-ups into its own separate handler
    public bool PwrUpJump { get; set;}
    private float PwrUpJumpCooldown;

    void Start () {
        PwrUpJumpCooldown = 10.0f;
    }

	public void ResetGame() {
		Application.LoadLevel("Main");
	}

	public void BackToMenu() {
		Application.LoadLevel("SplashScreen");
	}
    
    void Update () {
        if (PwrUpJump) {
            PwrUpJumpCooldown -= Time.deltaTime;
            if (PwrUpJumpCooldown < 0) {
                print("Power Up is being turned off by Game State");
                PwrUpJump = false;
                PwrUpJumpCooldown = 10.0f;
            }
        }
    }
}
