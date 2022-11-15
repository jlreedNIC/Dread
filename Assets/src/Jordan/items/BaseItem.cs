/**
 * @file    BaseItem.cs
 * @author  Jordan Reed
 *
 * @brief   Base Item class for other items to inherit from. Describes what to do upon collision
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

public class BaseItem : MonoBehaviour
{
    /*
     * @brief   This function returns the 'stats' of the item in a string form
     *          so it can be shown on the screen what the player just picked up.
     *          This is the virtual function, not intended to be called. 
     */
    protected virtual string GetItemStats()
    {
        return "base item: 0";
    }

    /*
     * @brief   This function 'applies the upgrade'. 
     *          This is the virtual function, not intended to be called.
     */
    protected virtual void ApplyUpgrade()
    {
        Debug.Log("base item apply upgrade. does nothing!");
    }

    /*
     * @brief   When the item is collided with by the player: 
     *              - it will send a message to the notification screen based on what the item is
     *              - then it will apply whatever upgrade it needs to
     *              - it will be destroyed.
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("player collided with item");
            
            NotificationManager.Instance.showScreen(GetItemStats());
            ApplyUpgrade();
            Destroy(gameObject);
        }
        
    }
}
