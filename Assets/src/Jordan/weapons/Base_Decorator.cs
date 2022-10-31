/*
 *  Jordan Reed
 *  10/15/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
        look into implementing decorators as adding new component script vs a new gameobject
            it can still have the same sprite
 */

public class Base_Decorator : Base_Weapon
{
    public GameObject weapon_wrappee;

    public void setWrappee(GameObject current)
    {
        // Debug.Log("applying wrappee");
        weapon_wrappee = current;
    }

    override public int GetWeaponDamage()
    {
        // Debug.Log("recursive damage call/base decorator");
        return weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponDamage();
    }

    override public float GetWeaponFireRate()
    {
        // Debug.Log("recursive fire rate call/base decorator");
        return weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRate();
    }

    override public int GetWeaponFireRange()
    {
        // Debug.Log("recursive fire range call/base decorator");
        return weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRange();
    }
}