/**
 * @file    ShipPart.cs
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

public class ShipPart : BaseItem
{
    [SerializeField] private int part = 1;

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
        return part + " ship part received!";
    }

    override protected void ApplyUpgrade(Collision2D col)
    {
        // virtual
        // does different things based on the class
        Debug.Log("ship part picked up");
        // figure out where to store ship part variable
    }

}
