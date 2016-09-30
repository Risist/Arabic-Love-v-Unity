﻿using UnityEngine;
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
        asi = animator.GetCurrentAnimatorStateInfo(0);
        timerBetweenShots.update();
        timerGiveAmmo.update();

        if (Input.GetButton("Fire2"))
        {
            animator.SetBool("Fire", true);
            
            if (readyToShot && timerBetweenShots.isReady() && useAmmo() && asi.normalizedTime>2.5f )
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

        
            animator.SetBool("Move", playerMovement.move);
        

	}
}
