/**
 * @file    FireRate_Decorator.cs
 * @author  Jordan Reed
 *
 * @brief   This is the fire rate decorator class for weapons. It inherits from Base_Decorator.
 *          It defines the recursive calls to implement the fire rate modifiers of weapons.
 *
 *          It helps to implement the decorator pattern.
 *
 * @date    October 15 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
 */

public class FireRate_Decorator : Base_Decorator
{
    [SerializeField] private float rate_upgrade = -.5f;          // weapon fire rate to decrease by

    /*
     * @brief Returns a description of the weapon to display to the screen.
     *
     * @param string Description of what the player just picked up
     */
    override public string getWeaponName()
    {
        return "Fire Rate " + rate_upgrade;
    }

    override public string getPewNoise()
    {
        return "rate";
    }

    /*
     * @brief Returns the fire rate a weapon has. 
     *        Adds to the fire rate and recursively calls the GetWeaponFireRate function 
     *        that it overrides so as to recursively modify the fire rate.
     *        Fire rate will not go below 0.
     *
     * @returns int fire rate
     */
    override public float GetWeaponFireRate()
    {
        // get total rate
        float total_rate = rate_upgrade + weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRate();

        // if total rate is negative, set to 0, then return it
        if(total_rate <= 0)
        {
            return 0;
        }
        else return total_rate;
    }

}