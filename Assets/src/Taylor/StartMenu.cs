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
}
