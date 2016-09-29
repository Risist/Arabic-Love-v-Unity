using UnityEngine;
using System.Collections;


public class ShopCreateButton : MonoBehaviour
{

    // to check for payments
    public MoneyManager moneyManager;
    public float cost = 100;

    public GameObject prefabToSpawn;


    public Sprite spriteVisualisation;
    public GameObject spawnVisualisation;
    SpriteRenderer spawnRenderer;
    FollowMouse spawnFollowMouse;
    NoBuildCollision spawnNoBuildCollision;


    enum Mode
    {
        disabled,
        waitToUp,
        findPosition,
        findRotation
    }
    Mode mode = Mode.disabled;
    void setMode(Mode newMode)
    {
        mode = newMode;
        if (newMode == Mode.disabled)
        {
            spawnVisualisation.SetActive(false);
        } else if(newMode == Mode.findPosition)
        {
            spawnVisualisation.SetActive(true);
            spawnVisualisation.transform.rotation = Quaternion.Euler(0, 0, 0);
            spawnRenderer.sprite = spriteVisualisation;

            spawnFollowMouse.position = true;
            spawnFollowMouse.rotation = false;

        }else if( newMode == Mode.findRotation)
        {
            spawnVisualisation.SetActive(true);
            spawnRenderer.sprite = spriteVisualisation;


            spawnFollowMouse.position = false;
            spawnFollowMouse.rotation = true;
        }
    }
    public Shop shop;


    // Use this for initialization
    void Start()
    {
        spawnRenderer = spawnVisualisation.GetComponent<SpriteRenderer>();
        spawnFollowMouse = spawnVisualisation.GetComponent<FollowMouse>();
        spawnNoBuildCollision = spawnVisualisation.GetComponent<NoBuildCollision>();
        setMode(Mode.disabled);
    }

    // Update is called once per frame
    void Update()
    {
        if(mode != Mode.disabled)
        {
            if( shop.receiveCancelBuild() )
            {
                setMode(Mode.disabled);
                shop.resetBuild();
            }
        }

        if (mode == Mode.waitToUp)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                setMode(Mode.findPosition);
            }
        }
        else if(mode == Mode.findPosition)
        {
            if (Input.GetButton("Fire2"))
            {
                setMode(Mode.disabled);
                shop.resetBuild();
            }
            else
            {
                if(Input.GetButtonUp("Fire1"))
                {
                    setMode(Mode.findRotation);
                }
            }


        }
        else if(mode == Mode.findRotation)
        {
            if (Input.GetButton("Fire2"))
            {
                setMode(Mode.disabled);
                shop.resetBuild();
            }
            else if(Input.GetButtonUp("Fire1") )
            {
                if(spawnNoBuildCollision.isOnCollision() == false)
                {
                    GameObject obj = (GameObject)Instantiate(prefabToSpawn, spawnVisualisation.transform.position, spawnVisualisation.transform.rotation);
                    spawnNoBuildCollision.rengister(obj);
                    setMode(Mode.disabled);
                    shop.resetBuild();
                    moneyManager.pay(cost);
                }
                else
                {
                    setMode(Mode.disabled);
                    shop.resetBuild();
                }
            }

        }
    }

    public void onButtonPress()
    {
        if(mode == Mode.disabled)
        {
            if (moneyManager.hasEnoughMoney(cost))
            {
                if (shop.tryToBuild())
                    setMode(Mode.waitToUp);
                else
                    shop.sendCancelBuild();
            }
        }
        else
        {
            setMode(Mode.disabled);
            shop.resetBuild();
        }
    }
}