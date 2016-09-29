using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    // timers
    public Timer tToStartFollow;
    public Timer tAttention;

    // followerData
    GameObject player;
    float playersPriority = 0.0f;
    void resetFollower()
    {
        player = null;
        playersPriority = 0.0f;
    }
    bool setFollower( float priority, GameObject _object)
    {
        if (priority > playersPriority)
        {
            player = _object;
            playersPriority = priority;
            return true;
        }
        return false;
    }

    // references
    MoveTo moveTo;
    RandomMovement randomMovement;

    public GameObject GetPlayer()
    {
        return player;
    }
    public void setPlayer( GameObject newPlayer)
    {
        player = newPlayer;
    }

    public enum Mode
    {
        free,
        gainingAttention,
        following,
        disabled,
        followKidnapper
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
        else if (mode == Mode.followKidnapper)
        {
            moveTo.destination = player.transform.position;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<FollowCapture>() != null && mode == Mode.free)
        {
            mode = Mode.gainingAttention;
            tToStartFollow.restart();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

        FollowCapture followCapture = other.GetComponent<FollowCapture>();
        if ( followCapture != null && mode == Mode.gainingAttention)
        {
            if (tToStartFollow.isReady() && setFollower(followCapture.priority, other.gameObject) )
            {
                mode = Mode.following;
                tAttention.restart();
                randomMovement.enabled = false;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<FollowCapture>() != null && mode == Mode.gainingAttention)
        {
            resetFollower();
            mode = Mode.free;
        }
    }
}
