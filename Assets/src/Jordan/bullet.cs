using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private int total_damage;
    [SerializeField] private Transform starting_point;
    [SerializeField] private int distance;

    // Start is called before the first frame update
    void Start()
    {
        // set starting point when bullet is spawned by base weapon
    }

    // Update is called once per frame
    void Update()
    {
        // either here or in fixed update, check amount of distance allowed to travel
        // if dist. traveled is max then destroy game object
        // think about setting up collider for range that gets set with each new weapon
        // on collider exit, (or collide with enemy) destroy object
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("damage: " + total_damage);

        // call damageable script TakeDamage()
        if(other.gameObject.TryGetComponent<Damageable>(out Damageable damageableComponent))
        {
            damageableComponent.TakeDamage(total_damage);
        }

        Destroy(gameObject);
    }
}
