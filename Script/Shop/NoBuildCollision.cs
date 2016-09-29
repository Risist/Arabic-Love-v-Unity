using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoBuildCollision : MonoBehaviour {
    
    bool onCollision = false;

    public List<GameObject> colliders;
    public void rengister(GameObject toRengister)
    {
        colliders.Add(toRengister);
    }
    public bool isOnCollision()
    {
        bool r = onCollision;
        onCollision = false;
        return r;
    }
    

	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerStay2D(Collider2D other)
    {
       

        if (other.isTrigger == false)
        {
            Debug.Log("Tag:" + other.gameObject.tag);
            if (other.gameObject.tag == "Building")
            {
                onCollision = true;
            }
        }
    }
}
