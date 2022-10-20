using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProcGenStress
{
    public float fps = 0f;

    [UnityTest]
    public IEnumerator LargeRoomTest()
    {
        int row = 0;    
        int cols = 0;
        cols = BoardManager.columns;
        row = BoardManager.rows;
        // show 8 x 8 map
        SceneManager.LoadScene("level_stress_test");
        // wait for scene to load
        yield return new WaitForSeconds(3);
        // increment map dimensions until fail condition
        for(int i = 8; i < 100000; i++)
        {
            // fps = 1.0f /Time.deltaTime;
            BoardManager.columns = cols + i;
            BoardManager.rows = row + i;

            SceneManager.LoadScene("level_stress_test");
            // wait for scene to load
            yield return new WaitForSeconds(0.05f);
            Debug.Log("Increasing dimensions to " + i + " x " + i);

            // Check for fatal error
            if( i >= 290)
            {
                Debug.Log("Map generation tanked the system at dimensions:" + i + " x " + i);
                break;
            }
            yield return null;
        };
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
