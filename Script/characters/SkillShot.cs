using UnityEngine;
using System.Collections;

public class SkillShot : MonoBehaviour {

    // to Spawn
    public GameObject ammoPrefab;
    public Transform spawnTransform;

    public Timer timerBetweenShots;

    public float actualAmmo = 0;
    public float maxAmmo = 10;

    Animator animator;
    AnimatorStateInfo asi;
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
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timerBetweenShots.update();
        timerGiveAmmo.update();
        asi = animator.GetCurrentAnimatorStateInfo(0);
        if (Input.GetButton("Fire2"))
        {
            //animator.speed = 3.0f;
            animator.SetBool("Fire", true);
            if (readyToShot && timerBetweenShots.isReady() && useAmmo() && asi.normalizedTime > 2.5f)
            {
                timerBetweenShots.restart();
                Instantiate(ammoPrefab, spawnTransform.position, spawnTransform.rotation);
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
            //animator.speed = 1.0f;
            animator.SetBool("Fire", false);
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

        if(playerMovement.move == true)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

	}
}
