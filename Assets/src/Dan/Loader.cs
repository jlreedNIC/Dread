/**********************************************************
 * Loader.cs                                              *
 *                                                        *
 * checks the singlton of GameManager and loads           *
 * invokes the GameManager if it hasn't already been      *
 * or if the previous version of the GameManager has been *
 * destroyed and the intance value has been reset to null *
 **********************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;

    void Awake()
    {
        // checks if the singleton in GameManager is set to null
        // if so it makes a call to the GameManager script for instantiation
        // of the level to be created.
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        // instantiate notification manager if it's not already to avoid errors
        NotificationManager.Instance.instantiateNotifications();
    }
}
