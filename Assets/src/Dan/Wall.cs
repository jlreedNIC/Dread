/*
 * This Script will allow the interior walls to become damagable by the player/enemies.
 * The need for this class to exist beyond the destructable mechanic is to provide
 * the player the means to escape should the interiors walls that are generated trap them. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite dmgSprite;
    public int hp = 4;

    private SpriteRenderer spriteRenderer;
    // used for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DamageWall(int loss)
    {
        spriteRenderer.sprite = dmgSprite;
        hp -= loss;
        // if the wall's hp is less than or equal to 0
        if (hp <= 0)
        {
            //disable the game object (wall)
            gameObject.SetActive(false);
        }
    }

}