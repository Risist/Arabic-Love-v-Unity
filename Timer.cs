using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class Timer
{
    public float actualTime = 0;
    public float cd = 1;

    public void update()
    {
        actualTime += Time.deltaTime;
    }

    public void restart()
    {
        actualTime = 0;
    }

    public bool isReady( float cd)
    {
        return actualTime >= cd;
    }
    public bool isReady()
    {
        return isReady(cd);
    }
    public bool isReadyRestart(float cd)
    {
        if( actualTime >= cd )
        {
            restart();
            return true;
        }
        return false;
    }
    public bool isReadyRestart()
    {
        return isReadyRestart(cd);
    }
}
