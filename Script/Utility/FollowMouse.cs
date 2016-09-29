﻿using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
    

    public bool position;
    public bool rotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        if( position)
            transform.position = cameraPosition;
        if (rotation)
        {
            float angleRad = Mathf.Atan2(cameraPosition.y - transform.position.y, cameraPosition.x - transform.position.x);
            transform.rotation = Quaternion.Euler(0, 0, (180 / Mathf.PI) * angleRad + 90);
        }

    }
}
