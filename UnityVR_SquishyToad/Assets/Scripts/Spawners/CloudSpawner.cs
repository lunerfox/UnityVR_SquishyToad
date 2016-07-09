using UnityEngine;
using System.Collections;

//Spawns clouds into the scene
public class CloudSpawner : MonoBehaviour {

    public GameObject[] cloudPrefabs;   //Array of clouds available
    public float heightOffset;
    public float startOffset;
    public float minDistance;           //Minimum Distance between clouds
    public float maxDistance;           //Maximum Distance between clouds
    public float maxRenderDistance;     //Distance away from the player to render clouds at (On both ends?)

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
