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

    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Toggle mToggle;

    public void Start()
    {
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);

        // mToggle.onValueChanged.AddListener(delegate { ToggleValueChanged(mToggle); } );
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
    }

    //QuitGame Function
    //--------------------------------
    //Quits the game
    //if start game button is pressed 
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void MainMenu()
    {
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    void ToggleValueChanged(Toggle change)
    {
        Debug.Log("value changed " + change.isOn);
        // setBCMode(change.isOn);
    }

    public void setBCMode()
    {
        Debug.Log("toggle value " + mToggle.isOn);
        WinLossMngr.bcMode = mToggle.isOn;
    }
}
