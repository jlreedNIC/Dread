/**
 * @file    exitTile.cs
 * @author  Jordan Reed
 *
 * @brief   This class handles the bullet upgrades. Generalized script to use for any bullet upgrade
 *
 * @date    November 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class exitTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * @brief When a collision is detected with the item, a notification screen is called and the 
     *        upgrade is applied. The item is then destroyed.
     *
     * @param Collision2D col The collider that has been detected and can now be acted on
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("player collided with exit tile");
            SceneManager.LoadScene(1); 
            // NotificationManager.Instance.instantiateNotifications();
            // Destroy(NotificationManager.Instance);
        }
        
    }
}
