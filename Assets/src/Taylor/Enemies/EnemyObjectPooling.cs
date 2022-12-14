using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyObjectPooling : MonoBehaviour
{

    private EnemyObjectPooling() {}

    public static EnemyObjectPooling Instance
    {
        get
        {
            return Nested.instance;
        }
    }

    private class Nested
    {
        static Nested() {}

        internal static readonly EnemyObjectPooling instance = new GameObject("EnemyObjectPoolManager").AddComponent<EnemyObjectPooling>();
    }
    [SerializeField] public int _defaultPoolSize = 10;

    [SerializeField] public List<GameObject> _enemyPool = new List<GameObject>();
    

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public List<GameObject> GenerateEnemies(int amount, List <GameObject> enemyPrefabs)
    {
        //clear the list when first level reloads again from start menu scene
        Debug.Log("Clearing enemyPool"); 
        _enemyPool.Clear();

        Debug.Log("In GeneratingEnemies"); 
        for (int i = 0; i < amount; i++)
        {
            int randNum = Random.Range(0,enemyPrefabs.Count);
            GameObject enemy = Instantiate(enemyPrefabs[randNum]);

            Debug.Log(enemy.name + (i+1) + " Was instantiated"); 

            enemy.SetActive(false);

            _enemyPool.Add(enemy);
            Debug.Log(enemy.name + (i+1) + " Was added to pool"); 
        }
        
        Debug.Log(" Current Enemy Pool Size: " + _enemyPool.Count); 

        //spawner.enabled = true;
        return _enemyPool;
    }

    public GameObject RequestEnemy()
    {
        Debug.Log("In RequestEnemy"); 

        foreach(GameObject enemy in _enemyPool)
        {
            Debug.Log("In RequestEnemy for loop"); 
            if (enemy.activeInHierarchy == false)
            {
                Debug.Log("In RequestEnemy for loop if block"); 
                enemy.SetActive(true);
                Debug.Log(enemy.name + " Was set active"); 
                return enemy;
            }
        }
        Debug.Log("No More Enemies To Spawn, Exiting RequestEnemy()"); 

        return null;
    }

    public void DespawnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        Debug.Log(enemy.name + " Was Destroyed");
    }
}

// In your GameManager or SpawnManager or wherever else you would normally be instantiating your enemy prefab, you???ll replace that instantiation call with the following:
// GameObject enemy = PoolManager.Instance.RequestEnemy();
// enemy.transform.position = new Vector3(_xPos, _yPos, 0);


// To use DespawnEnemy, in the Enemy script we go to wherever we would normally be destroying the instance and replace that destruction with the following line:
// PoolManager.Instance.DespawnEnemy(gameObject);