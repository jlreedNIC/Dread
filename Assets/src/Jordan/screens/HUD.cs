/**
 * @file    HUD.cs
 * @author  Jordan Reed
 *
 * @brief   This class manages the HUD. It updates the values for health, ammo count, and part count that the player sees.
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
 *      look into turning this class into singleton
 *      where do we store the parts count? here or in the player stat class?
 */

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject AmmoCount;      // holds the text mesh pro object for the ammo count
    [SerializeField] private GameObject PartCount;      // holds the text mesh pro object for the part count
    [SerializeField] private Image healthBar;           // holds the progress bar image for the health bar

    private TMP_Text objectText;                        // Text object to update the text mesh pro objects on screen
    private int curVal, maxVal;                         // ints to hold the current and maximum values to update on screen text

    private float curHealth, maxHealth;                 // float values to hold the health values
    private float maxWidth, curWidth;                   // float values to hold the width of the health bar
    private RectTransform imageRect;                    // holds the width and height of the health image bar

    [SerializeField] private GameObject playerRef;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start for HUD called");
        imageRect = healthBar.GetComponent<RectTransform>();
        maxWidth = imageRect.rect.width;
        if(playerRef == null)
        {
            playerRef = GameObject.FindWithTag("Player");
            // playerRef = GameObject.Find("Test_Player");  // may be needed if player is going to be instantiated in script
        }
    }

    // Update is called once per frame
    void Update()
    {
        // set current ammo values
        objectText = AmmoCount.GetComponent<TMP_Text>();
        curVal = AmmoManager.Instance.GetTotalAmmo();
        maxVal = AmmoManager.Instance.GetMaxAmmo();
        objectText.text = curVal + "/" + maxVal;

        // set current part counts
        objectText = PartCount.GetComponent<TMP_Text>();
        curVal = 4;
        maxVal = 7;
        objectText.text = curVal + "/" + maxVal;

        // get current health and update health bar
        curHealth = playerRef.GetComponent<Player_Movement>().damageable.currentHealth;
        maxHealth = playerRef.GetComponent<Player_Movement>().damageable.baseHealth;
        curWidth = (curHealth/maxHealth) * maxWidth;

        // Debug.Log(curHealth + "/" + maxHealth + "*" + maxWidth + "=" + curWidth);
        imageRect.sizeDelta = new Vector2( curWidth, imageRect.sizeDelta.y);

        // Debug.Log("health: " + curHealth + "/" + maxHealth);
        // Debug.Log("rect width: " + curWidth + "/" + maxWidth);
    }
}
