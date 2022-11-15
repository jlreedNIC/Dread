/**
 * @file    exitTile.cs
 * @author  Jordan Reed
 *
 * @brief   This class handles the scene transitioning. What happens when the player reaches the exit tile in the level
 *
 * @date    November 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class exitTile : MonoBehaviour
{
    /*
     * @brief   When the player runs into the exit tile, reload the current scene so the player can keep playing the game
     *
     *          Will need to handle reseting some variables
     *
     * @param   Collision2D col The collider that has been detected and can now be acted on
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("player collided with exit tile");
            SceneManager.LoadScene(1); 
        }
        
    }
}
