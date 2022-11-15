/*****************************************************************
 * GameManager.cs                                                *
 *                                                               *
 * Singleton class implementation ensures that only one instance *
 * of a level and all assets of the BoardManger and others       *
 * invoked in the GameManager are only instantiated once.        *
 * The initial instantiated objects are then destroyed           *
 * then reinvoked upon termination of the game,                  *
 * the player's life total, or during a level transition.        *
 *****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
    public static GameManager instance = null;

    public BoardManager boardScript;

    // test level
    public int level = 1;

    // Start is called before the first frame update
    void Awake()
    {   
        //Singleton implementation
        if (instance = null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        // if it is the first instantiation be sure to preserve
        // the current instance of a level.
        DontDestroyOnLoad(gameObject);
        
        // generate a level
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
        // any other game objects go below here
    }

    // Update is called once per frame
    void Update()
    {
        
    }
=======
   public static GameManager instance = null;

   public BoardManager boardScript;

   // test level
   private int level = 1;

   // Start is called before the first frame update
   void Awake()
   {
      //Singleton implementation
      if (instance = null)
      {
         instance = this;
      }
      else if (instance != this)
      {
         Destroy(gameObject);
      }
      // if it is the first instantiation be sure to preserve
      // the current instance of a level.
      DontDestroyOnLoad(gameObject);

      // generate a level
      boardScript = GetComponent<BoardManager>();
      InitGame();
   }

   void InitGame()
   {
      boardScript.SetupScene(level);
      // any other game objects go below here
   }

   // Update is called once per frame
   void Update()
   {

   }
>>>>>>> Stashed changes
}