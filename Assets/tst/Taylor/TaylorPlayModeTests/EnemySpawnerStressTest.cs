using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemySpawnerStressTest
{
    public float fps = 0;

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest] public IEnumerator EnemySpawnerStress()
    {
        SceneManager.LoadScene("Taylor_Testing");
        yield return new WaitForSeconds(3); // wait for scene to load

        GameObject player = GameObject.Find("Test_Player");
        GameObject enemy = GameObject.Find("Test_Enemy");

        long numOfEnemies = 1;

        while (true)
        {
            fps = 1.0f / Time.deltaTime;

            GameObject newEnemy = GameObject.Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);

            newEnemy.transform.parent = enemy.transform.parent;
            
            numOfEnemies++;
   
            Debug.Log("Number of enemies: " + numOfEnemies + " FPS: " + fps);
            
            // check if it breaks
            if (fps < 15)
            {
                Debug.Log("Number of enemies when fps dipped below 15: " + numOfEnemies);
                break;
            }

            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null; // wait a frame
        }
        yield return null;
    }
}