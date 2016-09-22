using UnityEngine;
using System.Collections;

public class HpControler : MonoBehaviour {

    public float hp = 100;
    public float maxHp = 100;
    // all damage and healing is multiplayed by this value
    public float defence = 1;

    // if the object shoud be removed when is dead
    public bool destroyWhenDead = true;

    public bool isAlive()
    {
        return hp > 0;
    }

    // deal damage or heal the object
    // a positive value of damage is meaned to be healing
    // when from other hand a negative value means damage
    // change of health is multiplayed by defence
    // when defence is negative everything (healing and damaging) works opposite
    public void dealDamage(float damage, GameObject causer)
    {
        hp += damage * defence;
        if (hp > maxHp)
            hp = maxHp;
        else if( isAlive() == false)
        {
            if(destroyWhenDead)
                Destroy(gameObject);

            onDeathEvent(damage, causer);
        }
    }

    // called when the object is signed as dead
    protected virtual void onDeathEvent(float damage, GameObject causer)
    {
        // does nothing without override
    }

}
