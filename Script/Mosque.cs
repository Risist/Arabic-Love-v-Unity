using UnityEngine;
using System.Collections;

public class Mosque : MonoBehaviour {

    MoneyManager mm;
    private Collider2D coll;
    BuildHUD bhud;
    private  int level=1;
    private SpriteRenderer spriterenderer;
    public Sprite[] sprite1;
    public int points = 0;

    void Start ()
    {
        coll = gameObject.GetComponent<Collider2D>();
        mm = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyManager>();
        bhud = GameObject.FindGameObjectWithTag("BuildHud").GetComponent<BuildHUD>();
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
    }
	
	
	void Update ()
    {
        if(bhud.check == true)
        {
            if (isTouch())
            {
                level++;
                Upgrade(level);
            }
        }
        
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.isTrigger == false &&
            other.gameObject.GetComponent<WifeControler>() != null
            && other.gameObject.GetComponent<FollowPlayer>().mode == FollowPlayer.Mode.following)
        {
            WifeControler wifeControler = other.gameObject.GetComponent<WifeControler>();
            wifeControler.setMarrige(true);
            wifeControler.enabled = true;

            //other.gameObject.GetComponent<FollowPlayer>().enabled = false;
            other.gameObject.GetComponent<FollowPlayer>().mode = FollowPlayer.Mode.disabled;

            points++;
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

    void Upgrade(int level)
    {
        if(mm.hasEnoughMoney(40))
        {
            if (level == 2)
            {
                if (mm.pay(40))
                {
                    spriterenderer.sprite = sprite1[0];
                }
            }
        }
        if(mm.hasEnoughMoney(80))
        {
            if (level == 3)
            {
                if (mm.pay(80))
                {
                    spriterenderer.sprite = sprite1[1];
                }
            }
        }
        if (level > 3) level = 3;
    }

}

