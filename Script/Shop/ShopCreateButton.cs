using UnityEngine;
using System.Collections;


public class ShopCreateButton : MonoBehaviour
{

    // to check for payments
    public MoneyManager moneyManager;
    public float cost = 100;

    public GameObject prefabToSpawn;
    SpriteRenderer prefabRenderer;

    public GameObject acceptMenuObject;
    AcceptBuildManager acceptBuildManager;


    //public Sprite spriteVisualisation;
    public GameObject spawnVisualisation;
    SpriteRenderer spawnRenderer;
    FollowMouse spawnFollowMouse;
    NoBuildCollision spawnNoBuildCollision;


    enum Mode
    {
        disabled,
        waitToUp,
        findPosition,
        findRotation,
        waitForAccept,
    }
    Mode mode = Mode.disabled;
    void setMode(Mode newMode)
    {
        mode = newMode;
        if (newMode == Mode.disabled)
        {
            spawnVisualisation.SetActive(false);
            acceptMenuObject.SetActive(false);

        } else if(newMode == Mode.findPosition)
        {
            spawnVisualisation.SetActive(true);
            spawnVisualisation.transform.rotation = Quaternion.Euler(0, 0, 0);
            //spawnRenderer.sprite = spriteVisualisation;
            spawnRenderer.sprite = prefabRenderer.sprite;
            spawnVisualisation.transform.localScale = prefabToSpawn.transform.localScale;

            spawnFollowMouse.position = true;
            spawnFollowMouse.rotation = false;
            acceptMenuObject.SetActive(false);

        }
        else if( newMode == Mode.findRotation)
        {
            spawnVisualisation.SetActive(true);
            //spawnRenderer.sprite = spriteVisualisation;
            spawnRenderer.sprite = prefabRenderer.sprite;
            spawnVisualisation.transform.localScale = prefabToSpawn.transform.localScale;


            spawnFollowMouse.position = false;
            spawnFollowMouse.rotation = true;
            acceptMenuObject.SetActive(false);
        }
        else if (newMode == Mode.waitForAccept)
        {
            spawnVisualisation.SetActive(true);
            //spawnRenderer.sprite = spriteVisualisation;
            spawnRenderer.sprite = prefabRenderer.sprite;
            spawnVisualisation.transform.localScale = prefabToSpawn.transform.localScale;

            spawnFollowMouse.position = false;
            spawnFollowMouse.rotation = false;
            acceptMenuObject.SetActive(true);
            acceptBuildManager.resetState();
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

        acceptBuildManager = acceptMenuObject.GetComponent<AcceptBuildManager>();
        prefabRenderer = prefabToSpawn.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode != Mode.disabled)
        {
            if (shop.receiveCancelBuild())
            {
                setMode(Mode.disabled);
                shop.resetBuild();
                if (ProjectSettings.debugLogEnabled_building)
                    Debug.Log("receive cancel build");
            }
        }

        if (mode == Mode.waitToUp)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                setMode(Mode.findPosition);
            }
        }
        else if (mode == Mode.findPosition)
        {
            if (Input.GetButton("Fire2"))
            {
                setMode(Mode.disabled);
                shop.resetBuild();
                if (ProjectSettings.debugLogEnabled_building)
                    Debug.Log("find position cancel");
            }
            else
            {
                if (Input.GetButtonUp("Fire1"))
                {
                    setMode(Mode.findRotation);
                }
            }


        }
        else if (mode == Mode.findRotation)
        {
            if (Input.GetButton("Fire2"))
            {
                setMode(Mode.disabled);
                shop.resetBuild();

                if (ProjectSettings.debugLogEnabled_building)
                    Debug.Log("find rotation cancel");
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                if (spawnNoBuildCollision.isOnCollision() == false)
                {
                    setMode(Mode.waitForAccept);
                    
                    // no confirm version
                    //GameObject obj = (GameObject)Instantiate(prefabToSpawn, spawnVisualisation.transform.position, spawnVisualisation.transform.rotation);
                    //spawnNoBuildCollision.rengister(obj);
                    //setMode(Mode.disabled);
                    //shop.resetBuild();
                    //moneyManager.pay(cost);

                    //if (ProjectSettings.debugLogEnabled_building)
                        //Debug.Log("builded");
                }
                else
                {
                    setMode(Mode.disabled);
                    shop.resetBuild();
                    if (ProjectSettings.debugLogEnabled_building)
                        Debug.Log("onCollision with other");
                }
            }

        }
        else if (mode == Mode.waitForAccept)
        {
            if (Input.GetButton("Fire2") || acceptBuildManager.isDeclined())
            {
                setMode(Mode.disabled);
                shop.resetBuild();

                if (ProjectSettings.debugLogEnabled_building)
                    Debug.Log("waitForAccept cancel");
            }
            else if (acceptBuildManager.isAccepted())
            {
                GameObject obj = (GameObject)Instantiate(prefabToSpawn, spawnVisualisation.transform.position, spawnVisualisation.transform.rotation);
                spawnNoBuildCollision.rengister(obj);
                setMode(Mode.disabled);
                shop.resetBuild();
                moneyManager.pay(cost);

                if (ProjectSettings.debugLogEnabled_building)
                    Debug.Log("builded");
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
                {
                    shop.sendCancelBuild();
                    if (ProjectSettings.debugLogEnabled_building)
                        Debug.Log("onButtonPress fail to build");
                }
            }
        }
        else
        {
            setMode(Mode.disabled);
            shop.resetBuild();
            if (ProjectSettings.debugLogEnabled_building)
                Debug.Log("onButtonPress just pressed");
        }
    }
}