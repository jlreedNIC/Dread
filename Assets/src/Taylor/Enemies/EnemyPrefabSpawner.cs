using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabSpawner : MonoBehaviour
{
    // [SerializeField] public List<GameObject> enemies; 

    // [SerializeField] public List<Transform> spawnPoints; 

    [SerializeField] public GameObject enemyPrefab; 


    [SerializeField] public float baseEnemySpawnRate = 3.5f; 

    public int maxNumEnemies = EnemyObjectPooling.Instance._defaultPoolSize; 
    public int currentNumEnemies = 0; 
    public bool isAbleToSpawn = true; 


    // Start is called before the first frame update
    // void Start()
    // {
    //     spawnEnemy();
    //     //StartCoroutine(spawnEnemy(baseEnemySpawnRate));
    //     // StartCoroutine(spawnEnemy(baseEnemySpawnRate, enemyPrefab));
    // }
    void Start()
    {
        StartCoroutine(spawnEnemy());
        // spawnEnemy();
        //StartCoroutine(spawnEnemy(baseEnemySpawnRate));
        // StartCoroutine(spawnEnemy(baseEnemySpawnRate, enemyPrefab));
    }
    public void Update()
    {
        // int randEnemy = Random.Range(0,enemies.Length);
        // int ranSpwanPoint = Random.Range
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

    public IEnumerator spawnEnemy()
    {
        for(int i = 0; i < maxNumEnemies; i++)
        {
            Debug.Log(" Currently Requesting Enemy: " + (i+1)); 
            GameObject enemy = EnemyObjectPooling.Instance.RequestEnemy(); 
        }
        yield return new WaitForSeconds(1f);
    }

    // private IEnumerator spawnEnemy(float interval, GameObject enemy)
    // {
    //     yield return new WaitForSeconds(interval);
    //     //GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
    //     GameObject newEnemy = EnemyObjectPooling.Instance.RequestEnemy(); 
    //     //newEnemy.transform.position = new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0);
    //     StartCoroutine(spawnEnemy(interval, enemy));
    // }

}