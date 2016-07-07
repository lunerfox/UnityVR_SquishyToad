using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour {
    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "" + FindObjectOfType<GameState>().HighScore;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    
}
