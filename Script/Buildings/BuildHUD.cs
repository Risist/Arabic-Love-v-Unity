using UnityEngine;
using System.Collections;

public class BuildHUD : MonoBehaviour {

    public GameObject newHouse;
    public bool check = false;

	public void build()
    {
        if (check == false)
        {
            newHouse.SetActive(true);
            check = true;
        }
        else
        {
            newHouse.SetActive(false);
            check = false;
        }
        
    }
}
