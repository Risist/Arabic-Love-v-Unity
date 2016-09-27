using UnityEngine;
using System.Collections;

public class DieOnCollision : MonoBehaviour {

    public bool onTrigger;
    public bool onCollision;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(onTrigger && other.isTrigger == false)
            Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collider2D other)
    {
        if(onCollision && other.isTrigger == false)
            Destroy(gameObject);
    }
}
