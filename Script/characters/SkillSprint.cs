using UnityEngine;
using System.Collections;

/// <summary>
/// 1. if sprint key is not pressed activate playerMove
/// and let it control movement
/// 2. if sprint key is pressed change visualisation;
/// once the key is down rotate player to point
/// and then move player forward until sprint key is pressed
/// 3. when sprint key is up again enable playerMovement script and change visualisation to basic version
/// 
/// </summary>

public class SkillSprint : MonoBehaviour {

    public Timer cdSprint;

    public float multiplaySpeed = 2;
    bool atMove = false;

    PlayerMovement playerMovement;
    MoveTo moveTo;



    public GameObject rendererNormal;
    public GameObject rendererSprint;

    // Use this for initialization
    void Start () {
        playerMovement = GetComponent<PlayerMovement>();
        moveTo = GetComponent<MoveTo>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        cdSprint.update();

        if( atMove)
        {
            playerMovement.computeMousePos();
            moveTo.autoMove = false;
            rendererSprint.SetActive(true);
            rendererNormal.SetActive(false);

            moveTo.moveToDestinationNonCheck(moveTo.movementSpeed * multiplaySpeed);

            if(Input.GetButtonUp("Fire2"))
            {
                atMove = false;
                cdSprint.restart();
            }
        }
        else
        {
            rendererSprint.SetActive(false);
            rendererNormal.SetActive(true);

            if ( Input.GetButtonDown("Fire2") && cdSprint.isReady() )
            {
                playerMovement.computeMousePos();
                moveTo.rotateToDestination();
                atMove = true;
            }
            else
            {
                playerMovement.enabled = true;
                moveTo.autoMove = true;
            }
        }


    }
}
