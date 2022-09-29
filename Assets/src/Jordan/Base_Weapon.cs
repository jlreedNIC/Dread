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

    [SerializeField] private GameObject bullet_type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // likely to be in player script
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        
    }

    // currently spawns a bullet traveling in the upwards direction
    void Fire()
    {
        GameObject bullet = Instantiate(bullet_type, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // to use after mouse input added

        // rb.AddForce(new Vector2(0.0f, bulletForce), ForceMode2D.Impulse);
    }
}
