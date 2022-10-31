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

public class Damage_Decorator : Base_Decorator
{
    [SerializeField] private int dmg_upgrade = 1;

    override public int GetWeaponDamage()
    {
        // Debug.Log("recursive weapon damage call/damage decorator");
        return dmg_upgrade + weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponDamage();
    }
}