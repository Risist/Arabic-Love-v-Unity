using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {

    
    public Sprite[] sprites;
    public float[] chances;

    // Use this for initialization
    void Start ()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float sum = 0;
        foreach (float it in chances)
            sum += it;

        float randed = Random.Range(0,sum);

        float lastSum = 0;
        for (int i = 0; i < sprites.Length; ++i)
            if (randed > lastSum && randed < lastSum + chances[i] )
            {
                spriteRenderer.sprite = sprites[i];
                return;
            }
            else
            {
                lastSum += chances[i];
            }
	}
}
