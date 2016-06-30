using UnityEngine;
using System.Collections;

public class AudioCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter(Collision collision) {
        print("Collide with Audio Source");
        AudioSource Audio = GetComponent<AudioSource>();
        Audio.Play();
    }
}
