/* BoardManager.cs
 * 
 * This script defines the board prefabs, assets, and procedural generation
 * of the level. Exterior walls are placed first, then the floor terrain tiles,
 * and last the interior walls and game objects. 
 */


using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    // Set fields to be visible in the inspector
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    // initialize gameboard size to default values for an 8 x 8 matrix
    // NOTE: STATIC DECLARATION SHOULD ONLY BE USED FOR TESTING PURPOSES!! REMOVE AFTER TO RE-SERIALIZE IN INTERPRETER MODE
    public int columns = 8;
    public int rows = 8;

    // Instantiate wall boundaries min = 5 walls, max = 9 walls
    public Count wallCount = new Count (5,9);

    // Prefab Level Tile Variables
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] outerWallTiles;

    // jordan's items and weapons
    public GameObject[] ammoPickUps;
    public GameObject[] healthPickUps;
    public GameObject[] upgrades;
    public GameObject[] shipParts;

    public GameObject playerPrefab; 


    private Transform boardHolder;

    /* 
     * Keeps track of grid positions to determine if a tile
     * has been spawned or not.
     */ 
    private List<Vector3> gridPositions = new List<Vector3>();
    
    /* 
     * Clears the board and manages tile, object, and enemy assignments
     */
    public void InitializeList()
    {
        // before generation, clear the gameboard of all tiles
        gridPositions.Clear();
        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                // add new room tiles, objects, and enemies where none currently exist on the map
                gridPositions.Add(new Vector3(x,y,0f));
            }
        }
    }

    // Instantiates the tile array types and prepares them to randomly be placed on the tile map
    public void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for(int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range (0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = outerWallTiles[Random.Range (0, outerWallTiles.Length)];
                }
                
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }
    
    // Randomizes level tiles and postions for them to be placed onto the game board
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        // use this value to spawn an object in a random location
        return randomPosition;
    }

    // tile spawner function
    public int LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        if( minimum != 0 && maximum != 0)
        {   
            // controls the number of objects spawned in the level
            int objectCount = Random.Range(minimum, maximum + 1);

            // spawn the number of objects specified by object count
            for(int i = 0; i < objectCount; i++)
            {
                // choose a random position to start spawning [call to randoms position function]
                Vector3 randomPosition = RandomPosition();
                GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
                // Do Not Rotate Tiles On Instantiation
                GameObject instance = Instantiate(tileChoice, randomPosition, Quaternion.identity);

                instance.transform.parent = boardHolder;
                // instance.transform.SetParent(boardHolder);
                
            }
        }
        return (maximum);
    }
    
    // Generates the board and initilizes the arrays with between 5 - 9 interior wall tiles,
    // a perimeter wall, and a guaranteed exit tile.
    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
        // guard code to ensure that instantiation of a board with less than the optimal dimensions
        // does not occur and crash the game
        if(columns < 8 || rows < 8)
        {
            Debug.Log("Out of Bounds Error: dimensional value entered for a row or col is less than 8");
            Application.Quit();
        }
        else
        // place all tiles and walls in the scene
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        /* [Place holder For Any Enemy instantiation if needed]
         * Spawn # of enemies based on the level's number IE: level 1 spawn 1 enemy; 2 spawn 2,..etc.
         * int enemyCount = (int)Mathf.Log(level, 2f);
         
         * LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
         */

         // spawn the exit tile in the upper right hand corner of the map (guaranteed)
         Instantiate(exit, new Vector3(columns - 1, rows - 1, 0F), Quaternion.identity);
         exit.transform.parent = boardHolder;
         
        // Calculate all graphs
        AstarPath.active.Scan();
        // Instantiate(playerPrefab, new Vector3(0,0,0), Quaternion.identity);
        GameObject.FindWithTag("Player").transform.position = new Vector3(0,0,0);

        // items instantiated after level scanned so as not to interfere with enemy paths
        // regular health and ammo pickups
        LayoutObjectAtRandom(ammoPickUps, 1, 2);
        LayoutObjectAtRandom(healthPickUps, 1, 2);

        // upgrades
        LayoutObjectAtRandom(upgrades, 1, 2);

        // ship parts
        LayoutObjectAtRandom(shipParts, 1, 1);

    }
}