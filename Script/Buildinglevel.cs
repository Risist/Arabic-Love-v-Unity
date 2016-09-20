using UnityEngine;
using System.Collections;

public class Buildinglevel : MonoBehaviour {

    private SpriteRenderer spriterenderer;
    private Collider2D coll;
    public Sprite[] sprite;
    public int level = 1;
    private Spawn sp;
	
	void Start ()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        coll = gameObject.GetComponent<Collider2D>();
        sp = GetComponentInChildren<Spawn>();
    }
	
	
	void Update ()
    {
        if (isTouch())
        {
            level++;
        }
        if (level == 1)
        {
            spriterenderer.sprite = sprite[0];
            sp.Wait = 3;
            sp.Wait1 = 2;
        }
        if (level == 2)
        {
            spriterenderer.sprite = sprite[1];
            sp.Wait = 2;
            sp.Wait1 = 1;
        }
        if (level == 3)
        {
            spriterenderer.sprite = sprite[2];
            sp.Wait = 1;
            sp.Wait1 = 0.5f;
        }
        if (level > 3) level = 1;

    }

    public bool isTouch()
    {
        bool result = false;
        if(Input.touchCount == 1)
        {
            if(Input.touches[0].phase == TouchPhase.Ended)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 touchpos = new Vector2(wp.x, wp.y);
                if(coll == Physics2D.OverlapPoint(touchpos))
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
