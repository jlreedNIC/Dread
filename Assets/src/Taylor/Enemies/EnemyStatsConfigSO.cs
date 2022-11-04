/// <summary>
/// Taylor Martin
/// 513 Studios
/// Project D.R.E.A.D.
/// University of Idaho
/// Created: September 2022
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

    //attack stat variables

    //rate of the enemy attacks
    [field: SerializeField] public float attackRate;
    //holds the attack range of the enemy
    [field: SerializeField] public float attackRange; 
    //holds the force produced by the attack. Unused??
    [field: SerializeField] public float attackForce; 
    //holds how much damage the enemy can do
    [field: SerializeField] public int attackDamage; 
    //holds the amount of time elapsed while attacking
    [field: SerializeField] public float attackCooldown;

    //searching stats

    //holds the the length of time the enemy will search for
    [field: SerializeField] public float searchDuration;
    //holds the the rate of time the enemy will turn while searching
    [field: SerializeField] public float searchingTurnSpeed; 

    //state stats
    //holds the amount of time elapsed while in a state
    [field: SerializeField] public float stateTimeElapsed;

}