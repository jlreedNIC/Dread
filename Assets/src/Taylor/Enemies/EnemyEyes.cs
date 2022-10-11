using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyes : MonoBehaviour
{

    [SerializeField] public bool isPlayerInArea {get; private set;}

    public Transform target {get; private set;}

    [SerializeField] private string detectionTag = "Player"; 

    [SerializeField] private CircleCollider2D colliders; 

    [SerializeField] private EnemyStatsConfigSO _enemyStats; 

    public void Start()
    {
        colliders = GetComponent<CircleCollider2D>();

        colliders.radius = _enemyStats.lookSphereCastRadius; 
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(detectionTag))
        {
            isPlayerInArea = true; 
            target = other.gameObject.transform; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(detectionTag))
        {
            isPlayerInArea = false;
            target = null; 
        }
    }

    private void OnDrawGizmos()
    {
        if (target == null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _enemyStats.lookSphereCastRadius);
        }
        if(target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _enemyStats.lookSphereCastRadius);
        }
    }
}
