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

    override public string getWeaponName()
    {
        return "Fire Rate " + rate_upgrade;
    }

    override public float GetWeaponFireRate()
    {
        // Debug.Log("recursive fire rate call/firerate decorator");
        float total_rate = rate_upgrade + weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRate();
        if(total_rate <= 0)
            return 0;
        else return rate_upgrade + weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRate();
    }

}