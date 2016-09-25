using UnityEngine;
using System.Collections;

public class Upgrade : Building {


    public override void UpgradeBuilding(int level, float minCd, float maxCd, Sprite sprite, SpriteRenderer spriterenderer)
    {
        if (level == 1)
        {
            spriterenderer.sprite = sprite;
            minCd = 6;
            maxCd = 5;
        }
        if (level == 2)
        {
            spriterenderer.sprite = sprite;
            minCd = 5;
            maxCd = 4;

        }
    }
}
