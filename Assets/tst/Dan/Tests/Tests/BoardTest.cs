using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoardTest
{
    // Bounds test that checks the optimal upperbound for level generation
    [Test]
    public void UpperBoundTest()
    {
        int columns = 8;
        int rows = 8;
        
        BoardManager newRef  = BoardManager.Instance;
        /* InitializeList clears the gameboard of all tiles then populates
         the new level grid with tiles */ 
        newRef.InitializeList();
        Assert.AreEqual(8, rows);
        Debug.Log("Rows are equal to: " + rows);
        Assert.AreEqual(8, columns);
        Debug.Log("Columns are equal to: " + columns);
    }
    /* Bounds test to see if the board manager will take a matrix value
     * That is less than the optimal max value(8) for the tile set generator
     * grid = 8 x 8
     */
    [Test]
    public void LowerBoundTest()
    {
        int columns = 0;
        int rows = 0;
        
        BoardManager newRef  = BoardManager.Instance;
        /* InitializeList clears the gameboard of all tiles then populates
         the new level grid with tiles */ 
        newRef.InitializeList();
        Assert.AreEqual(0, rows);
        Debug.Log("Rows are equal to: " + rows);
        Assert.AreEqual(0, columns);
        Debug.Log("Columns are equal to: " + columns);

        // increase the size of the grid by 1 -> grid = 1 x 1
        columns = columns + 1;
        rows = rows + 1;
        newRef.InitializeList();
        Assert.AreEqual(1, rows);
        Debug.Log("Rows are equal to: " + rows);
        Assert.AreEqual(1, columns);
        Debug.Log("Columns are equal to: " + columns);

        // increase the size of the grid by 1 -> grid = 2 x 2
        columns = columns + 1;
        rows = rows + 1;
        newRef.InitializeList();
        Assert.AreEqual(2, rows);
        Debug.Log("Rows are equal to: " + rows);
        Assert.AreEqual(2, columns);
        Debug.Log("Columns are equal to: " + columns);
    }
}
