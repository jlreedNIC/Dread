/**
 * @file    WinLossMngr.cs
 * @author  Jordan Reed
 *
 * @brief   enable bc mode, track bc deaths, check for death/game over, check for win
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
    [SerializeField] GameObject deathScreen;        // holds prefab of death screen
    [SerializeField] GameObject winScreen;          // holds prefab of win screen
    [SerializeField] GameObject playerRef;          // reference to the player object in the scene
    
    static private int shipParts;                   // how many ship repair parts the player has
    static private int bcDeathCount = 0;            // how many times bc has died in bc mode

    static public bool bcMode = false;              // is bc mode enabled or not

    // Start is called before the first frame update
    void Start()
    {
        // make sure deathScreen is created and inactive
        deathScreen = GameObject.Instantiate(deathScreen);
        deathScreen.SetActive(false);

        // create win screen and deactivate
        winScreen = GameObject.Instantiate(winScreen);
        winScreen.SetActive(false);

        // find player object
        if(playerRef == null)
        {
            playerRef = GameObject.FindWithTag("Player");
        }
    }

    // needs to be called somewhere to be reset upon scene reload
    public void initWinLoss()
    {
        // make sure deathScreen is created and inactive
        deathScreen = GameObject.Instantiate(deathScreen);
        deathScreen.SetActive(false);

        // create win screen and deactivate
        winScreen = GameObject.Instantiate(winScreen);
        winScreen.SetActive(false);

        // find player object
        if(playerRef == null)
        {
            playerRef = GameObject.FindWithTag("Player");
        }

        // make sure ship parts is set to 0
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
     *          to restart the game or quit the game. Does not pause the game
     */
    public void triggerDeathScreen()
    {
        Debug.Log("death screen triggered");
        deathScreen.SetActive(true);
        resetShipParts();
    }

    /*
     * @brief   This function will show the win screen on top of the current game and give options
     *          to restart the game or quit the game. Does not pause the game
     */
    public void triggerWinScreen()
    {
        Debug.Log("win screen triggered");
        winScreen.SetActive(true);
        resetShipParts();
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

    /*
     * @brief   Sets BC mode to true or false depending on parameter.
     *
     * @param   bool enabled if True, bcMode enabled
     *                       if False, bcMode not enabled
     */
    public static void setBCMode(bool enabled)
    {
        Debug.Log("bc mode set to " + enabled);
        bcMode = enabled;
    }

    /*
     * @brief   Resets the BC death count to 0
     */
    public static void resetBCMode()
    {
        bcDeathCount = 0;
    }
    
    /*
     * @brief   Add a death to the BC death counter
     */
    public static void addBCDeath()
    {
        bcDeathCount++;
    }

    /*
     * @brief   Returnt the amount of deaths BC has had while playing
     */
    public static int getBCDeath()
    {
        return bcDeathCount;
    }
}
