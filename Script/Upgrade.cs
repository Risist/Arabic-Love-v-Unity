using UnityEngine;
using System.Collections;

public class Upgrade : Building {


    public RandomSpawn spawner;

    public float baseMinCd = 10, ratioMinCd = 1;
    public float baseMaxCd = 20, ratioMaxCd = 1;

    public override void updateLvlBonus()
    {
        
        spawner.minCd = baseMinCd - level * ratioMinCd;
        spawner.maxCd = baseMaxCd - level * ratioMaxCd;
    }

}
