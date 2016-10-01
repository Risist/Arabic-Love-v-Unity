using UnityEngine;
using System.Collections;
using System;


/**/

public class Building : MonoBehaviour
{
    
    // graphical data
    public Sprite[] sprite;
    private SpriteRenderer spriteRenderer;

    // money data
    MoneyManager moneyManager;
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
    bool canUpgrade()
    {
        int maxLvl = getMaxLevel() - 1;
        return level < maxLvl;
    }
    void levelUp()
    {
        // stay under max lvl
        // pay for upgrade if has enough money
        // if not do nothing
        

        if( canUpgrade() && moneyManager.pay(getActualCost()))
        {
            ++level; // lvl up
            updateLvlBonus(); // lvl bonus
            spriteRenderer.sprite = sprite[level]; // visualization
        }


    }
    // what happens when level is increased?
    // update our bonus!
    // to override
    protected virtual void updateLvlBonus()
    {

    }

    // hud data
    Collider2D coll;
    GameObject upgradeButton;
    FollowGameObject upgradeFollow;

    UpgradeManager upgradeManager;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        moneyManager = gameController.GetComponent<MoneyManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite[level]; 
        
        // hud
        coll = gameObject.GetComponent<Collider2D>();

        upgradeManager = gameController.GetComponentInChildren<UpgradeManager>();

        upgradeFollow = upgradeManager.upgradeButton.GetComponent<FollowGameObject>();
        upgradeButton = upgradeManager.upgradeButton;
    }

    void Update()
    {
        if (isMouseOnCollider(ProjectSettings.mouseTouch) && canUpgrade())
        {
            upgradeButton.SetActive(true);
            upgradeFollow.objectToFollow = gameObject;
        }

        if( upgradeFollow.objectToFollow == gameObject && upgradeManager.isPressed())
        {
            levelUp();
            if(canUpgrade() == false)
            {
                upgradeButton.SetActive(false);
            }
        }
    }
    
    public bool isMouseOnCollider(bool useMouse)
    {
        Vector3 wp;
        if(useMouse)
            wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        else
            wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        Vector2 touchpos = new Vector2(wp.x, wp.y);
        return coll == Physics2D.OverlapPoint(touchpos);
    }

}

/**
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

/**
public class Building : MonoBehaviour {

    private SpriteRenderer spriterenderer;
    public Sprite[] sprite;

    MoneyManager mm;
    public float costRatio = 50;
    public float minimalCost = 50;

    Collider2D coll;
    BuildHUD bhud;
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
        bhud = GameObject.FindGameObjectWithTag("BuildHud").GetComponent<BuildHUD>();
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
