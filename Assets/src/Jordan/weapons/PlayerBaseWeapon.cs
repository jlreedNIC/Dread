/**
 * @file    PlayerBaseWeapon.cs
 * @author  Jordan Reed
 *
 * @brief   
 *
 * @date    October 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
 */

public class PlayerBaseWeapon : Base_Weapon
{
    override public void Fire()
    {
        // Debug.Log("base decorator fire");
        if(canFire)
        {
            // play pewpew sound
            // FindObjectOfType<AudioManager>().Play("Pew");
            // if(AudioMan)
            // {
            //     Debug.Log("Playing pewpew sound!");
            //     AudioMan.Play("Pew");
            // }
            // else
            // {
            //     Debug.Log("can't play pewpew");
            // }

            int curDmg = GetWeaponDamage();
            float curRate = GetWeaponFireRate();
            int curRange = GetWeaponFireRange();
            // Debug.Log("weapon damage: " + curDmg + " fire rate: " + curRate + " fire range: " + curRange);

            // bullet info will be set in ammo manager class
            GameObject bullet = AmmoManager.Instance.createBullet(curRange, curDmg, firePoint);
            if(bullet != null)
            {
                canFire = !canFire;

                // apply force to bullet to move
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 

                StartCoroutine(FireCooldown(curRate));
            }
        }
        else
        {
            Debug.Log("can't fire yet");
        }
    }

}

