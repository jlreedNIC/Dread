using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint; 
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;

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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); // to use after mouse input added

        rb.AddForce(new Vector2(0.0f, bulletForce), ForceMode2D.Impulse);
    }
}
