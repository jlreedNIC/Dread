using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // audio manager
    // should we have this? or just call the script Dan is making???
    [SerializeField] private AudioManager AudioMan;

    // Start is called before the first frame update
    public void Start()
    {
        // set audio manager variable to play the correct sounds
        AudioMan = FindObjectOfType<AudioManager>();
        if(AudioMan)
        {
            Debug.Log("Found audio manager");
        }
        else
        {
            Debug.Log("Did not find audio manager");
        }

        // get firepoint if not set
        if(firePoint == null)
        {
            // get firepoint
            firePoint = this.gameObject.transform.GetChild(0);
        }

        // base range
        fire_range = 5;

    }

    // Update is called once per frame
    public void Update()
    {
        // likely to be in player script
        // if(Input.GetButtonDown("Fire1"))
        // {
        //     Fire();
        //     /* Plays Audio clip for gun firing on player clicks.
        //     NOTE: This feature will need to be adjusted for other weapon types later in develoment
        //     as they will have alternate sound bites. DB*/
        //     // FindObjectOfType<AudioManager>().Play("Pew");
        // }
        
    }

    // currently spawns a bullet traveling in the upwards direction
    public void Fire()
    {
        // play pewpew sound
        if(AudioMan)
        {
            Debug.Log("Playing pewpew sound!");
            AudioMan.Play("Pew");
        }

        // spawn bullet
        GameObject bullet = Instantiate(bullet_type, firePoint.position, firePoint.rotation);
        // set bullet distance able to travel
        bullet.GetComponent<bullet>().setFireRange(fire_range);
        // apply force to bullet to move
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 
    }
}
