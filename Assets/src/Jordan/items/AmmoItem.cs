/**
 * @file    AmmoItem.cs
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

public class AmmoItem : BaseItem
{
    [SerializeField] private int ammo = 5;

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
        return "Ammo pickup: " + ammo;
    }

    override protected void ApplyUpgrade(Collision2D col)
    {
        // virtual
        // does different things based on the class
        Debug.Log("ammo pickup. added " + ammo + " ammo to player");
        AmmoManager.Instance.updateAmmoCount(ammo);
    }

}
