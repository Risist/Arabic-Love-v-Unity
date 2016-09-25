using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{

    //zmiene do spawnowania
    public GameObject woman;
    public float waitMax, waitMin;
    public float startSpawn = 1;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnWaves());

    }

    //Spawnowanie żon
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        {
            Instantiate(woman, gameObject.transform.position,gameObject.transform.rotation);
            yield return new WaitForSeconds(Random.Range(waitMin, waitMax));

        }
    }
}
