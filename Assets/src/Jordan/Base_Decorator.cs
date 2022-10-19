/*
 *  Jordan Reed
 *  10/15/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
 */

public class Base_Decorator : Base_Weapon
{
    public GameObject weapon_wrappee;

    public void setWrappee(GameObject current)
    {
        Debug.Log("applying wrappee...");
        weapon_wrappee = current;
    }

    override public int GetWeaponDamage()
    {
        // Debug.Log("recursive damage call/base decorator");
        return weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponDamage();
    }

    override public float GetWeaponFireRate()
    {
        // Debug.Log("recursive fire rate call/base decorator");
        return weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRate();
    }

    override public int GetWeaponFireRange()
    {
        // Debug.Log("recursive fire range call/base decorator");
        return weapon_wrappee.GetComponent<Base_Weapon>().GetWeaponFireRange();
    }

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
        
            /* 
                get weapon damage (recursive)
                get fire rate (recursive)
                get weapon range (recursive)

                ammo manager . fire bullet (range, damage)
                    spawn bullet
                    apply damage
                    apply range
                    apply force
                
                firecooldown(rate??)
            */
            canFire = !canFire;

            int curDmg = GetWeaponDamage();
            float curRate = GetWeaponFireRate();
            int curRange = GetWeaponFireRange();
            // Debug.Log("weapon damage: " + curDmg + " fire rate: " + curRate + " fire range: " + curRange);

            // bullet info will be set in ammo manager class
            // spawn bullet
            GameObject bullet = Instantiate(bullet_type, firePoint.position, firePoint.rotation);

            // set max bullet dist and bullet damage
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
}