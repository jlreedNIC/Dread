/**
 * @file    AmmoItem.cs
 * @author  Jordan Reed
 *
 * @brief   This is the script for the ammo pick-up item. Adds ammo to the player's current total.
 *
 * @date    November 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/*
 * TO DO:
 *      
 */

public class AmmoItem : BaseItem
{
    [SerializeField] private int ammo = 5;

    /*
     * @brief   This function returns the 'stats' of the item in a string form
     *          so it can be shown on the screen what the player just picked up.
     */
    override protected string GetItemStats()
    {
        return "Ammo pickup: " + ammo;
    }

    /*
     * @brief   This function 'applies the upgrade'. Overridden function that adds
     *          ammo to the players total ammo count.
     *
     * @param   Collision2D The object that the item has collided with (should be player). 
     *          This is not needed in this function, but another class that 
     *          inherits from the same base class.
     */
    override protected void ApplyUpgrade(Collision2D col)
    {
        // does different things based on the class
        Debug.Log("ammo pickup. added " + ammo + " ammo to player");
        AmmoManager.Instance.updateAmmoCount(ammo);
    }

}
