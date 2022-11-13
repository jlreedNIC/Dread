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
    // [SerializeField] GameObject hud;             // to deactivate hud upon death
    [SerializeField] GameObject playerRef;
    
    // private bool isDead = true;                    // keeps track of if the death screen is active and player is dead


    // Start is called before the first frame update
    void Start()
    {
        // make sure deathScreen is inactive
        deathScreen = GameObject.Instantiate(deathScreen);
        deathScreen.SetActive(false);

        // find player object
        if(playerRef == null)
        {
            playerRef = GameObject.FindWithTag("Player");
        }

        winScreen = GameObject.Instantiate(winScreen);
        winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // get player health
        if(playerRef == null)
        {
            triggerDeathScreen();
        }
    }

    public void triggerDeathScreen()
    {
        Debug.Log("death screen triggered");
        deathScreen.SetActive(true);
        // Time.timeScale = 0f; 
    }

    public void triggerWinScreen()
    {
        Debug.Log("win screen triggered");
        winScreen.SetActive(true);
        // Time.timeScale = 0f; 
    }
}
