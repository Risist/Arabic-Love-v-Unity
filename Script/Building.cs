using UnityEngine;
using System.Collections;
using System;


/**

public abstract class Building : MonoBehaviour
{
    
    // graphical data
    public Sprite[] sprite;
    private SpriteRenderer spriterenderer;

    // money data
    MoneyManager mm;
    public float costRatio = 50;
    public float minimalCost = 50;

    // leveling data
    public int level = 0;
    float getActualCost()
    {
        return minimalCost + costRatio * level;
    }
    int getMaxLevel()
    {
        // maxLevel is depended from how much graphics are added
        return sprite.Length;
    }
    void levelUp()
    {
        // stay under max lvl
        // pay for upgrade if has enough money
        // if not do nothing
        if(level < getMaxLevel() && mm.pay(getActualCost()))
        {
            ++level; // lvl up
            updateLvlBonus(); // lvl bonus
            spriterenderer.sprite = sprite[level]; // visualization
        }


    }
    // what happens when level is increased?
    // update our bonus!
    // to override
    protected abstract void updateLvlBonus();

    // hud data
    BuildHUD bhud;
    Collider2D coll;

    void Start()
    {
        mm = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyManager>();
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        spriterenderer.sprite = sprite[level]; // !!!!! level nie 0
        
        // hud
        bhud = GameObject.FindGameObjectWithTag("BuildHud").GetComponent<BuildHUD>();
        coll = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        if (bhud.check == true)
        {
            if (isTouch())
            {
                levelUp();
            }
        }
    }

    // to mnie martwi ...
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
        if (Input.GetMouseButtonUp(0)) // dlaczego 0 a nie "fire1" ???????????????
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

// w innym pliku
public class BuildingHome : Building
{
    public RandomSpawn spawner;

    public float baseMinCd = 10, ratioMinCd = 1;
    public float baseMaxCd = 20, ratioMaxCd = 1;

    protected override void updateLvlBonus()
    {
        spawner.cdMin = baseMinCd - level * ratioMinCd;
        spawner.cdMax = baseMaxCd - level * ratioMaxCd;
    }

}
/**/

/**/
public class Building : MonoBehaviour {

    private SpriteRenderer spriterenderer;
    public Sprite[] sprite;

    MoneyManager mm;
    public float costRatio = 50;
    public float minimalCost = 50;

    Collider2D coll;
    Shop bhud;
    Spawn sp;

    public int level = 0;
    float getActualCost()
    {
        return minimalCost + costRatio * level;
    }
    int getMaxLevel()
    {
        
        return sprite.Length;
    }
    void levelUp()
    {
        
        if (level < getMaxLevel() && mm.pay(getActualCost()))
        {
            ++level;
            updateLvlBonus();
            spriterenderer.sprite = sprite[level];
        }


    }

    public virtual void updateLvlBonus()
    {
    }

    void Start ()
    {
        sp = GetComponentInChildren<Spawn>();
        mm = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyManager>();
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        coll = gameObject.GetComponent<Collider2D>();
        spriterenderer.sprite = sprite[level];
        bhud = GameObject.FindGameObjectWithTag("BuildHud").GetComponent<Shop>();
    }
	
	
	void Update ()
    {
        if(bhud.check == true)
        {
            if (isTouch())
            {
                levelUp();
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

    
        
}
/**/
