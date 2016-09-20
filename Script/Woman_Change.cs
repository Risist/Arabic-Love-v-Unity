using UnityEngine;
using System.Collections;

public class Woman_Change : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    public Sprite black;
    public Sprite blue;
    public bool change = false;

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
    
	void Update ()
    {
        if (change == false)
            spriteRenderer.sprite = blue;
        else
            spriteRenderer.sprite = black;
    }
}
