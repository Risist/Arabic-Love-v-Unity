using UnityEngine;
using System.Collections;

public class Mosque : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.isTrigger == false &&
            other.gameObject.GetComponent<WifeControler>() != null
            && other.gameObject.GetComponent<FollowPlayer>().mode == FollowPlayer.Mode.following)
        {
            WifeControler wifeControler = other.gameObject.GetComponent<WifeControler>();
            wifeControler.setMarrige(true);
            wifeControler.enabled = true;

            //other.gameObject.GetComponent<FollowPlayer>().enabled = false;
            other.gameObject.GetComponent<FollowPlayer>().mode = FollowPlayer.Mode.disabled;
        }
    }
}
