using UnityEngine;
using System.Collections;

public class UpgradeManager : MonoBehaviour {

    bool pressed;

    public bool isPressed()
    {
        return pressed;
    }

    void LateUpdate()
    {
        pressed = false;
    }

    public GameObject upgradeButton;


    public void onButton()
    {
        pressed = true;
    }
}
