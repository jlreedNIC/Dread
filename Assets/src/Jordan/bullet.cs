using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private int total_damage;
    [SerializeField] private Vector3 starting_point;
    [SerializeField] private int distance;
    [SerializeField] private float dist_traveled;

    // Start is called before the first frame update
    void Start()
    {
        // set starting point when bullet is spawned by base weapon
        starting_point = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // check amount of distance allowed to travel
        // if dist. traveled is max then destroy game object
        dist_traveled = Vector3.Distance(starting_point, transform.position);
        if(dist_traveled >= distance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("damage: " + total_damage);

        // check if object is damageable, then deal damage
        if(other.gameObject.TryGetComponent<Damageable>(out Damageable damageableComponent))
        {
            damageableComponent.TakeDamage(total_damage);
        }
        
        Destroy(gameObject);
    }

    // sets the distance the bullet can travel before despawning
    public void setFireRange(int range)
    {
        distance = range;
    }
}
