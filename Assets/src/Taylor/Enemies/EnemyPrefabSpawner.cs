using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabSpawner : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemyTypes;  

    [SerializeField] public float baseEnemySpawnRate; 

    public int maxNumEnemies = 0; 
    public int currentNumEnemies = 0; 

    public void Start()
    {
        maxNumEnemies = EnemyObjectPooling.Instance._defaultPoolSize; 

        EnemyObjectPooling.Instance.GenerateEnemies(maxNumEnemies,enemyTypes);

        StartCoroutine(spawnEnemy());
    }

    public IEnumerator spawnEnemy()
    {
        for(int i = 0; i < maxNumEnemies; i++)
        {
            Debug.Log(" Currently Requesting Enemy: " + (i+1)); 
            GameObject enemy = EnemyObjectPooling.Instance.RequestEnemy();
            enemy.transform.position = new Vector3(Random.Range(0f, 20f), Random.Range(0f, 20f), 0);
            currentNumEnemies++;
            yield return new WaitForSeconds(baseEnemySpawnRate);
        }
    }
}