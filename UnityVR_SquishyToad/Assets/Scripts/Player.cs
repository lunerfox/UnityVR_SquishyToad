using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Text GazeText;
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
		RequestJump();
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
	}
}
