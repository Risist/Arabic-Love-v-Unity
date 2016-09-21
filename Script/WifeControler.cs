using UnityEngine;
using System.Collections;

public class WifeControler : MonoBehaviour {

    MoveTo moveTo;

    // display data
    public SpriteRenderer rendererNormal;
    public SpriteRenderer rendererWife;

    public void setMarrige(bool isOn)
    {
        rendererNormal.enabled = !isOn;
        rendererWife.enabled = isOn;
    }


    // cd ChangeDestination
    public float cdChangeDestinationMin = 0.1f, cdChangeDestinationMax = 1.0f;
    Timer cdChangeDestination = new Timer();

    // change destination
    public float maxOffset = 20;

    // Use this for initialization
    void Start ()
    {
        setMarrige(false);

        moveTo = GetComponent<MoveTo>();
        moveTo.autoMove = true;

        cdChangeDestination.cd = Random.Range(cdChangeDestinationMin, cdChangeDestinationMax);
        cdChangeDestination.restart();
    }

    


    // Update is called once per frame
    void Update ()
    {
        //rotateToDestination();
        //moveToDestination();

        // change Destination
        cdChangeDestination.update();
        if( cdChangeDestination.isReadyRestart())
        {
            Vector3 offset = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(Random.Range(0,maxOffset), 0);

            
            moveTo.destination = transform.position + offset;
            
            cdChangeDestination.cd = Random.Range(cdChangeDestinationMin, cdChangeDestinationMax);
            cdChangeDestination.restart();
        }

	}
}
