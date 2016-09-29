using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/*

usage:


 
*/

[System.Serializable]
public class Timer
{
    public Timer( float _actualTime, float _cd )
    {
        actualTime = _actualTime;
        cd = _cd;
    }
    public Timer()
    {
    }
    // actual time of timmer
    public float actualTime = 0;
    // how much time have to be elapsed from last reset to be ready
    public float cd = 1;

    // should be called somewhere in middle Update event of your script to count time
    public void update()
    {
        actualTime += Time.deltaTime;
    }

    // resets actual time to 0
    public void restart()
    {
        actualTime = 0;
    }

    // returns true if time elapsed from last reset is greather than passed argument (cd)
    public bool isReady( float cd)
    {
        return actualTime >= cd;
    }
    // returns true if time elapsed from last reset is greather than public member of this class (cd)
    public bool isReady()
    {
        return isReady(cd);
    }
    // the same as above but automatically resets if timer was ready
    public bool isReadyRestart(float cd)
    {
        if( actualTime >= cd )
        {
            restart();
            return true;
        }
        return false;
    }
    // the same as above but automatically resets if timer was ready
    public bool isReadyRestart()
    {
        return isReadyRestart(cd);
    }
}
