/**
 * @file    Range_Decorator.cs
 * @author  Jordan Reed
 *
 * @brief   This is the fire range decorator class for weapons. It inherits from Base_Decorator.
 *          It defines the recursive calls to implement the fire range modifiers of weapons.
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

public class Range_Decorator : Base_Decorator
{
    [SerializeField] private int range_upgrade = 1;         // weapon fire range to increase by

    /*
     * @brief Returns a description of the weapon to display to the screen.
     *
     * @param string Description of what the player just picked up
     */
    override public string getWeaponName()
    {
        return "Fire Range +" + range_upgrade;
    }

    /*
     * @brief Returns the name of the sound the weapon should implement. Range sound
     *
     * @returns string weapon sound
     */
    override public string getPewNoise()
    {
        return "range";
    }

    /*
     * @brief Returns the fire range a weapon has. 
     *        Adds the fire range and recursively calls the GetWeaponFireRange function 
     *        that it overrides so as to recursively modify the fire range.
     *
     * @returns int fire rate
     */
    override public int GetWeaponFireRange()
    {
        return range_upgrade + weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRange();
    }
}