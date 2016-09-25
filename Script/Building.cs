using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    //zmiene do ulepszania obiektów
    MoneyManager mm;
    private SpriteRenderer spriterenderer;
    private Collider2D coll;
    public Sprite[] sprite;
    public int level = 0;
    BuildHUD bhud;
    public float[] upgradeCost;
    public float maxCd=8, minCd=7;


    void Start ()
    {
        mm = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyManager>();
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        coll = gameObject.GetComponent<Collider2D>();
        spriterenderer.sprite = sprite[0];
        bhud = GameObject.FindGameObjectWithTag("BuildHud").GetComponent<BuildHUD>();
    }
	
	
	void Update ()
    {
        if(bhud.check == true)
        {
            if (isTouch())
            {
                ++level;
                if (level > 2) level = 2;
                if(mm.pay(upgradeCost[level]))
                {
                    UpgradeBuilding(level,minCd,maxCd,sprite[level],spriterenderer);
                }
                else
                {
                    --level;
                }
            }
        }
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

    public virtual void UpgradeBuilding(int level,float minCd,float maxCd,Sprite sprite,SpriteRenderer spriterenderer)
    {

    }
        
}
