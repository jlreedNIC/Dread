# GameManager.cs Prefab Overview

# **Class Role**
- The GameManager class is meant to act as a "middle man" for the board manager and other fucntionality in our game. The class relies on a singleton implementation as a preventative measure to avoid multi-instantiation of the prefab tiles and procedural generation of the level.
# **Class Heirarchy**
1. Loader.cs
2. GameManager.cs
3. BoardManager.cs

# Demonstration of GameManager.cs Video Link:
YouTube Link: [Game Manager Demo](https://youtu.be/ESsWxhA1P00)

# **Loader Class Script**
1. Checks to see if the GameManager instance is set to null.
2. If the instance is set to null, loader.cs calls for the GameManager to instantiate
3. If the instance is not set to null, then the singleton implmentation will keep one instance of GameManager preserved and destroy any other instances trying to be created.

# **Functions**
1. void Awake( ) 
   - with if statement for singleton verification.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

# **Game Manager Class Script**
1. Singleton instantiation of the GameMananger class
2. Inititates Level Generation via BoardManager.cs if singleton parameters are met.
## Variables
- public static GameManager instance = null
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
