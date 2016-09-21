using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    //zmiene do ulepszania obiektów
    private SpriteRenderer spriterenderer;
    private Collider2D coll;
    public Sprite[] sprite;
    public int level = 1;
    Spawn sp;
    

    void Start ()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        coll = gameObject.GetComponent<Collider2D>();
        sp = gameObject.GetComponentInChildren<Spawn>();
    }
	
	
	void Update ()
    {
        //kiedy jest nacisk na ekran to zwieksza się poziom
        if (isTouch())
        {
            level++;
        }
        //zmienianie cp i spirtów pod wpływem jaki budynejk ma poziom
        if (level == 1)
        {
            spriterenderer.sprite = sprite[0];
            sp.waitMax = 1;
            sp.waitMin = 1;
        }
        if (level == 2)
        {
            spriterenderer.sprite = sprite[1];
            sp.waitMax = 4;
            sp.waitMin = 3;
        }
        if (level == 3)
        {
            spriterenderer.sprite = sprite[2];
            sp.waitMax = 3;
            sp.waitMin = 2;
        }
        if (level > 3) level = 1;

    }

    //funkcja do sprawdzenia zcy gracz naciska na ekran
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
