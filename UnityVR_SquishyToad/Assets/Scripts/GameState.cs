using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	public bool IsGameOver   { get; set;}   //Game Over state is HIGH when the player has lost but has not restarted.
    public bool IsIdle       { get; set;}   //Idle state is HIGH when the player has restarted but not ready
	public float HighScore    {get; set;}
	public int CurLevel      {get; set;}

    //TODO: Separate power-ups into its own separate handler
    public bool PwrUpJump { get; set;}
    private float PwrUpJumpCooldown;

    void Awake() {
        //Maintains the game state between scenes
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start () {
        print("Initialize Super-State (GameState)");
        PwrUpJumpCooldown = 10.0f;
        IsGameOver = false;
        IsIdle = true;
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
