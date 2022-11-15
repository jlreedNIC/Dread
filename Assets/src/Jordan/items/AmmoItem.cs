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
     */
    override protected void ApplyUpgrade()
    {
        Debug.Log("ammo pickup. added " + ammo + " ammo to player");
        AmmoManager.Instance.updateAmmoCount(ammo);
    }

}
