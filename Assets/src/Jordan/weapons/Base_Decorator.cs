/**
 * @file    Base_Decorator.cs
 * @author  Jordan Reed
 *
 * @brief   This is the base decorator class for weapons. It inherits from Base_Weapon.
 *          It defines the basic recursive calls to implement all decorators.
 *          It will 'wrap' around another instance of a weapon. This means that any recursive calls will call the
 *          wrappee's functions, and it will continue in that fashion till the base weapon is reached.
 *
 *          In other words, it implements the decorator pattern.
 *
 * @date    October 15 2022
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
    public GameObject weapon_wrappee;               // instance of Base_Weapon to wrap around


    /*
     * @brief Sets the object to wrap around. Any recursive call references the wrappee.
     *
     * @param GameObject current This is a GameObject with the Base_Weapon script added as a component.
     */
    public void setWrappee(GameObject current)
    {
        // Debug.Log("applying wrappee");
        weapon_wrappee = current;
    }

    /*
     * @brief Returns the damage a weapon modifies the bullets by. 
     *        Recursively calls the GetWeaponDamage function that it overrides so as to recursively
     *        modify damage.
     *
     * @returns int weapon damage modifier
     */
    override public int GetWeaponDamage()
    {
        return weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponDamage();
    }

    /*
     * @brief Returns the fire rate a weapon has. 
     *        Recursively calls the GetWeaponFireRate function that it overrides so as to recursively
     *        modify the fire rate.
     *
     * @returns int fire rate
     */
    override public float GetWeaponFireRate()
    {
        return weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRate();
    }

    /*
     * @brief Returns the fire range a weapon has. 
     *        Recursively calls the GetWeaponFireRange function that it overrides so as to recursively
     *        modify the fire range.
     *
     * @returns int fire rate
     */
    override public int GetWeaponFireRange()
    {
        return weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRange();
    }
}