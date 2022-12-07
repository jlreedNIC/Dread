/**
 * @file    Damage_Decorator.cs
 * @author  Jordan Reed
 *
 * @brief   This is the damage decorator class for weapons. It inherits from Base_Decorator.
 *          It defines the recursive calls to implement the damage modifiers of weapons.
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

public class Damage_Decorator : Base_Decorator
{
    [SerializeField] private int dmg_upgrade = 1;       // weapon damage to increase by
    
    /*
     * @brief Returns a description of the weapon to display to the screen.
     *
     * @param string Description of what the player just picked up
     */
    override public string getWeaponName()
    {
        return "Weapon damage +" + dmg_upgrade;
    }

    /*
     * @brief Returns the name of the sound the weapon should implement. Damage sound.
     *
     * @returns string weapon sound
     */
    override public string getPewNoise()
    {
        return "damage";
    }

    /*
     * @brief Returns the damage a weapon modifies the bullets by. 
     *        Adds damage then recursively calls the GetWeaponDamage function that it 
     *        overrides so as to recursively modify damage.
     *
     * @returns int weapon damage modifier
     */
    override public int GetWeaponDamage()
    {
        return dmg_upgrade + weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponDamage();
    }
}