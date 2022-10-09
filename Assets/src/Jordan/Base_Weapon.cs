using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Weapon : MonoBehaviour
{
    [SerializeField] public Transform firePoint; // where bullets spawn from

    [SerializeField] public float bulletForce = 20f;

    [SerializeField] public string weapon_name;
    [SerializeField] public float fire_rate;
    [SerializeField] public int weapon_dmg_mod;
    [SerializeField] public int fire_range;

    [SerializeField] public GameObject bullet_type;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        // // likely to be in player script
        // if(Input.GetButtonDown("Fire1"))
        // {
        //     Fire();
        //     /* Plays Audio clip for gun firing on player clicks.
        //     NOTE: This feature will need to be adjusted for other weapon types later in develoment
        //     as they will have alternate sound bites.*/
        //     FindObjectOfType<AudioManager>().Play("Pew");
        // }
        
    }

    // currently spawns a bullet traveling in the upwards direction
    public void Fire()
    {
        GameObject bullet = Instantiate(bullet_type, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // to use after mouse input added

        // rb.AddForce(new Vector2(0.0f, bulletForce), ForceMode2D.Impulse);
    }
}
