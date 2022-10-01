/// <summary>
/// Taylor Martin
/// 513 Studios
/// Project D.R.E.A.D.
/// University of Idaho
/// Created: June 21 2022
/// FILE: BaseEnemyAIStateMachine.cs
/// BaseEnemyAIStateMachine
/// This State Machine will be used for the Base Enemy type. 
/// This state machine has the base 5 states
/// Patrol, Chase, Attack, Search, and Flee. 
/// The enemy type will in default patrol around the map within its givin patrol radius.
/// Once the player ship is seen, the enemy will chase the player ship.
/// once targeted and in attack range, the enemy will fire missles at the player ship.
/// If the player ship is lost, the enemy will rotate and search for the player ship. 
/// If the player is not found, go back to patrolling. 
/// If the enemy ship health is low, Flee. 
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//needed for navMesh and unity AI
using UnityEngine.AI;  
//needed for A* pathfinding package
using Pathfinding;

public class EnemyAIStateMachine : MonoBehaviour
{

    //enumeration to hold our enemy AI states
    public enum EnemyAIStates
    {
        Patrol,
        Chase,
        Attack,
        Search
    }

    protected EnemyAIStates _currentState;
    
    //references Enemy Stats SO. Holds _enemyStats. 
    [SerializeField] protected EnemyStatsConfigSO _enemyStats; 
    
    //The origin point of our enemy spawn
    public Vector3  OriginPoint; 
    
    //the next random waypoint generated that the enemy will move too. 
    public Vector3 nextRandomWaypoint;    
    
    //the target we want the enemy AI focus on. 
    public Transform target; 
    
    //square of the maxspeed
    [SerializeField] protected float _maxSpeedSqr; 
    
    //rigid body component for movement. 
    protected Rigidbody _selfRB; 

    //Reference to A* pathfinding package AIDestinationSetter script. 
    //used for turning script componenet on and off
    public AIDestinationSetter aiDestinationSetter; 

    //Reference to EnemyPatrolAI script. 
    //used for randompoint patrolling 
    public EnemyPatrolAI enemyPatrolAI; 

    public Transform enemyEyes; 

    // [SerializeField] AudioSource _audioSource;
    // [SerializeField] AudioClipSO _audioClipSO;

    // Start is called before the first frame update
    void Start()
    {
        //gets the rigid body component from game object
        _selfRB = GetComponent<Rigidbody>();
        
        // stores the square of enemy move speed
        _maxSpeedSqr = _enemyStats.moveSpeed * _enemyStats.moveSpeed;
        
        //stores the origin point of enemy game object
        OriginPoint = transform.position; 
        
        //sets the current state to the base state of patrolling 
        SetAIState(EnemyAIStates.Patrol);
        

        //starts the check distance co routine to make sure the point 
        //generate is within the enemy stats distanceToWaypoint. 
        // StartCoroutine(checkDistance(0.2f));
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        //calls AIStateMachine function to handle 
        //and transition between states. 
        AIStateMachine();
    }

    //AI State Machine Function 
    //uses a switch statement
    //and switches between states based on our state data type
    //Patrol
    //Chase
    //Search
    //Attack
    //Flee
    protected virtual void AIStateMachine()
    {
        switch(_currentState)
        {
            //Enemy Patrol State. 
            // Base enemy state. 
            // Patrol random points within enemy patrolRadius
            case EnemyAIStates.Patrol:
                                    {

                                        //enables EnemyPatrolAI script. For random point patrolling. 
                                        //disables aiDestinationSetter script. There is no destination set.
                                        //patrols random points
                                        ChangeObjectComponents(true, false); 

                                        //call state machine patrol function. 
                                        Patrol(); 
                                    }
                                    break; 
            //Enemy Search State. 
            // Switches when player target is seen and 
            // then leaves the look range of the enemy. 
            case EnemyAIStates.Search:
                                    {
                                        //print searching string to console
                                        //for debugging 
                                        // Debug.Log("Light Enemy Searching"); 
                                        //call enemy state machine search function. 
                                        //rotates enemy and searches for the player target. 
                                        //for a set time duration. 
                                        Search(); 
                                    }
                                    break; 
            //Enemy Chase State. 
            //Switches when player target is seen 
            //and is in the enemy look range. 
            case EnemyAIStates.Chase:
                                    {

                                        //disables EnemyPatrolAI script. Stops patrolling random points. 
                                        //enables aiDestinationSetter script. There is a destination set. chase destination.
                                        ChangeObjectComponents(false, true); 

                                        //call State Machine Chase function
                                        //to chase the player target. 
                                        Chase();
                                    }
                                    break; 
            //Enemy Attack State. 
            //Switches when player target is seen 
            //and with enemy attackRange
            case EnemyAIStates.Attack:
                                    {
                                        //print attacking string to console
                                        //for debugging 
                                        // Debug.Log("Light Enemy Attacking"); 
                                        //call State Machine Attack function
                                        //to Attack the player target. 
                                        Attack();
                                    }
                                    break; 
        }
    }

    //Patrol State Function
    protected virtual void Patrol() 
    {

    }

    //Chase State Function
    protected virtual void Chase() 
    {

    }

    //Attack State Function
    protected virtual void Attack() 
    {

    }

    //Search State Function
    protected virtual void Search() 
    {

    }

    public bool Look()
    {
        RaycastHit hit;

        Debug.DrawRay(enemyEyes.position, enemyEyes.forward.normalized * _enemyStats.lookRange, Color.green);

        if(Physics.SphereCast(enemyEyes.position,_enemyStats.lookSphereCastRadius, enemyEyes.forward, out hit, _enemyStats.lookRange)
            && hit.collider.CompareTag("Player"))
        {
            target = hit.transform;
            return true;
        }
        else
        {
            return false;
        }
    }

    //Change Object Components Function
    //takes 2 parameters
    //bool isEnemyComponentOn
    //bool isNavigatorComponentOn
    //true will turn on the component
    //false will turn off the component
    public void ChangeObjectComponents(bool isEnemyComponentOn, bool isNavigatorComponentOn)
    {
        //sets enemyPatrolAI.enabled to true or false depending on what is sent in 
        enemyPatrolAI.enabled = isEnemyComponentOn; 

        //sets aiDestinationSetter.enabled to true or false depending on what is sent in 
        aiDestinationSetter.enabled = isNavigatorComponentOn;
    }

    //SetAIState() function
    //sets the enemy AI state
    //sets enemy Navigator AI state
    //resets state time elapsed
    public void SetAIState(EnemyAIStates currentAIState)
    {
        //update the enemy AI state
        _currentState = currentAIState;
        //reset elapsed state time 
        _enemyStats.stateTimeElapsed = 0;
    }

    private void OnDrawGizmos()
    {
        if (_currentState != null && enemyEyes != null)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawWireSphere(enemyEyes.position, _enemyStats.lookSphereCastRadius);
        }
    }
}


//pluggalbe AI look example:

// private bool Look(StateController controller)
// {
//     RaycastHit hit;

//     Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStates.lookRange, Color.green);

//     if(Physics.SphereCast(controller.eyes.position, controller.enemyStates.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStates.lookRange)
//         && hit.collider.CompareTag("Player"))
//     {
//         controller.chaseTarget = hit.transform;
//         return true;
//     }
//     else
//     {
//         return false;
//     }
// }