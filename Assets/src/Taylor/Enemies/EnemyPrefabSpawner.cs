using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabSpwaner : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemies; 

    [SerializeField] public List<Transform> spawnPoints; 

    [SerializeField] public float baseEnemySpawnRate = 3.5; 


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(baseEnemySpawnRate, swarmerPrefab));
    }
    public void Update()
    {
        int randEnemy = Random.Range(0,enemies.Length);
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}