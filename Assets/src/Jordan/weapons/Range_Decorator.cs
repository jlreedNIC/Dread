/*
 *  Jordan Reed
 *  10/18/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
 */

public class Range_Decorator : Base_Decorator
{
    [SerializeField] private int range_upgrade = 1;

    override public int GetWeaponFireRange()
    {
        // Debug.Log("recursive fire range call/range decorator");
        return range_upgrade + weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRange();
    }
}