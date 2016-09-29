using UnityEngine;
using System.Collections;

/// <summary>
/// responsibilites:
/// 1) find aim
/// 2) gain atention of the aim
/// 3) move to escape point
/// 4) kill aim
/// 
/// rules for finding the aim:
/// a) better is closer one
/// 
/// gaining the atention:
/// need to edit script "follow player"
/// add new mode in with the aim is following us
/// 
/// escape point will be saved in GameControler script
/// as Circle collider
/// when attention is gained then it is checked 
/// if we are in the right place ( our collider is colliding with enemys)
/// kill the aim
/// </summary>

public class KidnapperControler : MonoBehaviour
{
    // settings
    public float captureDistance = 2;


    // aim data
    int idEscape;
    GameObject aim;
    WifeControler aimWifeControler;
    FollowPlayer aimFollowPlayer;
    float actualEvaluation;
    void resetEvaluation()
    {
        aim = null;
        actualEvaluation = 0;
        aimWifeControler = null;
    }
    void chectForPossibleAim(GameObject possibleAim)
    {
        // aim must have a WifeControler
        WifeControler possibleWifeControler = possibleAim.GetComponent<WifeControler>();
        if (possibleWifeControler == null )
            return;

        float newEvaluation = 1 / (possibleAim.transform.position - transform.position).sqrMagnitude;

        if (possibleWifeControler.rendererWife.enabled == true)
            newEvaluation *= 100000000;

            if (newEvaluation > actualEvaluation)
        {
            actualEvaluation = newEvaluation;
            aim = possibleAim;
            aimWifeControler = possibleWifeControler;
            aimFollowPlayer = aim.GetComponent<FollowPlayer>();
        }
    }


    // references
    MoveTo moveTo;
    RandomMovement randomMovement;

    GameControler gameControler;

    // Use this for initialization
    void Start()
    {
        moveTo = GetComponent<MoveTo>();
        // always use autoMove
        moveTo.autoMove = true;

        randomMovement = GetComponent<RandomMovement>();


        // setGameControler
        gameControler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControler>();

        idEscape = Random.Range(0, gameControler.kidnapperEscape.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //moveTo.destination = gameControler.kidnapperEscape.position;
        //randomMovement.enabled = false;
        if (aim != null)
        {
            if (aimFollowPlayer.mode == FollowPlayer.Mode.followKidnapper)
            {
                // move to escape place (with aim which is following us)
                moveTo.destination = gameControler.kidnapperEscape[idEscape].position;
                if ((aim.transform.position - gameControler.kidnapperEscape[idEscape].position).sqrMagnitude < gameControler.kidnapperEscapeRadius * gameControler.kidnapperEscapeRadius)
                {
                    aim.GetComponent<HpControler>().dealDamage(-10000, gameObject);
                }

            }
            else
            {
                // move to aim
                moveTo.destination = aim.transform.position;

                // check if can capture
                if((aim.transform.position - transform.position).sqrMagnitude < captureDistance * captureDistance)
                {
                    // if yes change follow mode of aim
                    aimFollowPlayer.mode = FollowPlayer.Mode.followKidnapper;
                    aimFollowPlayer.setPlayer(gameObject); 
                }

            }

            randomMovement.enabled = false;
        }
        else
        {
            randomMovement.enabled = true;
        }


        // next frame check For New aim, so need to reset actual state of evaluation
        resetEvaluation();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.isTrigger == false)
            chectForPossibleAim(other.gameObject);
    }
    void OnDestroy()
    {
        if(aim != null)
        {
            aimFollowPlayer.mode = FollowPlayer.Mode.free;
        }
    }
}

/*public class KidnapperControler : MonoBehaviour {

    float bestEvaluation = 9999999999999999;
    GameObject aim = null;
    MoveTo moveTo;
    RandomMovement randomMovement;

    GameControler gameControler;
    

    // the less evaluation the better aim

    void resetEvaluation()
    {
        bestEvaluation = 9999999999999999;
        aim = null;
    }
    void checkEvaluation(float evaluation, GameObject possibleAim)
    {
        if(evaluation < bestEvaluation)
        {
            bestEvaluation = evaluation;
            aim = possibleAim;
        }
    }
    void checkEvaluation(GameObject possibleAim)
    {
        WifeControler wifeControler = possibleAim.GetComponent<WifeControler>();
        if (wifeControler != null) // && wifeControler.rendererWife.enabled == true)
        {
            checkEvaluation( (gameObject.transform.position - possibleAim.transform.position).sqrMagnitude, possibleAim);
        } 
    }

	// Use this for initialization
	void Start () {

        resetEvaluation();
        moveTo = GetComponent<MoveTo>();
        moveTo.autoMove = true;

        randomMovement = GetComponent<RandomMovement>();

        gameControler = GameObject.FindGameObjectWithTag("GameControler").GetComponent<GameControler>();

	}
	
	// Update is called once per frame
	void Update () {
        
        if(aim != null)
        {
            if (aim.GetComponent<FollowPlayer>().mode == FollowPlayer.Mode.following)
            {
                moveTo.destination = gameControler.kidnapperEscape.transform.position;
            }
            else
            {
                moveTo.destination = aim.transform.position;
            }

            randomMovement.enabled = false;
        }
        else
        {
            randomMovement.enabled = true;
        }

        //if (aim.GetComponent<FollowPlayer>().mode == FollowPlayer.Mode.following &&
          //     aim.GetComponent<FollowPlayer>().GetPlayer() == gameObject && colliderToEscape.IsTouching())

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (aim != null)
            return;

        checkEvaluation(other.gameObject);
    }
}*/
