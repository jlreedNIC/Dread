/// <summary>
/// Taylor Martin
/// 513 Studios
/// Project D.R.E.A.D.
/// University of Idaho
/// Created: September 27 2022
/// FILE: PauseMenu.cs
/// pause menu class
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    
    //this will be implemented after HUD is created
    public GameObject hud;

    public void awake()
    {
        pauseMenuUI.SetActive(false); 
    }

    // Update is called once per frame
    public void Update()
    {
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

    public void Pause()
    {
        hud.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1f; 
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(0); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
