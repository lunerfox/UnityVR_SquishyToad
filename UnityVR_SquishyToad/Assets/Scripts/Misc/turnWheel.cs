using UnityEngine;
using System.Collections;

//Rotates the wheels of a vehicle. Put script onto the wheel itself.

public class turnWheel : MonoBehaviour {

    //GameObject carModel;
    Vehicle vehicle;
    public float wheelRotationMod;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //Get the speed of the parent vehicle
        vehicle = transform.parent.parent.gameObject.GetComponent<Vehicle>();
        float vehicleSpeed = vehicle.speed;
        bool vehicleDirection = vehicle.direction;
        if (vehicleDirection)   transform.Rotate(0, 0, -vehicleSpeed * wheelRotationMod * 360 * Time.deltaTime);
        else                    transform.Rotate(0, 0, vehicleSpeed * wheelRotationMod * 360 * Time.deltaTime);
    }
}
