using UnityEngine;
using System.Collections;





public class Shop : MonoBehaviour {

    [System.Serializable]
    public class SpawnPointData
    {
        public Transform transform;
        public bool justSpawned = false;
    }

    public ShopCreateButton[] creationButtons;
    public SpawnPointData[] spawnPoints;
    GameObject upgradeButton;


    public GameObject[] menuObjects;
    bool open = false;
    public void setOpen(bool s)
    {
        open = s;
        foreach( GameObject it in menuObjects)
            it.SetActive(s);
    }
    public bool getOpen()
    {
        return open;
    }

    void Start()
    {
        upgradeButton = GameObject.FindGameObjectWithTag("GameController")
            .GetComponentInChildren<UpgradeManager>().upgradeButton;
        setOpen(open);
    }

    // for mantain all buttons together

    // to prevent from building two different buildings at the same time
    // using two buttons
    bool onBuild = false;
    public bool tryToBuild()
    {
        if (onBuild)
            return false;
        else
        {
            onBuild = true;
            return true;
        }
    }
    public void resetBuild()
    {
        onBuild = false;
    }

    //
    bool cancelBuild;
    public bool receiveCancelBuild()
    {
        if(cancelBuild)
        {
            cancelBuild = false;
            return true;
        }
        return false;
    }
    public void sendCancelBuild()
    {
        cancelBuild = true;
    }

    void Update()
    {

    }

    public void onBuildButtonPress()
    {
        setOpen(!getOpen());
        //if(open == false)
        upgradeButton.SetActive(false);
    }
	
}
