using UnityEngine;
using System.Collections;

public class KidnapperControler : MonoBehaviour {

    float bestEvaluation = 0;
    GameObject aim = null;
    MoveTo moveTo;
    RandomMovement randomMovement;
    

    void resetEvaluation()
    {
        bestEvaluation = 0;
        aim = null;
    }
    void checkEvaluation(float evaluation, GameObject possibleAim)
    {
        if(evaluation >bestEvaluation)
        {
            bestEvaluation = evaluation;
            aim = possibleAim;
        }
    }
    void checkEvaluation(GameObject possibleAim)
    {
        WifeControler wifeControler = possibleAim.GetComponent<WifeControler>();
        if (wifeControler != null && wifeControler.rendererWife.enabled == true)
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
	}
	
	// Update is called once per frame
	void Update () {
        
        if(aim != null)
        {



            randomMovement.enabled = false;
        }
        else
        {
            randomMovement.enabled = true;
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (aim != null)
            return;

        checkEvaluation(other.gameObject);
    }
}
