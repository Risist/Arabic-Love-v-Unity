using UnityEngine;
using System.Collections;

public class BuildHouse : MonoBehaviour {

    public GameObject newHouse;
    private Collider2D coll;
    

	
	void Start ()
    {
        coll = gameObject.GetComponent<Collider2D>();
	}
	
    
	
	void Update ()
    {
        if (isTouch())
        {
            Instantiate(newHouse,gameObject.transform.position,gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    public bool isTouch()
    {
        bool result = false;
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 touchpos = new Vector2(wp.x, wp.y);
                if (coll == Physics2D.OverlapPoint(touchpos))
                {
                    result = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {

            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousepos = new Vector2(wp.x, wp.y);
            if (coll == Physics2D.OverlapPoint(mousepos))
            {
                result = true;
            }

        }
        return result;
    }
}
