/**
 * @file    PermaHealth.cs
 * @author  Jordan Reed
 *
 * @brief   This item class permanently increases the player's total health
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

public class PermaHealth : BaseItem
{
    [SerializeField] private int healthMod = 5;     // ammount to permanently increase the player's health

    /*
     * @brief   This function returns the 'stats' of the item in a string form
     *          so it can be shown on the screen what the player just picked up.
     */
    override protected string GetItemStats()
    {
        return "Maximum health increased by " + healthMod;
    }

    /*
     * @brief   This function 'applies the upgrade'. 
     *          Overridden function that adds to the player's maximum health as well as the current amount of health.
     */
    override protected void ApplyUpgrade()
    {
        Debug.Log("health pickup. added " + healthMod + " max health to player");

        // find the player object and get the class reference
        Player_Movement playerRef = GameObject.FindWithTag("Player").GetComponent<Player_Movement>();
        // add maximum health
        playerRef.damageable.baseHealth += healthMod;
        playerRef.damageable.GainHealth(healthMod);
    }

}
