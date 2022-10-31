/**
 * @file    bullet.cs
 * @author  Jordan Reed
 *
 * @brief   This class manages the bullet gameobjects that are created in game.
 *
 * @date    September 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
        fix friendly fire issue
*/

/*
 * bullet: class to manage bullet gameobjects in game
 *
 * member variables:
 */
public class bullet : MonoBehaviour
{
    [SerializeField] private int total_damage;          // damage bullet will do to enemy/player
    [SerializeField] private Vector3 starting_point;    // initial position of bullet
    [SerializeField] private int max_distance;          // the max amount of distance a bullet can travel
    [SerializeField] private float dist_traveled;       // current distance traveled by bullet
    [SerializeField] private string bulletName;         // name of bullet type

    // Start is called before the first frame update
    void Start()
    {
        // set starting point when bullet is spawned by base weapon
        starting_point = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
        // Debug.Log("not deleting bullets just for test purposes");

        // check if object is damageable, then deal damage
        if(other.gameObject.TryGetComponent<Damageable>(out Damageable damageableComponent))
        {
            damageableComponent.TakeDamage(total_damage);
        }
        
        Destroy(gameObject);
    }

    /*
     * @brief sets the distance the bullet can travel before despawning
     *
     * @param int range The range the bullet is allowed to travel
     */
    public void setFireRange(int range)
    {
        max_distance = range;
    }

    /*
     * @brief Sets the total amount of damage the bullet will do upon collision
     *
     * @param int dmg The amount of damage a single bullet will do after weapon modifiers have been applied
     */
    public void setTotalDamage(int dmg)
    {
        total_damage = dmg;
    }

    // really only used for testing, otherwise could go in fixed update above
    /*
     * @brief Checks to see how far the bullet has traveled. If it's past the max distance
     *        allowed, the bullet will be destroyed.
     */
    public void CheckDistance()
    {
        if(dist_traveled >= max_distance)
        {
            // Debug.Log("destroyed bullet at dist " + dist_traveled);
            Destroy(gameObject);
        }
    }

    // used only in testing
    // may be able to get rid of when implementing play mode test
    public void TestDistTraveled(float n)
    {
        dist_traveled = n;
    }

    /*
     * @brief Returns the name of the bullet type
     *
     * @return string name of bullet
     */
    public string getName()
    {
        return bulletName;
    }
}