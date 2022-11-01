/// <summary>
/// Taylor Martin
/// 513 Studios
/// Project D.R.E.A.D.
/// University of Idaho
/// Created: September 27 2022
/// FILE: StartMenu.cs
/// Start Menu Class
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{

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
        SceneManager.LoadScene(4); 
    }

    //QuitGame Function
    //--------------------------------
    //Quits the game
    //if start game button is pressed 
    public void QuitGame()
    {
        Application.Quit();
    }
}
