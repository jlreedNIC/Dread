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
        X fix switch weapon action
        
        need to create an enemy base weapon class that won't be tied to the ammo manager

        add a way to view the stats of each weapon

        IEnumerator ??
 */

public class Base_Weapon : MonoBehaviour
{
    protected Transform firePoint;                         // where bullets spawn from

    protected float bulletForce = 20f;                    // what force to apply to bullets after being created

    [SerializeField] protected string weapon_name;      // weapon name to print to screen
    [SerializeField] private float fire_rate;           // how fast a weapon can fire it's bullets
    [SerializeField] private int weapon_dmg_mod;        // damage a weapon can multiply to the bullets
    [SerializeField] private int fire_range;            // how far a weapon can shoot

    protected bool canFire;                             // whether or not a weapon is able to be fired
                                                        // really only used to implement a delay in firing
                                                        // i.e. weapon can be fired every 3 seconds
    
    protected bool canBePickedUp;                       // whether or not a weapon can be picked up
                                                        // this allows for the player to switch between weapons
                                                        // manages the weapon collider so the weapon won't collide when the player is holding it
    
    /*
     * @brief Returns the damage a weapon modifies the bullets by. 
     *        Virtual so the decorator classes can implement recursive calls for the upgrades.
     *
     * @returns int weapon damage modifier
     */
    virtual public int GetWeaponDamage()
    {
        return weapon_dmg_mod;
    }

    /*
     * @brief Returns the fire rate a weapon has. 
     *        Virtual so the decorator classes can implement recursive calls for the upgrades.
     *
     * @returns int weapon fire rate
     */
    virtual public float GetWeaponFireRate()
    {
        return fire_rate;
    }

    /*
     * @brief Returns the fire range a weapon has. 
     *        Virtual so the decorator classes can implement recursive calls for the upgrades.
     *
     * @returns int weapon fire range
     */
    virtual public int GetWeaponFireRange()
    {
        return fire_range;
    }

    /*
     * @brief Returns the name a weapon has. 
     *        Virtual so the decorator classes can implement their own name.
     *
     * @returns int weapon fire rate
     */
    virtual public string getWeaponName()
    {
        return weapon_name;
    }
    
    virtual public string getPewNoise()
    {
        return "standard_pew";
    }

    // Start is called before the first frame update
    // initialize variables at the start
    public void Start()
    {

        // get firepoint if not set
        if(firePoint == null)
        {
            // get firepoint
            firePoint = this.gameObject.transform.GetChild(0);
        }

        // weapon starts out being able to be fired no matter what
        canFire = true;

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

    /*
     * @brief Handles the firing mechanism of a weapon. Virtual so the player and enemy classes can override it.
     *        If a weapon can be fired, get the damage, fire rate, and fire range of the current weapon.
     *        Create a new bullet with the range and damage. Apply force to bullet and start the cool down for firing.
     */
    virtual public void Fire()
    {
        if(canFire)
        {
            // play pewpew sound when audio manager implemented

            int curDmg = GetWeaponDamage();
            float curRate = GetWeaponFireRate();
            int curRange = GetWeaponFireRange();

            // bullet created by ammo manager for player
            // if no ammo left, bullet is not created
            GameObject bullet = AmmoManager.Instance.createBullet(curRange, curDmg, firePoint, getPewNoise());
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

    /*
     * @brief Function runs (designed to run as coroutine) for the designated amount of time then lets the weapon fire again.
     *
     * @param float rate Amount of time to wait until letting the weapon fire again
     *
     * @returns IEnumerator
     */
    public IEnumerator FireCooldown(float rate)
    {
        yield return new WaitForSeconds(rate);
        canFire = true;
        yield break;
    }

    /*
     * @brief This function will allow the player to pick up and switch their weapons. 
     *
     *        If a weapon can be picked up (this excludes weapons being held by something), the function will
     *        move the new weapon to be a child of the the player (or enemy), as well as placing the weapon in the
     *        same orientation as the old weapon. 
     *
     *        The old weapon then will no longer have a parent and will be placed
     *        in the upright position. It will also be allowed to be picked up again.
     *
     *        If a weapon cannot be picked up, the old weapon will still be the current weapon held.
     *
     *        This function is called from an OnCollision2D function.
     *
     * @param GameObject oldWeapon The weapon (of type base_weapon) that the current player (or enemy) is holding.
     *
     * @returns GameObject The new current weapon that will need to be set in the player/enemy script.
     */
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
