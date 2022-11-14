using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MementoPattern;

public class Damageable : MonoBehaviour
{
   public int healthTotal = 0;
   //base health to be loaded in or set in editor 
   [SerializeField] public int baseHealth;

   //variable to hold and modify current health value
   [SerializeField] public int currentHealth;


   //Start
   //init curret health as sent in game object base health
   private void Start()
   {
      currentHealth = baseHealth;
      /****MEMENTO PATTERN DAN B ***/  
      // preserve original state of player
      // TEST currentHealth = 2;
      Memento.Originator orig = new Memento.Originator(); 
      orig.Health = currentHealth;  
      Debug.Log("Originator Recordinig CurrentHealth = " + orig.Health);
      // "Log" the initial health value via the caretaker subclass   
      Memento.CareTaker caretaker = new Memento.CareTaker();
      caretaker.PlayerHealth = orig.CreateMarker(orig);
      // checking that the care taker did not modify the player's health value
      Debug.Log("Creating Save State Player Health = " + orig.Health);
   }

   //TakeDamage() 
   //makes a game object take damage to their health
   //clamps value so it cannot go negative
   public void TakeDamage(int damageDealt)
   {
      currentHealth = Mathf.Clamp(currentHealth - damageDealt, 0, baseHealth);
      /*test*/
      // currentHealth = 2;
      /****MEMENTO PATTERN DAN B ***/
      // update the health state of player
      Memento.Originator orig = new Memento.Originator();
      // "Log" the modified health value via the caretaker subclass
      Memento.CareTaker caretaker = new Memento.CareTaker();
      caretaker.PlayerHealth = orig.CreateMarker(orig);
      Debug.Log("Creating Save State Player Health = " + caretaker.PlayerHealth);

      if (currentHealth <= 0)
      {
         if (this.gameObject.tag == "Player")
         {
                if(WinLossMngr.bcMode)
                {
                    WinLossMngr.addBCDeath();
                    currentHealth = baseHealth;
                }
                else
                {
                Destroy(this.gameObject);
                }
                
         }
         if (this.gameObject.tag == "Enemy")
         {
            EnemyObjectPooling.Instance.DespawnEnemy(this.gameObject);
         }
      }
   }

   //GainHealth() 
   //makes a game object gain health
   //clamps value so it cannot go over base health
   public void GainHealth(int healthObtained)
   {
      currentHealth = Mathf.Clamp(currentHealth + healthObtained, 0, baseHealth);
      /*Test*/
      // currentHealth = 80;
      if (currentHealth >= baseHealth)
      {
         currentHealth = baseHealth;
         /****MEMENTO PATTERN DAN B ***/
         // update the health state of player
         // CreateMarker marker = new CreateMarker();
         // marker.Health = currentHealth;
         // "Log" the modified health value via the caretaker subclass
         // CareTaker caretaker = new CareTaker();
         // caretaker.Memento = marker.CreateMarker();
         // Debug.Log("Save State Player Health After Healing = ", marker.Health);
      }
   }

   public void OnEnable()
   {
      currentHealth = baseHealth;
   }

   public void OnDestroy()
   {
      if (this.gameObject.tag == "Player")
      {
         Debug.Log(this.gameObject.name + " Was Destroyed");
         Destroy(this.gameObject);
      }
      if (this.gameObject.tag == "Enemy")
      {
         Debug.Log(this.gameObject.name + " Was returned to pool");

      }
   }
}