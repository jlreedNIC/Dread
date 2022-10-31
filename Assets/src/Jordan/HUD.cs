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
    [SerializeField] private GameObject AmmoCount;
    [SerializeField] private GameObject PartCount;
    [SerializeField] private Image healthBar;
    private TMP_Text AmmoText;
    private TMP_Text PartText;
    private int curAmmo, maxAmmo;
    private int curParts, maxParts;
    private float curHealth, maxHealth;
    private float maxWidth, curWidth;
    private RectTransform imageRect;

    // Start is called before the first frame update
    void Start()
    {
        AmmoText = AmmoCount.GetComponent<TMP_Text>();
        PartText = PartCount.GetComponent<TMP_Text>();
        imageRect = healthBar.GetComponent<RectTransform>();
        maxWidth = imageRect.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        // get current ammo counts and update text field
        curAmmo = AmmoManager.Instance.GetTotalAmmo();
        maxAmmo = AmmoManager.Instance.GetMaxAmmo();

        AmmoText.text = curAmmo + "/" + maxAmmo;

        // get current values of part counts and update text
        // curParts = getPartCount();
        curParts = 4;
        maxParts = 7;
        PartText.text = curParts + "/" + maxParts;

        // get current health and update health bar
        // curHealth = getPlayerHealth();
        curHealth = 1;
        maxHealth = 1;
        // maxHealth = getPlayerMaxHealth();
        curWidth = (curHealth/maxHealth) * maxWidth;
        imageRect.sizeDelta = new Vector2( curWidth, imageRect.sizeDelta.y);

        // Debug.Log("health: " + curHealth + "/" + maxHealth);
        // Debug.Log("rect width: " + curWidth + "/" + maxWidth);
    }
}
