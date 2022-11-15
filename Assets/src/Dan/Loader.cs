/************************************************************
 * Loader.cs                                                *
 *                                                          *
 * checks the singleton value of GameManager and            *
 * invokes the GameManager if it hasn't already been        *
 * instantiated. If a previous instance of the GameManager  * 
 * has been destroyed, the class instance value is reset to * 
 * null.                                                    *
 ************************************************************/


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

   public void initialize()
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
