using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    MoveTo moveTo;
    public bool move;

    public void computeMousePos()
    {
        float camDistance = Camera.main.transform.position.y - transform.position.y;
        moveTo.destination = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDistance));
    }

    // Use this for initialization
    void Start () {

        moveTo = GetComponent<MoveTo>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButton("Fire1"))
        {
            computeMousePos();
            move = true;
        }
        else
        {
            move = false;
        }
            
    }
}
