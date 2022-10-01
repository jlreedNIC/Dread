/// <summary>
/// Taylor Martin
/// University of Idaho
/// 513 Studios
/// Project D.R.E.A.D.
/// Created: 9/29/22
/// Last Updated: 9/29/22
/// FILE: EnemyPatrolAI.cs
/// EnemyPatrolAI 
/// Generates random points within enemy patrolRadius
/// Uses A* pathfinding to generate and traverse paths
/// between random points
/// Used by the Enemy State Machine to follow around the map
/// </summary>

using UnityEngine; 
using Pathfinding; 
using System.Collections;
using System.Collections.Generic;


public class EnemyPatrolAI : MonoBehaviour
{

    //A* pathfinding package IAstarAI GameObject
    IAstarAI ai; 

    //origin point of the enemy navigator
    public Vector3 OriginPoint; 

    //enemy stats SO reference. 
    //needed for patrolRadius
    public EnemyStatsConfigSO enemyStats; 

    //Start() function
    //called when the enemy navigator game object is spawned
    public void Start()
    {
        // get the ai component from unity
        ai = GetComponent<IAstarAI>(); 

        //get origin point of enemy navigator
        OriginPoint = transform.position; 
    }


    // PickRandomPoint()
    //generates a random point for the enemy navigator. 
    Vector3 PickRandomPoint() 
    {
        //generates a random point within the set patrolRadius in enemy stats
        //insideUnitSphere has a radius of 1. 
        var point = Random.insideUnitSphere * enemyStats.patrolRadius;

        //sets the y axis point to 0. for just movement in the x and z axis
        point.z = 0;

        //adds the generated point to the OriginPoint. Stroring new value in point. 
        point += OriginPoint;

        // point += ai.position;
        return point;
    }


    //update(). 
    //called every frame 
    void Update()
    {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if(!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath))
        {
            //calls PickRandomPoint() to generate a random point. 
            //sets the AI destination to the generated point.
            ai.destination = PickRandomPoint(); 

            //prints destination point to the console.
            //used for debugging. 
            // Debug.Log(ai.destination.ToString()); 

            //generates a path to the generated point. 
            //Then traverses the generated path. 
            ai.SearchPath(); 
        }
    }

}