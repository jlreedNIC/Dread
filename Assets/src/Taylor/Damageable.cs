using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour 
{
    [SerializeField] public int baseHealth;

    [SerializeField] public int currentHealth;  

    private void Start()
    {
        currentHealth = baseHealth;

    }

    public void TakeDamage(int damageDealt)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageDealt, 0, baseHealth);

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    
    public void OnDestroy()
    {
        Debug.Log(this.gameObject.name + " Was Destroyed"); 
    }
}
