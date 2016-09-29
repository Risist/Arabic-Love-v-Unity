using UnityEngine;
using System.Collections;

public class SuicideController : MonoBehaviour {

    public GameObject explosionPrefab;
    public Timer timeToExplosion;
    MoveTo moveTo;

    void Start () {

        moveTo = GetComponent<MoveTo>();
        moveTo.autoMove = true;

        Transform suicidePlace = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControler>().suicidePlace;
        float maxOffsetFromCenter = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControler>().suicideRadius;

        Vector3 offset =  Quaternion.Euler(0, 0, Random.Range(0, 360))  * new Vector3(Random.Range(0, maxOffsetFromCenter), 0);
        moveTo.destination = suicidePlace.transform.position + offset;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToExplosion.update();

        if (moveTo.check() == false || timeToExplosion.isReady() )
        {

            //Debug.Log("destination " + moveTo.destination.ToString());
            //Debug.Log("My position " + transform.position.ToString());

            Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)) );
            GetComponent<HpControler>().dealDamage(-10000, gameObject);
            Destroy(gameObject);

            //Vector3 offset = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(Random.Range(0, maxOffsetFromCenter), 0);
            //moveTo.destination = centerOfDestination.position + offset;
        }
    }
}
