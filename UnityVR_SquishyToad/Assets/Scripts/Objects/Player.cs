using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //THIS SHOULD BE REFACTORED OUT!!  [gameCoordinator]

public class Player : MonoBehaviour {

    public Text GazeText;
    public bool allowJump;                          //Check this to allow the player to move
	public uint JumpVelocity;
	public float JumpAngleInDegrees;
	private Rigidbody rb;
	private GvrHead FrogHead;
	private bool JumpReady;
	private float lastJumpRequestTime = 0.0f;
	private GameState gameState;

	// Use this for initialization
	void Start () {
		gameState = GameObject.FindObjectOfType<GameState>();
		//Attach the OnTrigger event to PullTrigger Method
		GvrViewer.Instance.OnTrigger += PullTrigger;
		rb = GetComponent<Rigidbody>();
	}

    private void PullTrigger() {
		if(allowJump) RequestJump();
	}
	
	private void RequestJump() {
		lastJumpRequestTime = Time.time;
		rb.WakeUp(); 
	}
	
	private void Jump(){

        Vector3 projectedVector = LookDirection();

        if (gameState.PwrUpJump) {
            Vector3 jumpvector = Vector3.RotateTowards(projectedVector, Vector3.up, JumpAngleInDegrees * Mathf.Deg2Rad, 0);
            rb.velocity = jumpvector * JumpVelocity * 5;
        }
        else {
            Vector3 jumpvector = Vector3.RotateTowards(projectedVector, Vector3.up, JumpAngleInDegrees * Mathf.Deg2Rad, 0);
            rb.velocity = jumpvector * JumpVelocity;
        }

		
		
        //Play Audio to indicate that a jump has occured.
        AudioSource bounce = GetComponent<AudioSource>();
		bounce.Play(); 
	}

	//Provides the player's view direction in the horizontal.
	public Vector3 LookDirection()
	{
		return Vector3.ProjectOnPlane(FrogHead.Gaze.direction, Vector3.up);
	}

	void OnCollisionStay(Collision collision) {
		float deltaT = Time.time - lastJumpRequestTime; 
		if (deltaT < 0.1 && !gameState.IsGameOver) {
			Jump ();
			lastJumpRequestTime = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		FrogHead = FindObjectOfType<GvrHead>();
        //Allow the player to start jumping if the game is being played (After the player presses the "Escape" button)
        if (!gameState.IsIdle && !gameState.IsGameOver) allowJump = true;
        else                                            allowJump = false;
        
	}

    public void PlayerReady()       //THIS SHOULD BE REFACTORED OUT!! [gameCoordinator]
    {
        print("Player Ready");
        gameState.IsIdle = false;
    }

    public void ResetGame()         //THIS SHOULD BE REFACTORED OUT!! [gameCoordinator]
    {
        SceneManager.LoadScene(1);
        gameState.IsIdle = true;
        gameState.IsGameOver = false;
        print("Game Reset");
    }
}
