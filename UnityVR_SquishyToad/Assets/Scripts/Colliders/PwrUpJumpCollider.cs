using UnityEngine;
using System.Collections;

public class PwrUpJumpCollider : MonoBehaviour
{

    public float rotateRate;            //Rate at which the pwrup rotates around the Z axis per-second

    private GameState gameState;
    private Player player;
    private bool waitForDestroy;        //This object is waiting to be destroyed;
    AudioSource src;
    // Use this for initialization
    void Start()
    {
        waitForDestroy = false;
        gameState = FindObjectOfType<GameState>();
        src = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Turns the power-up object via rotateRate
        float rotDelta = rotateRate * Time.deltaTime;           //Degrees to turn
        transform.Rotate(Vector3.forward, rotDelta);            //Spins this way to account for -90 rotation in the X axis
    }

    void OnTriggerEnter(Collider collider)
    {
        player = collider.gameObject.GetComponent<Player>();
        if (player) {
            print("Power Up is being set TRUE");
            gameState.PwrUpJump = true;
            this.enabled = false;
            this.transform.localScale = new Vector3(0, 0, 0);   //Set the scale to nothing so that it "Poofs" out of existence.
            src.Play();
        }
    }

}
