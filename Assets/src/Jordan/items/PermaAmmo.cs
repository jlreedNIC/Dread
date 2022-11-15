/**
 * @file    PermaAmmo.cs
 * @author  Jordan Reed
 *
 * @brief   This item class permanently increases the player's total ammo count
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

public class PermaAmmo : BaseItem
{
    [SerializeField] private int ammo = 5;  // ammount to increase the permanent ammo total by

    /*
     * @brief   This function returns the 'stats' of the item in a string form
     *          so it can be shown on the screen what the player just picked up.
     */
    override protected string GetItemStats()
    {
        return "Maximum ammo increased by " + ammo;
    }

    /*
     * @brief   This function 'applies the upgrade'. 
     *          Overridden function that adds to the max ammo total as well as increasing the current total by the same amount.
     */
    override protected void ApplyUpgrade()
    {
        Debug.Log("ammo pickup. added " + ammo + " max ammo to player");
        // increase max total and pick up same amount of ammo
        AmmoManager.Instance.updateMaxTotal(ammo);
        AmmoManager.Instance.updateAmmoCount(ammo);
    }

}
