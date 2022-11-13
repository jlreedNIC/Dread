/**
 * @file    AmmoManager.cs
 * @author  Jordan Reed
 *
 * @brief   This class will keep track of the ammunition the player is allowed to use.
 *          It will keep track of the ammo type, the amount of ammo, the damage the ammo will do,
 *          and it will create the ammo at a specified position (ie at the end of the gun).
 *
 * @date    October 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *   TO DO:
 */

public sealed class AmmoManager : MonoBehaviour
{
    // singleton implementation
    private AmmoManager() {}
    public static AmmoManager Instance
    {
        get
        {
            return Nested.instance;
        }
    }

    private class Nested
    {
        static Nested() {}
        // internal static readonly AmmoManager instance = new AmmoManager();
        internal static readonly AmmoManager instance = new GameObject().AddComponent<AmmoManager>();
    }

    // not sure if we need this for scene transitions
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // variables are serialized to allow for seeing them in unity
    [SerializeField] private int totalAmmo;             // total amount of ammo available
    [SerializeField] private int maxTotal;              // total amount of ammo able to be carried
    [SerializeField] private int ammoDamage;            // ammount of damage that the ammo can do
    [SerializeField] private GameObject bulletType;     // current bullet type to create

    /*
     * @brief initialize variables that need to be set at the start
     */
    void Start()
    {
        // initial ammo inventory set to 40
        totalAmmo = maxTotal = 40;

        // sets the prefab for the bullet so singleton can instantiate it the first time
        // this will also set the damage each bullet does
        if(bulletType == null)  
        {
            bulletType = Resources.Load<GameObject>("Bullet");
            SetNewAmmoType(bulletType);      
        }
    }

    public void resetAmmoMan()
    {
        bulletType = Resources.Load<GameObject>("Bullet");
        SetNewAmmoType(bulletType); 
        totalAmmo = maxTotal = 40;
    }

    /*
     * @brief returns the current amount of ammo player has
     *
     * @return int current ammo
     */
    public int GetTotalAmmo()
    {
        return totalAmmo;
    }

    /*
     * @brief returns the max amount of ammo able to be carried
     *
     * @return int max ammo amount
     */
    public int GetMaxAmmo()
    {
        return maxTotal;
    }

    /*
     * @brief returns the amount of damage a single bullet will do
     *
     * @return int bullet damage
     */
    public int GetAmmoDamage()
    {
        return ammoDamage;
    }

    /*
     * @brief returns the name of a bullet type. For use in item screens
     *
     * @return string bullet name
     */
    public string GetCurrentBulletName()
    {
        return bulletType.GetComponent<Bullet>().getName();
    }

    /*
     * @brief Updates the total ammo the player has. Checks upper and lower bounds
     *
     * @param int amount of bullets to add to current total
     */
    public void updateAmmoCount(int n)
    {
        totalAmmo += n;
        if(totalAmmo <= 0) totalAmmo = 0;
        else if(totalAmmo >= maxTotal) totalAmmo = maxTotal;
    }

    /*
     * @brief Updates the maximum amount of ammo the player has
     *
     * @param int amount of bullets to add to current maximum
     */
    public void updateMaxTotal(int count)
    {
        maxTotal += count;
    }

    /*
     * @brief Updates the ammo type to create for the player. Also sets the base damage each bullet will do.
     *
     * @param GameObject intended to be a bullet prefab that is new ammo type
     */
    public void SetNewAmmoType(GameObject bullet)
    {
        bulletType = bullet;
        ammoDamage = bulletType.GetComponent<Bullet>().getDamage();
    }
    
    /*
     * @brief Creates a bullet with the given information. Returns the bullet back to the method that
     *        called it so it can apply force in the right direction. If there is not enough ammo, it will return null.
     *
     * @param int range The range the bullet is allowed to travel
     * @param int damage The amount of damage a single bullet will do after weapon modifiers have been applied
     * @param Transform firePoint The object that has the starting position and rotation for the new bullet
     *
     * @returns GameObject new bullet with specified parameters
     *          null if not enough ammo
     */
    public GameObject createBullet(int range, int damage, Transform firePoint)
    {
        if(totalAmmo > 0)
        {
            // Debug.Log("creating new bullet " + range);

            // create a bullet here with the range, damage, position, rotation
            GameObject bullet = Instantiate(bulletType, firePoint.position, firePoint.rotation);

            // if a weapon's base damage is 0, then make it 1 for the purpose of multiplying down below
            if(damage == 0)
            {
                damage++;
            }

            // set max bullet dist and bullet damage
            bullet.GetComponent<Bullet>().setFireRange(range);
            bullet.GetComponent<Bullet>().setTotalDamage(damage*ammoDamage);

            // subtract from ammo count
            updateAmmoCount(-1);

            return bullet;
        }
        else return null;
    }
}

