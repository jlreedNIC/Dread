/**
 * @file    HealthItem.cs
 * @author  Jordan Reed
 *
 * @brief   
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

public class HealthItem : BaseItem
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
        return "Health pickup: " + healthMod;
    }

    override protected void ApplyUpgrade()
    {
        // virtual
        // does different things based on the class
        Debug.Log("health pickup. added " + healthMod + " health to player");
        // call player.addHealth(healthMod);
        // to be added after player health added
    }

}
