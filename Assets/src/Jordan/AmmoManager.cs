using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
        make sure this is not creating more than one instance
 */

public sealed class AmmoManager : MonoBehaviour
{
    // singleton implementation
    private AmmoManager() {}
    // public static AmmoManager Instance
    // {
    //     get
    //     {
    //         return Nested.instance;
    //     }
    // }

    // private class Nested
    // {
    //     static Nested() {}
    //     // internal static readonly AmmoManager instance = new AmmoManager();
    //     internal static readonly AmmoManager instance = new GameObject().AddComponent<AmmoManager>();
    // }
    public static AmmoManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Debug.Log("tried creating new instance");
            Destroy(this);
        }
        else
        {
            Debug.Log("new instance");
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // when do we actually need to use this?
        }
    }

    [SerializeField] private int totalAmmo;             // total amount of ammo available
    [SerializeField] private int maxTotal;              // total amount of ammo able to be carried
    [SerializeField] private int ammoDamage;            // ammount of damage that the ammo can do
    
    [SerializeField] private GameObject bullet_type;    // current bullet type to create

    void Start()
    {
        // initial ammo inventory set to 40
        totalAmmo = maxTotal = 40;
    }

    // function will return the total amount of ammo currently have
    public int GetTotalAmmo()
    {
        return totalAmmo;
    }

    // function will return the max amount of ammo able to be carried
    public int GetMaxAmmo()
    {
        return maxTotal;
    }

    public int GetAmmoDamage()
    {
        return ammoDamage;
    }

    public string GetCurrentBulletName()
    {
        return bullet_type.GetComponent<bullet>().getName();
    }

    public void updateAmmoCount(int n)
    {
        totalAmmo += n;
        if(totalAmmo <= 0) totalAmmo = 0;
        else if(totalAmmo >= maxTotal) totalAmmo = maxTotal;
    }

    public void updateMaxTotal(int count)
    {
        maxTotal += count;
    }

    // set the current ammo type
    // takes a gameobject type (prefab for bullet)
    public void SetNewAmmoType(GameObject bullet)
    {
        // this function will set the currentAmmoType and ammoDamage
        // based off of what is received

        // this is designed for picking up new 'items' that will give upgraded bullets
        bullet_type = bullet;
    }
    
    // returns null if not enough ammo
    public GameObject createBullet(int range, int damage, Transform firePoint)
    {
        if(totalAmmo > 0)
        {
            // Debug.Log("creating new bullet " + range);
            // create a bullet here with the range, damage, position, rotation
            GameObject bullet = Instantiate(bullet_type, firePoint.position, firePoint.rotation);

            // set max bullet dist and bullet damage
            bullet.GetComponent<bullet>().setFireRange(range);
            bullet.GetComponent<bullet>().setTotalDamage(damage);

            updateAmmoCount(-1);

            return bullet;
        }
        else return null;
    }
}
