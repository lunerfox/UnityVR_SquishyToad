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

	// Use this for initialization
	void Start () {
		//Attach the OnTrigger event to PullTrigger Method
		GvrViewer.Instance.OnTrigger += PullTrigger;
		rb = GetComponent<Rigidbody>();
	}
	
	private void PullTrigger() {
		
		Vector3 projectedVector = Vector3.ProjectOnPlane(FrogHead.Gaze.direction, Vector3.up);
		Vector3 jumpvector = Vector3.RotateTowards(projectedVector, Vector3.up, JumpAngleInDegrees * Mathf.Deg2Rad, 0);
		//GazeText.enabled = !GazeText.enabled;
		print("Trigger Pulled");
		if(JumpReady) rb.velocity = jumpvector * JumpVelocity;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		print("I've Just Collided");
		JumpReady = true;	
	}
	
	void OnCollisionExit(Collision collision)
	{
		print("I'm not longer colliding");	
		JumpReady = false;	
	}
	
	// Update is called once per frame
	void Update () {
		FrogHead = FindObjectOfType<GvrHead>();
		GazeText.text = FrogHead.Gaze.ToString();
		
		//print (Gaze.Gaze);
	}
}
