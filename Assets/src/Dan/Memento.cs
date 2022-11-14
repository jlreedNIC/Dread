/******************************************************* 
 *The Memento class stores player information such as:
 * upgrades and life total. Level progression is also
 * recorded by this class
 ******************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MementoPattern
{
   public class Memento
   {
      public int Level;
      public int Health;

      public Memento(int level, int health)
      {
         this.Level = level;
         this.Health = health;
      }

      //'CareTaker' class
      public class CareTaker
      {
         // store a checkpoint for a successfully completed level
         public Memento LevelMarker;
         public Memento PlayerHealth;
      }
      //'Originator' Class
      public class Originator
      {
        public int Level;
        public int Health;
         // Saves values in the memento class
         public Memento CreateMarker(Originator player)
         {
            return new Memento(player.Level, player.Health);
         }
         // Restores values from the memento class (getter)
         public void RestoreLevel(Memento playerMemento)
         {
            this.Level = playerMemento.Level;
            this.Health = playerMemento.Health;
         }

         public void DisplayPlayerInfo()
         {
            Debug.Log("Level: " + this.Level);
            Debug.Log("Health: " + this.Health);
         }
      }
   }
}