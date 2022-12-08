/**
 * @file    StartScreen.cs
 * @author  Jordan Reed - Taylor Martin
 *
 * @brief   Manages start screen buttons. Modified from Taylor's startmenu script
 *
 * @date    November 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;


public class StartScreen : MonoBehaviour
{

    [SerializeField] private GameObject startMenu;      // holds the reference to the canvas with the start menu
    [SerializeField] private GameObject settingsMenu;   // reference to the canvas with the settings menu
    [SerializeField] private Toggle mToggle;            // reference to the toggle button for bc mode

    // Runs once when started
    // makes sure the start menu is active and the settings menu is inactive
    public void Start()
    {
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }
    }

    //StartGame Function
    //--------------------------------
    //Starts the game by loading the scene in element 1
    //if start game button is pressed 
    public void StartGame()
    {
        SceneManager.LoadScene(1); 
        FindObjectOfType<AudioManager>().Play("start");
    }

    //QuitGame Function
    //--------------------------------
    //Quits the game
    //if start game button is pressed 
    public void QuitGame()
    {
        Application.Quit();
    }

    /*
     * @brief   Function to show the settings screen and hide the start menu.
     *
     *          Added by Jordan.
     */
    public void Settings()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    /*
     * @brief   Function to show the start menu and hide the settings screen.
     *
     *          Added by Jordan.
     */
    public void MainMenu()
    {
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    /*
     * @brief   Function to set the BC mode based on if the toggle switch in the settings is on or off
     *
     *          Added by Jordan
     */
    public void setBCMode()
    {
        Debug.Log("toggle value " + mToggle.isOn);
        WinLossMngr.bcMode = mToggle.isOn;
    }
}
