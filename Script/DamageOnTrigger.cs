using UnityEngine;
using System.Collections;

public class DamageOnTrigger : MonoBehaviour {

    public float damageToDealEnter = 0;
    public float damageToDealStay = 0;
    public float damageToDealExit = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        HpControler hpControler = other.gameObject.GetComponent<HpControler>();
        if(other.isTrigger == false && hpControler != null && damageToDealEnter != 0 )
        {
            hpControler.dealDamage(damageToDealEnter, gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        HpControler hpControler = other.gameObject.GetComponent<HpControler>();
        if (other.isTrigger == false && hpControler != null && damageToDealStay != 0)
        {
            hpControler.dealDamage(damageToDealStay, gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        HpControler hpControler = other.gameObject.GetComponent<HpControler>();
        if (other.isTrigger == false && hpControler != null && damageToDealExit != 0)
        {
            hpControler.dealDamage(damageToDealExit, gameObject);
        }
    }
}
