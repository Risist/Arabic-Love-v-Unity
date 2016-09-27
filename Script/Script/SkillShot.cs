using UnityEngine;
using System.Collections;

public class SkillShot : MonoBehaviour {

    // to Spawn
    public GameObject ammoPrefab;

    public Timer timerBetweenShots;

    public float actualAmmo = 0;
    public float maxAmmo = 10;
    public bool hasEnoughAmmo()
    {
        return actualAmmo > 0;
    }
    public bool useAmmo()
    {
        if(hasEnoughAmmo())
        {
            --actualAmmo;
            return true;
        }
        return false;
    }

    public Timer timerGiveAmmo;

    PlayerMovement playerMovement;
    MoveTo moveTo;
    bool readyToShot = true;


	// Use this for initialization
	void Start () {
        playerMovement = GetComponentInParent<PlayerMovement>();
        moveTo = GetComponentInParent<MoveTo>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timerBetweenShots.update();
        timerGiveAmmo.update();

        if (Input.GetButton("Fire2"))
        {
            if (readyToShot && timerBetweenShots.isReady() && useAmmo())
            {
                timerBetweenShots.restart();
                Instantiate(ammoPrefab, transform.position, transform.rotation);
            }
            playerMovement.enabled = false;
            playerMovement.computeMousePos();
            moveTo.rotateToDestination();
            moveTo.autoMove = false;

            if (hasEnoughAmmo() == false)
            {
                readyToShot = false;
            }
        }
        else
        {
            playerMovement.enabled = true;
            moveTo.autoMove = true;

            readyToShot = true;
        }

        if(Input.GetButtonUp("Fire2"))
        {
            moveTo.destination = transform.position;
        }

        

        if( actualAmmo < maxAmmo && timerGiveAmmo.isReadyRestart() )
        {
            actualAmmo++;
        }

	}
}
