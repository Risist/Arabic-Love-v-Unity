using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject woman;
    public float Wait,Wait1;
    public Transform spawnV;
    public float startWait = 1;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
                Instantiate(woman, spawnV.position, spawnV.rotation);
                yield return new WaitForSeconds(Random.Range(Wait,Wait1));

        }
    }

}



