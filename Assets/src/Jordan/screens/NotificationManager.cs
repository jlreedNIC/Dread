/**
 * @file    NotificationManager.cs
 * @author  Jordan Reed
 *
 * @brief   This class will show the notification screens.
 *
 * @date    October 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
    TO DO:
        make sure this is not creating more than one instance
 */

/*
 * ScreenManager: Shows a notification. Creates a single notification screen and updates the text as called.
 *
 * member variables:
 */
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
        internal static readonly NotificationManager instance = new GameObject().AddComponent<NotificationManager>();
    }
    // // singleton implementation
    // private NotificationManager() {}
    
    // public static NotificationManager Instance { get; private set; }

    // private void Awake()
    // {
    //     if(Instance != null && Instance != this)
    //     {
    //         Debug.Log("tried creating new instance");
    //         Destroy(this);
    //     }
    //     else
    //     {
    //         Debug.Log("new instance");
    //         Instance = this;
    //         DontDestroyOnLoad(this.gameObject); // when do we actually need to use this?
    //     }
    // }

    [SerializeField] private GameObject notificationScreenPrefab;     // contains text mesh pro and image background
    private GameObject screenInstance;                          // an instance of the prefab
    private TMP_Text screenText;                                // tmp text object
    private Image background;                                   // background image object 
    [SerializeField] private bool isScreenActive;               // bool value to hold whether or not the screen is shown on screen
    [SerializeField] private float delay = 5;                       // amount of time to show notification
    int numScreensActive = 0;                                   // number of notifications called, used to ensure screen is shown for full delay time

    /*
     * @brief Create an instance of notification screen prefab on start. Set variables
     *        of text and background in script to modify as needed
     */
    void Start()
    {
        notificationScreenPrefab = Resources.Load<GameObject>("NotificationScreen");
        screenInstance = Instantiate(notificationScreenPrefab);
        screenText = screenInstance.transform.GetChild(0).GetComponent<TMP_Text>();
        background = screenInstance.transform.GetChild(1).GetComponent<Image>();
    }

    void Update()
    {
        // show item pop up or not
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

    // set text
    private void setScreenText(string sText)
    {
        screenText.text = sText;
    }

    // fix background image size to match text size
    private void setBackgroundSize()
    {
        // get sizes of background and text objects
        RectTransform backgroundSize = background.GetComponent<RectTransform>();
        RectTransform textSize = screenText.GetComponent<RectTransform>();

        // set size of background to slightly bigger than text size
        backgroundSize.sizeDelta = new Vector2((textSize.sizeDelta.x + 2)/.25f, (textSize.sizeDelta.y + 20)/.25f);
    }

    /*
     * @brief Populates the screen with the given text and makes sure the background fits the amount of text given.
     *        Then makes sure the screen is called and number of notifications has been updated
     *
     * @param string sText text to show on the notification screen
     */
    public void showScreen(string sText)
    {
        setScreenText(sText);
        setBackgroundSize();

        isScreenActive = true;
        numScreensActive++;
        StartCoroutine(screenDelay(delay));
    }

    /*
     * @brief Makes sure that the notification is shown for the full amount of time. It will not deactivate the screen
     *        until all notifications have run their time down.
     *
     * @param float rate amount of time to show the screen
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

