/**
 * @file    HUD.cs
 * @author  Jordan Reed
 *
 * @brief   This class manages the HUD. It updates the values for health, ammo count, and part count that the player sees.
 *          It also has a small screen for BC Mode
 *
 * @date    October 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

/*
 * TO DO:
 *      Would it be helpful to have this as a singleton
 */

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject AmmoCount;      // holds the text mesh pro object for the ammo count
    [SerializeField] private GameObject PartCount;      // holds the text mesh pro object for the part count
    [SerializeField] private Image healthBar;           // holds the progress bar image for the health bar
    [SerializeField] private GameObject bcModeScreen;   // screen for bcmode

    private TMP_Text objectText;                        // Text object to update the text mesh pro objects on screen
    private int curVal, maxVal;                         // ints to hold the current and maximum values to update on screen text

    private float curHealth, maxHealth;                 // float values to hold the health values
    private float maxWidth, curWidth;                   // float values to hold the width of the health bar
    private RectTransform imageRect;                    // holds the width and height of the health image bar

    [SerializeField] private GameObject playerRef;      // reference to the player gameobject to get the current health


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start for HUD called");

        // set variables for health bar image and the maximum width of the health bar
        imageRect = healthBar.GetComponent<RectTransform>();
        maxWidth = imageRect.rect.width;

        // if the player reference is not set in the inspector, find the player gameobject
        if(playerRef == null)
        {
            playerRef = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    // Update will update the values for all screens in HUD
    void Update()
    {
        // get current ammo values and update the screen
        objectText = AmmoCount.GetComponent<TMP_Text>();
        curVal = AmmoManager.Instance.GetTotalAmmo();
        maxVal = AmmoManager.Instance.GetMaxAmmo();
        objectText.text = curVal + "/" + maxVal;

        // get current part counts and update the screen
        objectText = PartCount.GetComponent<TMP_Text>();
        curVal = WinLossMngr.getShipParts();
        maxVal = 7;
        objectText.text = curVal + "/" + maxVal;

        // if the player gameobject is active, ie if the player is not dead
        if(playerRef != null)
        {
            // get current health and update health bar
            curHealth = playerRef.GetComponent<Player_Movement>().damageable.currentHealth;
            maxHealth = playerRef.GetComponent<Player_Movement>().damageable.baseHealth;
            curWidth = (curHealth/maxHealth) * maxWidth;

            imageRect.sizeDelta = new Vector2( curWidth, imageRect.sizeDelta.y);
        }

        // if bc mode is enabled
        if(WinLossMngr.bcMode)
        {
            // make sure bc screen is active and update with current death count
            bcModeScreen.SetActive(true);

            objectText = bcModeScreen.transform.GetChild(0).GetComponent<TMP_Text>();
            curVal = WinLossMngr.getBCDeath();
            objectText.text = "bc death count: " + curVal;
        }
        else
        {
            bcModeScreen.SetActive(false);
        }
    }
}
