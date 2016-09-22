using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour {

    // how much money did you have
    public float actualMoney = 0;
    // reset this value if you want to give the uint money every certain time 
    // ( by default one second )
    public float incomePerSecond = 0;
    // by default income is every second but it could be changed
    public Timer incomeTimer = new Timer(0,1);

    // check if you are able to pay cost
    public bool hasEnoughMoney( float cost)
    {
        return actualMoney > cost;
    }
    // if is able to pay a fee do so
    // returns if has enough money to pay
    // if has not does nothing
    // usage example: if( pay(cost)) build a building;
    public bool pay(float cost)
    {
        if( hasEnoughMoney(cost))
        {
            actualMoney -= cost;
            return true;
        }
        return false;
    }
    // used to change actual money without checking if has enough money
    // best situation to use is when you want to increase an amount of money
    // for example when you collect a coin or so
    public void addIncome( float income )
    {
        actualMoney += income;
    }


	
	
	// Update is called once per frame
	void Update () {

        incomeTimer.update();
        if(incomeTimer.isReadyRestart())
        {
            actualMoney += incomePerSecond;
        }
	}
}
