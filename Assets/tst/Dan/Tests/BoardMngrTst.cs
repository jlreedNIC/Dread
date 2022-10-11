using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.TestTools;

public class BoardMngrTst
{
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

    // initialize gameboard size for array to be a default 8 x 8 matrix
    public int columns = 8;
    public int rows = 8;
    // instantiate wall boundaries tile limits -> min = 5 walls, max = 9 walls
    public Count wallCount = new Count (5,9);

    // Prefab Variables
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] outerWallTiles;

    private Transform boardHolder;

    /* Keeps track of grid positions to determine if a tile
     * has been spawned or not.
     */ 
    
    private List<Vector3> gridPositions = new List<Vector3>();
    
    [Test]
    void InitializeList()
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

    [Test]
    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for(int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range (0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range (0, outerWallTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }
    }

    [Test]
    // spawns level tiles onto the game board
    Vector3 RandomPosition()
    {
        int randomIndex =  Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        // use this value to spawn an object in a random location
        return randomPosition;
    }
    [Test]
    // tile spawner function
    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        // controls the number of objects spawned in the level
        int objectCount = Random.Range(minimum, maximum + 1);
        // spawn the number of objects specified by object count
        for(int i = 0; i < objectCount; i++)
        {
            // choose a random position to start spawning [call to randoms position function]
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            // Do Not Rotate Tiles
            Instantiate (tileChoice, randomPosition, Quaternion.identity);
        }
    }

    [Test]
    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
        LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        /* Spawn # of enemies based on the level's number IE: level 1 spawn 1 enemy; 2 spawn 2,..etc.
         * int enemyCount = (int)Mathf.Log(level, 2f);
         * LayoutObjectAtRandom(enemyTiles, enemyCount, enemyCount);
         */
         Instantiate(exit, new Vector3(columns - 1, rows - 1, 0F), Quaternion.identity);
    }
}
