using UnityEngine;
using System.Collections;

public class SuicideController : MonoBehaviour {

    public GameObject explosionPrefab;
    public Vector3 centerOfDestination;
    public float maxOffsetFromCenter;
    public Timer timeToExplosion;
    MoveTo moveTo;

    void Start () {

        moveTo = GetComponent<MoveTo>();
        moveTo.autoMove = true;

        Vector3 offset =  Quaternion.Euler(0, 0, Random.Range(0, 360))  * new Vector3(Random.Range(0, maxOffsetFromCenter), 0);
        moveTo.destination = centerOfDestination + offset;
        
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
            Destroy(gameObject);

            //Vector3 offset = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(Random.Range(0, maxOffsetFromCenter), 0);
            //moveTo.destination = centerOfDestination.position + offset;
        }
    }
}
