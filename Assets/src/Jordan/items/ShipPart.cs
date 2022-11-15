/**
 * @file    ShipPart.cs
 * @author  Jordan Reed
 *
 * @brief   This class increases the total amount of ship parts collected upon item collision.
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

public class ShipPart : BaseItem
{
    [SerializeField] private int part = 1;      // number of ship parts picked up

    /*
     * @brief   This function returns the 'stats' of the item in a string form
     *          so it can be shown on the screen what the player just picked up.
     */
    override protected string GetItemStats()
    {
        return part + " ship part received!";
    }

    /*
     * @brief   This function 'applies the upgrade'. 
     *          Overridden function that adds to total ship parts collected.
     */
    override protected void ApplyUpgrade()
    {
        Debug.Log("ship part picked up");

        // add ship part
        WinLossMngr.addShipPart();
    }

}
