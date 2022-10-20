using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour 
{
    //base health to be loaded in or set in editor 
    [SerializeField] public int baseHealth;

    //variable to hold and modify current health value
    [SerializeField] public int currentHealth;  

    //Start
    //init curret health as sent in game object base health
    private void Start()
    {
        currentHealth = baseHealth;
    }

    //TakeDamage() 
    //makes a game object take damage to thier health
    //clamps value so it cannot go negative
    public void TakeDamage(int damageDealt)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageDealt, 0, baseHealth);

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //GainHealth() 
    //makes a game object gain health
    //clamps value so it cannot go over base health
    public void GainHealth(int healthObtained)
    {
        currentHealth = Mathf.Clamp(currentHealth + healthObtained, 0, baseHealth);

        if(currentHealth >= baseHealth)
        {
            currentHealth = baseHealth;
        }
    }

    
    public void OnDestroy()
    {
        Debug.Log(this.gameObject.name + " Was Destroyed"); 
    }
}