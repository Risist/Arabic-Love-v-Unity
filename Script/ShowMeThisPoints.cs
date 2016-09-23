using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowMeThisPoints : MonoBehaviour {

    Text text;
    Mosque mosque;

	void Start ()
    {
        text = gameObject.GetComponent<Text>();
        mosque = GameObject.FindGameObjectWithTag("Mosque").GetComponent<Mosque>();
	}
	
	
	void Update ()
    {
        text.text = "" + mosque.points;
	
	}
}
