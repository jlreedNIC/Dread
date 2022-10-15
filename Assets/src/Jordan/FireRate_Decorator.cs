/*
 *  Jordan Reed
 *  10/15/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
 */

public class FireRate_Decorator : Base_Decorator
{
    [SerializeField] private float rate_upgrade = -1;

    override public int GetWeaponDamage()
    {
        Debug.Log("recursive damage call/firerate decorator");
        return weapon_wrappee.GetWeaponDamage();
    }

    override public float GetWeaponFireRate()
    {
        Debug.Log("recursive fire rate call/firerate decorator");
        return rate_upgrade + weapon_wrappee.GetWeaponFireRate();
    }

    override public int GetWeaponFireRange()
    {
        Debug.Log("recursive fire range call/firerate decorator");
        return weapon_wrappee.GetWeaponFireRange();
    }

}