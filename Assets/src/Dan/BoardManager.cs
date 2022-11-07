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
    // NOTE: STATIC ONLY FOR TESTING PURPOSES!! REMOVE AFTER TO RE-SERIALIZE IN INTERPRETER MODE
    public int columns = 8;
    public int rows = 8;

    // Instantiate wall boundaries min = 5 walls, max = 9 walls
    public Count wallCount = new Count (5,9);

    // Prefab Variables
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] outerWallTiles;



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
                Instantiate(tileChoice, randomPosition, Quaternion.identity);
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
        if(columns < 8 || rows < 8)
        {
            Debug.Log("Out of Bounds Error: dimensional value entered for a row or col is less than 8");
            Application.Quit();
        }
        else
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        /* Spawn # of enemies based on the level's number IE: level 1 spawn 1 enemy; 2 spawn 2,..etc.
         * int enemyCount = (int)Mathf.Log(level, 2f);
         * LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
         */
         Instantiate(exit, new Vector3(columns - 1, rows - 1, 0F), Quaternion.identity);
         
        // Calculate all graphs
        AstarPath.active.Scan();
    }
}