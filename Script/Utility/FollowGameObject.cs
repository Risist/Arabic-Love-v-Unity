using UnityEngine;
using System.Collections;

public class FollowGameObject : MonoBehaviour {

    public bool position = true;
    public bool rotation = false;
    public Vector3 offsetPosition;
    public GameObject objectToFollow;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = objectToFollow.transform.position;

        if (position)
            transform.position = pos + offsetPosition;
        if (rotation)
        {
            float angleRad = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x);
            transform.rotation = Quaternion.Euler(0, 0, (180 / Mathf.PI) * angleRad + 90);
        }

    }
}
