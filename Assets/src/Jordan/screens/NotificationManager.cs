/**
 * @file    NotificationManager.cs
 * @author  Jordan Reed
 *
 * @brief   This class will manage all screens.
 *              - item screens
 *              - pause screens
 *              - not HUD
 *              - Death screens
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
 * ScreenManager:
 *
 * member variables:
 */
public sealed class NotificationManager : MonoBehaviour
{
    // singleton implementation
    private NotificationManager() {}
    
    public static NotificationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Debug.Log("tried creating new instance");
            Destroy(this);
        }
        else
        {
            Debug.Log("new instance");
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // when do we actually need to use this?
        }
    }

    [SerializeField] private GameObject notificationScreenPrefab;     // contains text mesh pro and image background
    private GameObject screenInstance;
    private TMP_Text screenText;                                // tmp text object
    private Image background;                                   // background image object 
    [SerializeField] private bool isScreenActive;
    [SerializeField] private float delay;

    /*
     * @brief 
     */
    void Start()
    {
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

    // show screen
    public void showScreen(string sText)
    {
        setScreenText(sText);
        setBackgroundSize();

        isScreenActive = true;
        StartCoroutine(screenDelay(delay));
    }

    // start cooldown
    public IEnumerator screenDelay(float rate)
    {
        // Debug.Log("starting cooldown");
        yield return new WaitForSeconds(rate);
        isScreenActive = false;
        // Debug.Log("ending cooldown");
        yield break;
    }

   
}

