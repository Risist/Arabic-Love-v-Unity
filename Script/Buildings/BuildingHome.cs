using UnityEngine;
using System.Collections;

public class BuildingHome : Building
{
    public RandomSpawn spawner;

    public float baseMinCd = 10, ratioMinCd = 1;
    public float baseMaxCd = 20, ratioMaxCd = 1;

    protected override void updateLvlBonus()
    {
        spawner.minCd = baseMinCd - level * ratioMinCd;
        spawner.maxCd = baseMaxCd - level * ratioMaxCd;
    }

}

/*
public class BuildingHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}*/
