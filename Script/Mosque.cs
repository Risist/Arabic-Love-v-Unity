using UnityEngine;
using System.Collections;

public class Mosque : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.gameObject.GetComponent<WifeControler>() != null)
        {
            WifeControler wifeControler = other.gameObject.GetComponent<WifeControler>();
            wifeControler.setMarrige(true);
            wifeControler.enabled = true;

            other.gameObject.GetComponent<FollowPlayer>().enabled = false;

        }
    }
}
