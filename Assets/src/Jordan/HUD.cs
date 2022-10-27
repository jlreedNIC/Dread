using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject AmmoCount;  
    [SerializeField] private Image healthBar;
    private TMP_Text AmmoText;  
    private int curAmmo, maxAmmo;
    private float curHealth, maxHealth;
    private float maxWidth, curWidth;
    private RectTransform imageRect;

    // Start is called before the first frame update
    void Start()
    {
        AmmoText = AmmoCount.GetComponent<TMP_Text>();
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
