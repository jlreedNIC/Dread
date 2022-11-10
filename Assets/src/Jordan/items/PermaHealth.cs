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
// using TMPro;

/*
 * TO DO:
 *      
 */

public class PermaHealth : BaseItem
{
    [SerializeField] private int healthMod = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected string GetItemStats()
    {
        return "Maximum health increased by " + healthMod;
    }

    override protected void ApplyUpgrade(Collision2D col)
    {
        // virtual
        // does different things based on the class
        Debug.Log("health pickup. added " + healthMod + " max health to player");
        col.gameObject.GetComponent<Player_Movement>().damageable.baseHealth += healthMod;
        col.gameObject.GetComponent<Player_Movement>().damageable.GainHealth(healthMod);
    }

}
