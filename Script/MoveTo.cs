using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

    ///// movement
    public float movementSpeed = 5;
    public float minimalDistance = 1;
    public Vector3 destination;

    // change rotation to destination
    public void rotateToDestination()
    {
        float angleRad = Mathf.Atan2(destination.y - transform.position.y, destination.x - transform.position.x);
        transform.rotation = Quaternion.Euler(0, 0, (180 / Mathf.PI) * angleRad + 90);
    }
    // move forward until reach destination
    // not valid if rotateToDestination is ommited
    public void moveToDestination()
    {
        moveToDestination(movementSpeed);
    }
    // the same as above but you can pass movement speed manually
    public void moveToDestination(float movementSpeed)
    {
        Vector2 delta = new Vector2(transform.position.x - destination.x, transform.position.y - destination.y);

        if (delta.sqrMagnitude > minimalDistance * minimalDistance)
            transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }

    // only moves forward
    public void moveToDestinationNonCheck()
    {
        moveToDestinationNonCheck(movementSpeed);
    }
    // the same as above but you can pass movement speed manually
    public void moveToDestinationNonCheck(float movementSpeed)
    {
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }

    // check if destination is reached
    public bool check()
    {
        Vector2 delta = new Vector2(transform.position.x - destination.x, transform.position.y - destination.y);
        return delta.sqrMagnitude > minimalDistance * minimalDistance;
    }
    // the same as above but with manually setable minimal distance
    public bool check( float minimalDistance)
    {
        Vector2 delta = new Vector2(transform.position.x - destination.x, transform.position.y - destination.y);
        return delta.sqrMagnitude > minimalDistance * minimalDistance;
    }

    // if you want to set up everything manually turn it to false
    public bool autoMove = true;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if( autoMove )
        {
            rotateToDestination();
            moveToDestination();
        }
	}
}
