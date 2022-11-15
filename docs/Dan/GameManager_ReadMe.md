# GameManager.cs Prefab Overview

## Glossary
### * Instantiate: Represent as or by an instance.
### * Spawn: To generate or instantiate (see above) a game object, item, or rendered graphic into the game scene (environment).  

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

## **Class Role**
- The GameManager class is meant to act as a "middle man" for the board manager and other fucntionality in our game. The class relies on a singleton implementation as a preventative measure to avoid multi-instantiation of the prefab tiles and procedural generation of the level.

## Updated Class Diagram
![updated diagram](https://github.com/jlreedNIC/Dread/blob/main/docs/Dan/Class%20Diagram.png)
## **Class Heirarchy**
1. Loader.cs
2. GameManager.cs
3. BoardManager.cs

# Demonstration of GameManager.cs Video Link:
- YouTube Link: [Game Manager Demo](https://youtu.be/ESsWxhA1P00)
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

# **Loader Class Script**
## What This Class Does:
1. Checks to see if the GameManager instance is set to null.
2. If the instance is set to null, loader.cs calls for the GameManager to instantiate.
3. If the instance is not set to null, then the singleton implmentation will keep one instance of GameManager preserved and destroy any other instances trying to be created.

## **Functions**
1. void Awake( ) 
   - If statement in the function checks for singleton instatiation of GameManager to null or not null.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

# **Game Manager Class Script**
## What This Class Does:
1. Singleton instantiation of the GameMananger class.
2. Inititates Level Generation via BoardManager.cs if singleton parameters are met.
## Variables
- public static GameManager instance.
- public BoardManager boardScript (BoardManagger object)
- private int level = 1 (sets default value of level progression tracker to 1)
## Functions
1. void Awake ( ) 
   - defines singleton instantiation and destruction methods for the GameManager class instance. If all conditions are met to allow for an instance,
     then InitGame ( ) is called.
2. void InitGame( ) 
   - Invokes boardScript.SetUpScene(level) 
       - passes the level progression counter to SetUpScence which will tell the board manager what level we are on and based on it how many objects to spawn.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Board Manager Class Script
## What This Class Does
1. Sets up random placement for tile prefabs.
2. Generates a level based on dimensions defined its serialized fields.
3. Places obstacles and items within the interior boundaries of the level.
## Additional Unity Libraries Used For This Class Implementation
  - UnityEngine.Random
  - System 
## Sub Classes
  - public class Count
       * public int minimum
       * public int maximum
       * public Count (int min, int max)
## Variables
   - public int columns
   - public int rows
   - public Count interiorWallCount
   - public GameObject exit
   - public GameObject[] floorTiles
   - public GameObject[] wallTiles
   - public GameObject[] outerWallTiles
## GameObjects
   - public GameObject playerPrefab
## Transform
   - private Transform boardHolder
## List - Vector3
   - private List<Vector3> gridPositions
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Functions
   - public void InitializeList()
     - Clears the board anda mananges tiles, objects/items, and enemy spawn positions.
   - public void boardSetup()
     - Intstantiates the tile array types and prepares them to randomly be placed on the tile map and generates a guaranteed exit in the upper right hand corner.
     - Spawns all outer wall tiles based on the room dimensions
   - Vector3 RandomPosition()
     - Randomizes level tiles and positions(coordinate tuple values) for them to be placed on the gameboard.
   - public int LayoutObjectsAtRandom(GameObject[], int, int)
     - This function spawns the tiles based on the min and max values assigned to the board dimensions.
   - public void SetupScene(int)
     - This function is responsible for generating everything else and placing them on the interior tiles and items.
