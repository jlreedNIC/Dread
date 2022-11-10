using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabSpawner : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemyTypes;  

    [SerializeField] public float baseEnemySpawnRate = 3.5f; 

    public int maxNumEnemies = 0; 
    public int currentNumEnemies = 0; 
    public bool isAbleToSpawn = true; 

    void Start()
    {
        maxNumEnemies = EnemyObjectPooling.Instance._defaultPoolSize; 
        EnemyObjectPooling.Instance.GenerateEnemies(maxNumEnemies,enemyTypes);
        StartCoroutine(spawnEnemy());
    }
    // public void spawnEnemy()
    // {
    //     Debug.Log("In spawnEnemy"); 

    //     while(true)
    //     {
    //         Debug.Log(" Current max Enemy pool size: " + maxNumEnemies); 

    //         if(currentNumEnemies >= maxNumEnemies)
    //         {
    //             isAbleToSpawn = false;
    //             Debug.Log(" Max Spawn Limit Reached. Exiting Loop In spawnEnemy"); 
    //             break; 
    //         }
    //         if(currentNumEnemies < maxNumEnemies)
    //         {
    //             Debug.Log("Enemies Left To Set Active: " + (maxNumEnemies - currentNumEnemies)); 
    //             isAbleToSpawn = true; 
    //         }
    //         if(isAbleToSpawn)
    //         {
    //             Debug.Log(" Currently Requesting Enemy: "); 
    //             GameObject enemy = EnemyObjectPooling.Instance.RequestEnemy(); 
    //             //enemy.transform.position = new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0);
    //             currentNumEnemies++; 
    //             Debug.Log(" Current number of enemies set active: " + currentNumEnemies);
    //         }
    //     }
    //     //yield return new WaitForSeconds(interval);
    // }

    private IEnumerator spawnEnemy()
    {
        for(int i = 0; i < maxNumEnemies; i++)
        {
            Debug.Log(" Currently Requesting Enemy: " + (i+1)); 
            // GameObject enemy = EnemyObjectPooling.Instance.GetEnemyFromPool();
            GameObject enemy = EnemyObjectPooling.Instance.RequestEnemy();
            enemy.transform.position = new Vector3(Random.Range(0f, 20f), Random.Range(0f, 20f), 0);
            currentNumEnemies++;
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
    }
}