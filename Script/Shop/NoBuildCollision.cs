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
        
        return r;
    }
    

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
        onCollision = false;
    }
    void OnTriggerStay2D(Collider2D other)
    {
       

        if (other.isTrigger == false)
        {
            if(ProjectSettings.debugLogEnabled_buildingTag)
                Debug.Log("Tag:" + other.gameObject.tag);
            if (other.gameObject.tag == "Building")
            {
                onCollision = true;
            }
        }
    }
}
