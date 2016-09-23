using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowMeThisMoney : MonoBehaviour {

    private Text text;
    MoneyManager mm;
	
	void Start () {

        text = GetComponent<Text>();
        mm = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyManager>();

	}
	
	
	void Update () {

        text.text = "" + mm.actualMoney;
	
	}
}
