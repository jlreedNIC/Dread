using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoardTest
{    
    // NOTE:
    // REQUIRES STATIC VARIABLES
    // The bounds checks for level generation dimensional values.

    // This test is to ensure the values are being preserved after the
    // Function InitializedList() clears all values for the board.

    

    [Test]
    public void UpperBoundTest()
    {   
        // int columns = BoardManager.rows;
        // int rows = BoardManager.columns;
        // // Check Default dimensions are preserved
        // BoardManager newRef  = BoardManager.Instance;
        // /* InitializeList() clears the gameboard of all tiles then populates
        //  the new level grid with tiles */ 
        // newRef.InitializeList();
        // Assert.AreEqual(8, rows);
        // Debug.Log("Rows are equal to: " + rows);
        // Assert.AreEqual(8, columns);
        // Debug.Log("Columns are equal to: " + columns);
    }

    [Test]
    public void LowerBoundTest()
    {
    //     int columns = BoardManager.columns;
    //     int rows = BoardManager.rows;

    //     rows = 0;
    //     columns = 0;
    //     // check to see if lower bounds are possible as an updated value
    //     BoardManager newRef  = BoardManager.Instance;
    //     /* InitializeList clears the gameboard of all tiles then populates
    //      the new level grid with tiles */ 
    //     newRef.InitializeList();
    //     Assert.AreEqual(0, rows);
    //     Debug.Log("Rows are equal to: " + rows);
    //     Assert.AreEqual(0, columns);
    //     Debug.Log("Columns are equal to: " + columns);

    //     // increase the size of the grid by 1 for each row and col size -> grid = 1 x 1
    //     // check to see if these bad values are preserved
    //     rows = 1;
    //     columns = 1;
    //     newRef.InitializeList();
    //     Assert.AreEqual(1, rows);
    //     Debug.Log("Rows are equal to: " + rows);
    //     Assert.AreEqual(1, columns);
    //     Debug.Log("Columns are equal to: " + columns);

    //     // increment the size of the grid by 1 for row and col size -> grid = 2 x 2 
    //     // check to see if the values are preserved
    //     rows = 2;
    //     columns = 2;
    //     newRef.InitializeList();
    //     Assert.AreEqual(2, rows);
    //     Debug.Log("Rows are equal to: " + rows);
    //     Assert.AreEqual(2, columns);
    //     Debug.Log("Columns are equal to: " + columns);
    }
}
