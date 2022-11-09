/**
 * @file    BaseItem.cs
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

public class BaseItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual string GetItemStats()
    {
        return "base item: 0";
    }

    protected virtual void ApplyUpgrade(Collision2D col)
    {
        // virtual
        // does different things based on the class
        Debug.Log("base item apply upgrade. does nothing!");
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("player collided with item");
            
            NotificationManager.Instance.showScreen(GetItemStats());
            ApplyUpgrade(col);
            Destroy(gameObject);
        }
        
    }
}
