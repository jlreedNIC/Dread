/**
 * @file    EnemyBaseWeapon.cs
 * @author  Jordan Reed
 *
 * @brief   This class manages the enemy weapons. It inherits from Base_Weapon and overrides
 *          the Fire and SwitchWeapon functions. Enemy weapons do not interact with the ammo manager
 *          and are not currently able to switch their active weapon.
 *
 * @date    October 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
        look at implementing enemy weapon decorators

        look at implementing weapon switching
 */

public class EnemyBaseWeapon : Base_Weapon
{
    [SerializeField] private GameObject bullet_type;    // can set what bullet an enemy has

    /*
     * @brief Handles the firing mechanism of the enemy weapon. Overrides the Fire in Base_Weapon.
     *        If a weapon can be fired, get the damage, fire rate, and fire range of the current weapon.
     *        Create a new bullet with the range and damage. Enemies have infinite ammo so no interaction with ammo manager.
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

            canFire = !canFire;

            // create a bullet
            // enemy doesn't have to worry about ammo management
            // they have infinite bullets
            GameObject bullet = Instantiate(bullet_type, firePoint.position, firePoint.rotation);

            // // set max bullet dist and bullet damage
            bullet.GetComponent<Bullet>().setFireRange(curRange);
            bullet.GetComponent<Bullet>().setTotalDamage(curDmg);

            // apply force to bullet to move
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 

            StartCoroutine(FireCooldown(curRate));
        }
        else
        {
            Debug.Log("can't fire yet");
        }
    }

    // code needed in enemy script for enemy to be able to switch weapons
    // not implemented yet
    override public GameObject SwitchActiveWeapon(GameObject oldWeapon)
    {
        Debug.Log("Enemy cannot currently switch weapons.");
        return oldWeapon;       
    }
}

