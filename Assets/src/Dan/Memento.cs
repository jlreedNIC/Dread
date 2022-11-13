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
   public class Memento : MonoBehaviour
   {
      public int Level;
      public string Health;

      public Memento(int level, string health)
      {
         this.Level = level;
         this.Health = health;
      }

      //'CareTaker' class
      public class CareTaker
      {
         // store a checkpoint for already crossed level
         public Memento LevelMarker;
      }
      //'Originator' Class
      public class Originator
      {
        public int Level;
        public string Health;
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