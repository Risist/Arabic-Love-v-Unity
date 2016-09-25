using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {

    public GameObject[] objects;
    public float[] chances;
    public Timer cd;
    Building build;

    void Start()
    {
        build = GetComponentInParent<Building>();
    }

    void Update()
    {
        cd.update();
        if (cd.isReadyRestart(Random.Range(build.minCd,build.maxCd)))
        {
            float sum = 0;
            foreach (float it in chances)
                sum += it;
            float randed = Random.Range(0, sum);

            float lastSum = 0;

            for (int i = 0; i < objects.Length; ++i)
                if (randed > lastSum && randed < lastSum + chances[i])
                {
                    Instantiate(objects[i], gameObject.transform.position, gameObject.transform.rotation);
                    break;
                }
                else
                {
                    lastSum += chances[i];
                }
            
        }
    }
}
