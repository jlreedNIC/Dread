/**
 * @file    NotificationManager.cs
 * @author  Jordan Reed
 *
 * @brief   This class will show the notification screens. It creates one screen instance and updates it as needed.
 *
 * @date    October 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public sealed class NotificationManager : MonoBehaviour
{
    // for this singleton implementation to work, need to call it before first item is picked up
    // singleton implementation
    private NotificationManager() {}
    public static NotificationManager Instance
    {
        get
        {
            return Nested.instance;
        }
    }

    private class Nested
    {
        static Nested() {}
        internal static readonly NotificationManager instance = new GameObject("NotificationManager").AddComponent<NotificationManager>();
    }

    private void Awake()
    {
        Debug.Log("notification awake called");
        // so we don't lose reference to the game object in the scene
        DontDestroyOnLoad(this.gameObject);
    }

    [SerializeField] private GameObject notificationScreenPrefab;       // prefab of the notification screen to create
    private GameObject screenInstance;                                  // an instance of the prefab
    private TMP_Text screenText;                                        // tmp text object of screen

    [SerializeField] private bool isScreenActive;                       // bool value to hold whether or not the screen is shown on screen
    [SerializeField] private float delay = 5;                           // amount of time to show notification

    private int numScreensActive = 0;                                           // number of notifications called, used to ensure screen is shown for full delay time

    /*
     * @brief   Create an instance of notification screen prefab on start, only when testing. Not used in main scene. 
     */
    void Start()
    {
        instantiateNotifications();
    }

    /*
     * @brief   Create an instance of the notification screen prefab and set the variable to edit the text.
     *          Make sure screen is not showing on start.
     */
    public void instantiateNotifications()
    {
        Debug.Log("notification instantiate called");

        // load prefab automatically
        notificationScreenPrefab = Resources.Load<GameObject>("NotificationScreen");

        // guard code to make sure not accessing null variables
        if(notificationScreenPrefab == null)
        {
            Debug.Log("prefab not loaded");
            return;
        }

        // don't create more than one instance of prefab, otherwise will have multiple screens showing up
        if(screenInstance == null) 
        {
            screenInstance = Instantiate(notificationScreenPrefab);
        }

        // guard code. don't access null variables
        if(screenInstance == null)
        {
            Debug.Log("prefab instance not loaded");
            return;
        }

        // set variable for text component
        screenText = screenInstance.transform.GetChild(0).GetComponent<TMP_Text>();

        // make sure screen is not active
        screenInstance.SetActive(false);
        isScreenActive = false;
    }

    // updates every frame
    // shows screen if screen instance is created and screen is supposed to be active
    void Update()
    {
        // show item pop up or not
        if(screenInstance != null)
        {
            if(isScreenActive)
            {
                screenInstance.SetActive(true);
                // Debug.Log("showing item screen");
            }
            else
            {
                screenInstance.SetActive(false);
                // Debug.Log("hiding item screen");
            }
        }
    }

    /*
     * @brief   Function will set the text portion of the notification screen.
     */
    private void setScreenText(string sText)
    {
        screenText.text = sText;
    }

    /*
     * @brief   Populates the screen with the given text.
     *          Then makes sure the screen is called and number of notifications has been updated.
     *          Starts the screen countdown to make sure screen is shows for a set number of seconds.
     *
     * @param   string sText text to show on the notification screen
     */
    public void showScreen(string sText)
    {
        setScreenText(sText);

        isScreenActive = true;
        numScreensActive++;
        StartCoroutine(screenDelay(delay));
    }

    /*
     * @brief   Makes sure that the notification is shown for the full amount of time. It will not deactivate the screen
     *          until all notifications have run their time down.
     *
     * @param   float rate amount of time to show the screen
     */
    private IEnumerator screenDelay(float rate)
    {
        // Debug.Log("starting cooldown");
        yield return new WaitForSeconds(rate);
        numScreensActive--;
        if(numScreensActive == 0) isScreenActive = false;
        // Debug.Log("ending cooldown");
        yield break;
    }

   
}

