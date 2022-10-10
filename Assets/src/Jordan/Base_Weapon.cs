using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
        decorator
 */

public class Base_Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint; // where bullets spawn from

    [SerializeField] private float bulletForce = 20f;

    [SerializeField] private string weapon_name;
    [SerializeField] private float fire_rate;
    [SerializeField] private int weapon_dmg_mod;
    [SerializeField] private int fire_range;

    // gets set with the ammo manager
    [SerializeField] private GameObject bullet_type;

    [SerializeField] private bool canFire;
    [SerializeField] private bool canBePickedUp;

    // audio manager
    // should we have this? or just call the script Dan is making???
    // [SerializeField] private AudioManager AudioMan;

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
        
    }

    // currently spawns a bullet traveling in the upwards direction
    public void Fire()
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
        
            canFire = !canFire;

            // bullet info will be set in ammo manager class
            // spawn bullet
            GameObject bullet = Instantiate(bullet_type, firePoint.position, firePoint.rotation);
            // set bullet distance able to travel
            bullet.GetComponent<bullet>().setFireRange(fire_range);
            // apply force to bullet to move
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 

            StartCoroutine(FireCooldown());
        }
        else
        {
            Debug.Log("can't fire yet");
        }
    }

    // weapon can only be fired so often
    // this function operates as the cooldown and will not let weapon be fired until ready
    private IEnumerator FireCooldown()
    {
        yield return new WaitForSeconds(fire_rate);
        canFire = true;
        yield break;
    }

    // switch which weapon the player is carrying
    // takes a GameObject parameter (must be of type base_class (which may be changed) )
    // returns the new weapon GameObject
    public GameObject SwitchActiveWeapon(GameObject oldWeapon)
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
            // oldWeapon.transform.position += new Vector3(2,0,0);
            oldWeapon.transform.rotation = new Quaternion(0,0,0,0);
            // oldWeapon.GetComponent<Base_Weapon>().canBePickedUp = false;

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
