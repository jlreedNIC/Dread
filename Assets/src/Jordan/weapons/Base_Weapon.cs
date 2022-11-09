/**
 * @file    Base_Weapon.cs
 * @author  Jordan Reed
 *
 * @brief   This is the base parent class for all weapons. It defines functions for firing the weapon as well as switching between weapons.
 *
 * @date    September 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
        fix switch weapon action
        
        need to create an enemy base weapon class that won't be tied to the ammo manager

        add a way to view the stats of each weapon
 */

public class Base_Weapon : MonoBehaviour
{
    public Transform firePoint; // where bullets spawn from

    public float bulletForce = 20f;

    [SerializeField] protected string weapon_name;
    [SerializeField] private float fire_rate;
    [SerializeField] private int weapon_dmg_mod;
    [SerializeField] private int fire_range;    

    // made public for inheritance purposes
    public bool canFire;
    public bool canBePickedUp;
    // when canbepickedup is false, turn collider off

    virtual public int GetWeaponDamage()
    {
        return weapon_dmg_mod;
    }

    virtual public float GetWeaponFireRate()
    {
        return fire_rate;
    }

    virtual public int GetWeaponFireRange()
    {
        return fire_range;
    }

    virtual public string getWeaponName()
    {
        return weapon_name;
    }
    
    // Start is called before the first frame update
    public void Start()
    {

        // get firepoint if not set
        if(firePoint == null)
        {
            // get firepoint
            firePoint = this.gameObject.transform.GetChild(0);
        }

        canFire = true;
        // canBePickedUp = true;
        // weapon can be picked up only if it's not held by an enemy or the player
        if(this.transform.parent != null)
        {
            canBePickedUp = false;
        }
        else
        {
            canBePickedUp = true;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        // if weapon can be picked up, turn the collider on, otherwise keep it off
        if(canBePickedUp) 
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
        else 
        {
            this.GetComponent<Collider2D>().enabled = false;
        }
    }

    virtual public void Fire()
    {
        // Debug.Log("base decorator fire");
        if(canFire)
        {
            // play pewpew sound

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
            // else show notification("no more ammo");
        }
        else
        {
            Debug.Log("can't fire yet");
        }
    }

    // weapon can only be fired so often
    // this function operates as the cooldown and will not let weapon be fired until ready
    public IEnumerator FireCooldown(float rate)
    {
        yield return new WaitForSeconds(rate);
        canFire = true;
        yield break;
    }

    // switch which weapon the player is carrying
    // takes a GameObject parameter (must be of type base_class (which may be changed) )
    // returns the new weapon GameObject

    // need to work on canBePickedUp
    // if enemies are loaded with prefab, player will end up picking up the enemy weapon
    virtual public GameObject SwitchActiveWeapon(GameObject oldWeapon)
    {
        if(canBePickedUp)
        {
            canBePickedUp = false;

            Debug.Log("switching weapons");
            // give the new player the position, rotation, and parent of the old weapon
            transform.position = oldWeapon.transform.position;
            transform.rotation = oldWeapon.transform.rotation;
            transform.parent = oldWeapon.transform.parent;

            // remove the parent and rotation of the old weapon
            oldWeapon.transform.parent = null;
            oldWeapon.transform.rotation = new Quaternion(0,0,0,0);
            oldWeapon.GetComponent<Base_Weapon>().canBePickedUp = true; // set old weapon able to be picked up

            // return the new weapon to be set in the player script
            return this.gameObject;
        }
        else
        {
            Debug.Log("can't switch with this weapon right now");
            return oldWeapon;
        }        
    }
}
