/**
 * @file    EnemyBaseWeapon.cs
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
        look at implementing enemy weapon decorators
 */

public class EnemyBaseWeapon : Base_Weapon
{
    [SerializeField] private GameObject bullet_type;    // can set what bullet an enemy has

    // fires a bullet from enemy gun
    override public void Fire()
    {
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

            canFire = !canFire;

            // spawn bullet
            GameObject bullet = Instantiate(bullet_type, firePoint.position, firePoint.rotation);

            // // set max bullet dist and bullet damage
            bullet.GetComponent<bullet>().setFireRange(curRange);
            bullet.GetComponent<bullet>().setTotalDamage(curDmg);

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

    override public GameObject SwitchActiveWeapon(GameObject oldWeapon)
    {
        Debug.Log("Enemy cannot currently switch weapons.");
        return oldWeapon;       
    }
}

