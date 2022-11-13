/**
 * @file    WinLossMngr.cs
 * @author  Jordan Reed
 *
 * @brief   enable bc mode, check for death/game over, check for win
 *
 * @date    November 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

/*
 * TO DO:
 *      
 */

public class WinLossMngr : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;        // holds prefab
    [SerializeField] GameObject winScreen;          // holds prefab
    [SerializeField] GameObject playerRef;          // reference to the player object in the scene
    
    static private int shipParts;                   // how many ship repair parts the player has
    static private int bcDeathCount = 0;            // how many times bc has died in bc mode

    static public bool bcMode = false;

    // Start is called before the first frame update
    void Start()
    {
        // make sure deathScreen is created and inactive
        deathScreen = GameObject.Instantiate(deathScreen);
        deathScreen.SetActive(false);

        // find player object
        if(playerRef == null)
        {
            playerRef = GameObject.FindWithTag("Player");
        }

        // create win screen and deactivate
        winScreen = GameObject.Instantiate(winScreen);
        winScreen.SetActive(false);
    }

    // needs to be called somewhere to be reset
    // maybe in pause menu? when loading start scene?
    public void initWinLoss()
    {
        // make sure deathScreen is created and inactive
        deathScreen = GameObject.Instantiate(deathScreen);
        deathScreen.SetActive(false);

        // find player object
        if(playerRef == null)
        {
            playerRef = GameObject.FindWithTag("Player");
        }

        // create win screen and deactivate
        winScreen = GameObject.Instantiate(winScreen);
        winScreen.SetActive(false);

        resetShipParts();
    }

    // Update is called once per frame
    void Update()
    {
        // check to see if the player has died, and show the death screen if they have
        if(playerRef == null)
        {
            triggerDeathScreen();
        }

        if(shipParts >= 7)
        {
            triggerWinScreen();
        }
    }

    /*
     * @brief   This function will show the death screen on top of the current game and give options
     *          to restart the game or quit the game.
     */
    public void triggerDeathScreen()
    {
        Debug.Log("death screen triggered");
        deathScreen.SetActive(true);
        resetShipParts();
        // Time.timeScale = 0f; 
    }

    /*
     * @brief   This function will show the win screen on top of the current game and give options
     *          to restart the game or quit the game.
     */
    public void triggerWinScreen()
    {
        Debug.Log("win screen triggered");
        winScreen.SetActive(true);
        resetShipParts();
        // Time.timeScale = 0f; 
    }

    /*
     * @brief   This function will reset the ship parts back to 0.
     */
    public static void resetShipParts()
    {
        shipParts = 0;
    }

    /*
     * @brief   This function will return the number of ship parts
     *
     * @return  int current number of ship parts
     */
    public static int getShipParts()
    {
        return shipParts;
    }

    /*
     * @brief   This function will add 1 to the number of ship parts held by the player
     */
    public static void addShipPart()
    {
        shipParts++;
    }

    public static void setBCMode(bool enabled)
    {
        Debug.Log("bc mode set to " + enabled);
        bcMode = enabled;
    }

    public static void resetBCMode()
    {
        bcDeathCount = 0;
    }
    
    public static void addBCDeath()
    {
        bcDeathCount++;
    }

    public static int getBCDeath()
    {
        return bcDeathCount;
    }
}
