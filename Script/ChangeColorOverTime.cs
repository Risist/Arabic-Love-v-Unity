using UnityEngine;
using System.Collections;

public class ChangeColorOverTime : MonoBehaviour {

    public Color colorChangePerFrame;
    public bool addiction = true;
    public Timer tTick;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        tTick.update();

        if (tTick.isReadyRestart())
        {
            if (addiction)
            {
                spriteRenderer.color += colorChangePerFrame;
            }
            else
            {
                spriteRenderer.color -= colorChangePerFrame;
            }
            /*Color c = spriteRenderer.color;
            c.a = c.a - colorChangePerFrame.a;
            spriteRenderer.color = c;*/
        }
	}
}
