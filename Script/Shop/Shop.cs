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
        setOpen(open);
    }

    // for mantain all buttons together

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
    }
	
}
