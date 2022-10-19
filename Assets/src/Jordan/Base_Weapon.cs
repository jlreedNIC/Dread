using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
        decorator
        look into scriptable object for the stats
        fix switch weapon action

        look at creating weapon class and a weapon object/behavior class
            in essence, a weapon class that we can do the decorator on
            and an object class that will handle the gameobject behavior (spawning bullets and whatnot)
 */

public class Base_Weapon : MonoBehaviour
{
    public Transform firePoint; // where bullets spawn from

    public float bulletForce = 20f;

    [SerializeField] private string weapon_name; // make this part of decorator??
    [SerializeField] private float fire_rate;
    [SerializeField] private int weapon_dmg_mod;
    [SerializeField] private int fire_range;

    // gets set with the ammo manager
    public GameObject bullet_type; // delete

    // made public for inheritance purposes
    public bool canFire;
    public bool canBePickedUp;
    // when canbepickedup is false, turn collider off

    // audio manager
    // should we have this? or just call the script Dan is making???
    // [SerializeField] private AudioManager AudioMan;

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

    // Start is called before the first frame update
    public void Start()
    {
        // set audio manager variable to play the correct sounds
        // AudioMan = FindObjectOfType<AudioManager>();
        // if(AudioMan)
        // {
        //     Debug.Log("Found audio manager");
        // }
        // else
        // {
        //     Debug.Log("Did not find audio manager");
        // }

        // get firepoint if not set
        if(firePoint == null)
        {
            // get firepoint
            firePoint = this.gameObject.transform.GetChild(0);
        }

        // base range
        fire_range = 5;
        canFire = true;
        canBePickedUp = true;
    }

    // Update is called once per frame
    public void Update()
    {
        // if(!canBePickedUp) getComponent<collider>.deactivate //find better code
    }

    // currently spawns a bullet traveling in the upwards direction
    virtual public void Fire()
    {
        Debug.Log("base weapon fire");
        Debug.Log("fire? " + canFire);
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
            Debug.Log("weapon damage: " + curDmg + " fire rate: " + curRate + " fire range: " + curRange);

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

            // return the new weapon to be set in the player script
            return this.gameObject;
        }
        else
        {
            Debug.Log("can't switch with this weapon right now");
            return oldWeapon;
        }        
    }

    // when player leaves the old weapon behind, then it can be picked up again
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            canBePickedUp = true;
        }
    }
}
