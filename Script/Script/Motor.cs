using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

    public float movementSpeed;
    public float movementSpeedFall;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        movementSpeed -= movementSpeedFall * Time.deltaTime;
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }
}
