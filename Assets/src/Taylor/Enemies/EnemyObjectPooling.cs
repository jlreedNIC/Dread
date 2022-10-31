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

    [SerializeField] private int _defaultPoolSize = 10;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<GameObject> _enemyPool = new List<GameObject>();

    //[SerializeField] private List<GameObject> _enemyTypes = new List<GameObject>();


    void Start()
    {
        GenerateEnemies(_defaultPoolSize);
    }

    List<GameObject> GenerateEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab);
            enemy.SetActive(false);

            _enemyPool.Add(enemy);
        }

        return _enemyPool;
    }

    public GameObject RequestEnemy()
    {
        foreach (GameObject enemy in _enemyPool)
        {
            if (enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(_enemyPrefab);
        _enemyPool.Add(newEnemy);

        return newEnemy;
    }

    public void DespawnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}

// In your GameManager or SpawnManager or wherever else you would normally be instantiating your enemy prefab, you’ll replace that instantiation call with the following:
// GameObject enemy = PoolManager.Instance.RequestEnemy();
// enemy.transform.position = new Vector3(_xPos, _yPos, 0);


// To use DespawnEnemy, in the Enemy script we go to wherever we would normally be destroying the instance and replace that destruction with the following line:
// PoolManager.Instance.DespawnEnemy(gameObject);
