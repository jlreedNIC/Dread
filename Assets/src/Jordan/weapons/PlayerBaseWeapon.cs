/**
 * @file    PlayerBaseWeapon.cs
 * @author  Jordan Reed
 *
 * @brief   This is the class for the player's base weapon. It inherits from Base_Weapon.
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
    /*
     * @brief Handles the firing mechanism of the player weapon. Overrides the Base_Weapon Fire().
     *        If a weapon can be fired, get the damage, fire rate, and fire range of the current weapon.
     *        Create a new bullet with the range and damage using the ammo manager.
     *        Apply force to bullet and start the cool down for firing.
     */
    override public void Fire()
    {
        if(canFire)
        {
            // play pewpew sound

            int curDmg = GetWeaponDamage();
            float curRate = GetWeaponFireRate();
            int curRange = GetWeaponFireRange();

            // bullet created by ammo manager for player
            // if no ammo left, bullet is not created
            GameObject bullet = AmmoManager.Instance.createBullet(curRange, curDmg, firePoint);
            if(bullet != null)
            {
                canFire = !canFire;

                // apply force to bullet to move
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 

                StartCoroutine(FireCooldown(curRate));
            }
            // else show notification("no more ammo");
        }
        else
        {
            Debug.Log("can't fire yet");
            // show animation here?
        }
    }

}

