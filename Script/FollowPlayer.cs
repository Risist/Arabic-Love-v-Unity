using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public Timer tToStartFollow;
    public Timer tAttention;
    GameObject player;
    MoveTo moveTo;
    RandomMovement randomMovement;

    public enum Mode
    {
        free,
        gainingAttention,
        following,
        disabled
    };
    public Mode mode = Mode.free;

	// Use this for initialization
	void Start ()
    {
        moveTo = GetComponent<MoveTo>();
        randomMovement = GetComponent<RandomMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        tToStartFollow.update();
        tAttention.update();

	    if( mode == Mode.following)
        {
            moveTo.destination = player.transform.position;
            if (tAttention.isReady())
            {
                mode = Mode.free;
                randomMovement.enabled = true;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && mode == Mode.free)
        {
            mode = Mode.gainingAttention;
            tToStartFollow.restart();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if( other.gameObject.tag == "Player" && mode == Mode.gainingAttention)
        {
            if (tToStartFollow.isReady())
            {
                mode = Mode.following;
                player = other.gameObject;
                tAttention.restart();
                randomMovement.enabled = false;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && mode == Mode.gainingAttention)
        {
            mode = Mode.free;
        }
    }
}
