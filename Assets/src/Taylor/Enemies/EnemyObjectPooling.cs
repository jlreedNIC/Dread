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
        internal static readonly EnemyObjectPooling instance = new EnemyObjectPooling();
    }

    [SerializeField] public int _defaultPoolSize = 10;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<GameObject> _enemyPool = new List<GameObject>();

    //[SerializeField] EnemyPrefabSpawner spawner;

    //[SerializeField] private List<GameObject> _enemyTypes = new List<GameObject>();


    void Start()
    {
        //spawner.enabled = false;
        //GenerateEnemies(_defaultPoolSize);
    }

    public List<GameObject> GenerateEnemies(int amount, GameObject enemyPrefab)
    {
        Debug.Log("In GeneratingEnemies"); 
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);

            Debug.Log(enemy.name + (i+1) + " Was instantiated"); 
            //enemy.transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
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
        // for(int i = 0; i < _enemyPool.Count; i++)
        // {
        //     Debug.Log("In RequestEnemy for loop"); 
        //     if (_enemyPool[i].activeInHierarchy == false)
        //     {
        //         Debug.Log("In RequestEnemy for loop if block"); 
        //         _enemyPool[i].SetActive(true);
        //         Debug.Log(_enemyPool[i].name + " Was set active"); 
        //         return _enemyPool[i];
        //     }
        // }

        // GameObject newEnemy = Instantiate(_enemyPrefab);
        // _enemyPool.Add(newEnemy);

        // return newEnemy;
        return null;
    }

    public void DespawnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        Debug.Log(enemy.name + " Was Destroyed");
    }
}

// In your GameManager or SpawnManager or wherever else you would normally be instantiating your enemy prefab, you’ll replace that instantiation call with the following:
// GameObject enemy = PoolManager.Instance.RequestEnemy();
// enemy.transform.position = new Vector3(_xPos, _yPos, 0);


// To use DespawnEnemy, in the Enemy script we go to wherever we would normally be destroying the instance and replace that destruction with the following line:
// PoolManager.Instance.DespawnEnemy(gameObject);

// using UnityEngine;
// using UnityEngine.Pool;
// public class SpawnUsingPool : MonoBehaviour
// {
//     public GameObject objectPrefab;
//     ObjectPool<GameObject> objectPool;
//     void Awake()
//     {
//         objectPool = new ObjectPool<GameObject>(OnObjectCreate, OnTake, OnRelease, OnObjectDestroy);
//     }
//     GameObject OnObjectCreate()
//     {
//         GameObject newObject = Instantiate(objectPrefab);
//         newObject.AddComponent<PoolObject>().myPool = objectPool;
//         return newObject;
//     }
//     void OnTake(GameObject poolObject)
//     {
//         poolObject.SetActive(true);
//     }
//     void OnRelease(GameObject poolObject)
//     {
//         poolObject.SetActive(false);
//     }
//     void OnObjectDestroy(GameObject poolObject)
//     {
//         Destroy(poolObject);
//     }
// }