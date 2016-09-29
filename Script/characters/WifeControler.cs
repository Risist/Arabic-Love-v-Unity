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

    // Use this for initialization
    void Start ()
    {
        setMarrige(false);
    }

    


    // Update is called once per frame
    void Update ()
    {

	}
}
