/**
 * @file    PauseScreen.cs
 * @author  Jordan Reed - Taylor Martin
 *
 * @brief   Manages pause screen buttons. Modified from Taylor's pausemenu script
 *
 * @date    November 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public static bool gameIsPaused = false;        // is the game paused or not
    public GameObject pauseMenuUI;                  // holds the ui gameobject to modify
    public GameObject hud;                          // holds the hud gameobject to modify

    // make sure pause screen is inactive at start
    public void Start()
    {
        pauseMenuUI.SetActive(false); 
    }

    // Update is called once per frame
    public void Update()
    {
        // if game is paused, actually pause the game
        // if not, unpause the game
        if(Input.GetButtonDown("Cancel"))
        {
            if(gameIsPaused)
            {
                Resume(); 
            }
            else
            {
                Pause();
            }
        }
    }

    /*
     * @brief   Function will pause the time on the game and show the pause menu while not showing the HUD
     */
    public void Pause()
    {
        hud.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        gameIsPaused = true;
    }

    /*
     * @brief   Function will resume the time on the game and hide the pause menu and resume showing the HUD
     */
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1f; 
        gameIsPaused = false;
    }

    /*
     * @brief   Function will make sure time is resumed for the game, reset the ammo manager
     *          to have basic bullets again, and reset the winloss manager. Then load the main screen.
     *
     *          Only function modified by Jordan.
     */
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        WinLossMngr.resetShipParts();
        AmmoManager.Instance.resetAmmoMan();
        gameIsPaused = false;
        SceneManager.LoadScene(0); 
    }

    /*
     * @brief   Function will quit the entire game
     */
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
