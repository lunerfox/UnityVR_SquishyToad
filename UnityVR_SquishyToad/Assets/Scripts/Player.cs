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

	// Use this for initialization
	void Start () {
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
		Vector3 projectedVector = Vector3.ProjectOnPlane(FrogHead.Gaze.direction, Vector3.up);
		Vector3 jumpvector = Vector3.RotateTowards(projectedVector, Vector3.up, JumpAngleInDegrees * Mathf.Deg2Rad, 0);
		//print("Trigger Pulled");
		rb.velocity = jumpvector * JumpVelocity;
	}
	
	void OnCollisionStay(Collision collision) {
		float deltaT = Time.time - lastJumpRequestTime; 
		if (deltaT < 0.1) {
			Jump ();
			lastJumpRequestTime = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		FrogHead = FindObjectOfType<GvrHead>();
	}
}
