using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
        fix friendly fire issue
*/

public class bullet : MonoBehaviour
{
    [SerializeField] private int total_damage;
    [SerializeField] private Vector3 starting_point;
    [SerializeField] private int max_distance;
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
        CheckDistance();
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
        max_distance = range;
    }

    public void setTotalDamage(int dmg)
    {
        total_damage = dmg;
    }

    // really only used for testing, otherwise could go in fixed update above
    public void CheckDistance()
    {
        if(dist_traveled >= max_distance)
        {
            Destroy(gameObject);
        }
    }
    // used only in testing
    // may be able to get rid of when implementing play mode test
    public void TestDistTraveled(float n)
    {
        dist_traveled = n;
    }
}
