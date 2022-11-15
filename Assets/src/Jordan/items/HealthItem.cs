/**
 * @file    HealthItem.cs
 * @author  Jordan Reed
 *
 * @brief   This class is the script to manage the health pick-up item. It adds to the player's current health, ie it 'heals' the player.
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

public class HealthItem : BaseItem
{
    [SerializeField] private int healthMod = 5; // amount to heal player by

    /*
     * @brief   This function returns the 'stats' of the item in a string form
     *          so it can be shown on the screen what the player just picked up.
     */
    override protected string GetItemStats()
    {
        return "Health pickup: " + healthMod;
    }

    /*
     * @brief   This function 'applies the upgrade'. 
     *          Overridden function that adds health to the players current health.
     */
    override protected void ApplyUpgrade()
    {
        Debug.Log("health pickup. added " + healthMod + " health to player");

        // find the player object and get the class reference
        Player_Movement playerRef = GameObject.FindWithTag("Player").GetComponent<Player_Movement>();
        // add health
        playerRef.damageable.GainHealth(healthMod);
    }

}
