using UnityEngine;
using System.Collections;

public class RemoveAfterDelay : MonoBehaviour {

    public float delay;

	void Start () {

        Destroy(gameObject, delay);
	}
}
