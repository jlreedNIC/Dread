/// <summary>
/// Taylor Martin
/// 513 Studios
/// Project D.R.E.A.D.
/// University of Idaho
/// Created: June 21 2022
/// FILE: EnemyStatsConfigSO.cs
/// Scriptable object For storing the enemy stats
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/EnemyStats")]
public class EnemyStatsConfigSO : ScriptableObject
{
    //movement and looking around variables

    //variable to hold movement speed of enemy
    [field: SerializeField] public float moveSpeed; 
    //Rotation Speed of Enemy 
    [field: SerializeField] public float rotationSpeed; 
    //acceleration speed of enemy 
    [field: SerializeField] public float accelerationStep; 
    //distance to the waypoint
    [field: SerializeField] public float distanceToWaypoint;
    //variable holding how far the enemy will be able to look within the scene
    [field: SerializeField] public float lookRange; 
    //varialbe to hold the radius at which the enemy can detect a player within
    [field: SerializeField] public float lookSphereCastRadius; 
    //variable to hold the radius whithin which new random points can be generated for patrol movement
    [field: SerializeField] public float patrolRadius; 
    //variable to hold the force added to an enemy game object on the x-axis. For movement
    [field: SerializeField] public float XTiltModifier; 
    //variable to hold the force added to an enemy game object on the y-axis. For movement
    [field: SerializeField] public float YTiltModifier;
    // Holds point above navigator for enemy to patrol 
    [field: SerializeField] public Vector3 NavOffset;

    //attack stat variables

    //rate of the enemy attacks
    [field: SerializeField] public float attackRate;
    //holds the attack range of the enemy
    [field: SerializeField] public float attackRange; 
    //holds the force produced by the attack. Unused??
    [field: SerializeField] public float attackForce; 
    //holds how much damage the enemy can do
    [field: SerializeField] public int attackDamage; 

    //searching stats

    //holds the the length of time the enemy will search for
    [field: SerializeField] public float searchDuration;
    //holds the the rate of time the enemy will turn while searching
    [field: SerializeField] public float searchingTurnSpeed; 
}