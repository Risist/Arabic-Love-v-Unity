using UnityEngine;
using System.Collections;

public class PlayerSprintControler : MonoBehaviour
{
    MoveTo moveTo;

    public Timer cdSprint;

    public SpriteRenderer rendererNormal;
    public SpriteRenderer rendererSprint;


    public float movementSpeedSprint = 15;
    public float movementSpeed = 5;

    protected bool activated = false;

    protected void countMousePos()
    {
        float camDistance = Camera.main.transform.position.y - transform.position.y;
        moveTo.destination = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDistance));
    }

    void Start()
    {
        moveTo = GetComponent<MoveTo>();
        moveTo.autoMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        countMousePos();
        cdSprint.update();



        if (activated)
        {
            moveTo.moveToDestinationNonCheck(movementSpeedSprint);
            if (Input.GetButtonUp("Fire2"))
            {
                activated = false;
                cdSprint.restart();
            }
            rendererSprint.enabled = true;
            rendererNormal.enabled = false;
        }
        else
        {
            rendererSprint.enabled = false;
            rendererNormal.enabled = true;

            if (cdSprint.isReady() && Input.GetButton("Fire2"))
            {
                activated = true;
                moveTo.rotateToDestination();
            }
            else
            {

                if (Input.GetButton("Fire1") && moveTo.check() )
                {
                    moveTo.rotateToDestination();
                    moveTo.moveToDestinationNonCheck(movementSpeed);
                }
            }
        }

    }
}

/**
public class PlayerSprintControler : MonoBehaviour
{
    public Timer cdSprint;

    public SpriteRenderer rendererNormal;
    public SpriteRenderer rendererSprint;


    public float movementSpeedSprint = 15;
    public float movementSpeed = 5;
    public float minimalDistance = 1;

    protected Camera cam;
    protected Transform my;
    protected float addictionalRotation = 90;

    protected Vector3 mousePos;

    protected bool activated = false;

    protected void countMousePos()
    {
        float camDistance = cam.transform.position.y - my.position.y;
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDistance));
    }

    // assume countMousePos is called before this
    protected void rotateToMouse()
    {
        float angleRad = Mathf.Atan2(mousePos.y - my.position.y, mousePos.x - my.position.x);
        my.rotation = Quaternion.Euler(0, 0, (180 / Mathf.PI) * angleRad + addictionalRotation);
    }
    protected void moveTo( float movementSpeed)
    {
        my.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }


    void Start()
    {
        cam = Camera.main;
        my = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update ()
    {
        countMousePos();
        cdSprint.update();

        
        
        if (activated)
        {
            moveTo(movementSpeedSprint);
            if (Input.GetButtonUp("Fire2"))
            {
                activated = false;
                cdSprint.restart();
            }
            rendererSprint.enabled = true;
            rendererNormal.enabled = false;
        }
        else
        {
            rendererSprint.enabled = false;
            rendererNormal.enabled = true;

            if (cdSprint.isReady() && Input.GetButton("Fire2"))
            {
                activated = true;
                rotateToMouse();
            }else
            {
                Vector2 delta = new Vector2(my.position.x - mousePos.x, my.position.y - mousePos.y);

                if (Input.GetButton("Fire1") && delta.sqrMagnitude > minimalDistance * minimalDistance)
                {
                    rotateToMouse();
                    moveTo(movementSpeed);
                }
            }
        }

    }
}
/**/
