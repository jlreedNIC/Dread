using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabSpawner : MonoBehaviour
{
    // [SerializeField] public List<GameObject> enemies; 

    // [SerializeField] public List<Transform> spawnPoints; 

    [SerializeField] public GameObject enemyPrefab; 


    [SerializeField] public float baseEnemySpawnRate = 3.5f; 


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(baseEnemySpawnRate, enemyPrefab));
    }
    public void Update()
    {
        // int randEnemy = Random.Range(0,enemies.Length);
        // int ranSpwanPoint = Random.Range
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}