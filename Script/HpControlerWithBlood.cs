using UnityEngine;
using System.Collections;

public class HpControlerWithBlood : HpControler {

    public GameObject bloodSign;

    public override void onDeathEvent(float damage, GameObject causer)
    {
        Instantiate(bloodSign, transform.position, transform.rotation);
    }
}
