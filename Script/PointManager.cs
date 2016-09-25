using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {

    //how many points did you have
    public int actualPoints = 0;
    public int maxPoints = 75;
    Text text;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    public void addPoints()
    {
        ++actualPoints;
    }

    public bool isWin()
    {
        return actualPoints > 75;
    }

    public void MaxPoints()
    {
        if (actualPoints > 75) actualPoints = maxPoints;
    }

    void Update()
    {
        ShowPoints();
    }

    public void ShowPoints()
    {
        text.text = "" + actualPoints;
    }
	
}
