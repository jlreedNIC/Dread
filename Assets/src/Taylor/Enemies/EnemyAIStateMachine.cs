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
using UnityEditor;
//needed for navMesh and unity AI
using UnityEngine.AI;  
//needed for A* pathfinding package
using Pathfinding;

public abstract class EnemyAIStateMachine : MonoBehaviour
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
    
    //the target we want the enemy AI focus on. 
    [SerializeField] public Transform target; 
    
    //rigid body component for movement. 
    protected Rigidbody _selfRB; 

    //Reference to A* pathfinding package AIDestinationSetter script. 
    //used for turning script componenet on and off
    [SerializeField] public AIDestinationSetter aiDestinationSetter; 
    [SerializeField] public AIPath aiPath; 


    //Reference to EnemyPatrolAI script. 
    //used for randompoint patrolling 
    [SerializeField] public EnemyPatrolAI enemyPatrolAI; 

    [SerializeField] public EnemyEyes enemyEyes; 

    [SerializeField] public Base_Weapon weaponSpawner;
     

    // [SerializeField] AudioSource _audioSource;
    // [SerializeField] AudioClipSO _audioClipSO;

    // Start is called before the first frame update
    public virtual void OnEnable()
    {
        //gets the rigid body component from game object
        _selfRB = GetComponent<Rigidbody>();

        aiPath = GetComponent<AIPath>();
        
        //sets the current state to the base state of patrolling 
        SetAIState(EnemyAIStates.Patrol);
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
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
                                        
                                        ChangeObjectComponents(false, false); 
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

                                        //disables EnemyPatrolAI script. Stops patrolling random points. 
                                        //enables aiDestinationSetter script. There is a destination set. chase destination.
                                        ChangeObjectComponents(false, true); 

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
        if(enemyEyes.target != null)
        {
            target = enemyEyes.target;
            aiDestinationSetter.target = target;
            // rotateTowardsTarget(target.position); 
            SetAIState(EnemyAIStates.Chase); 
        }
    }

    //Chase State Function
    protected virtual void Chase() 
    {
        if(enemyEyes.target == null)
        {
            target = null;
            aiDestinationSetter.target = target;
            // SetAIState(EnemyAIStates.Patrol);
            SetAIState(EnemyAIStates.Search);
        }
        if(target != null)
        {
            if(Vector2.Distance(transform.position, target.transform.position) < _enemyStats.attackRange)
            {   
                //changes the state of the enemy to the attack state
                SetAIState(EnemyAIStates.Attack);
            }
        }
    }

    //Attack State Function
    protected virtual void Attack() 
    {
        if(enemyEyes.target == null)
        {
            target = null;
            aiDestinationSetter.target = target;
            // SetAIState(EnemyAIStates.Patrol);
            SetAIState(EnemyAIStates.Search);
        }

        if(target != null)
        {
            target = enemyEyes.target;
            aiDestinationSetter.target = target;
            // rotateTowardsTarget(target.position); 

            if(Vector2.Distance(transform.position, target.transform.position) < _enemyStats.attackRange)
            {
                if(CheckIfCoolDownElapsed(_enemyStats.attackRate))
                {

                    //prints string to console. for debugging. 
                    Debug.Log("Enemy Ranged Attacking");
                    rotateTowardsTarget(target.position); 
                    //calls on our weapon spawner class method fire
                    //launches a missle prefab from 
                    //the weapon spawner prefab on the enemy game object
                    weaponSpawner.Fire(); 
                    _enemyStats.attackCooldown = 0;
                }
            }
            else
            {
                target = enemyEyes.target;
                aiDestinationSetter.target = target;
                // SetAIState(EnemyAIStates.Patrol);
                SetAIState(EnemyAIStates.Chase);
            }
        }
    }

    //Search State Function
    protected virtual void Search() 
    {
        if(!CheckIfCountDownElapsed(_enemyStats.searchDuration))
        {
            Debug.Log("Enemy Searching");
            aiPath.canMove = false; 
            // Spin the object around the target at 20 degrees/second.
            transform.RotateAround(transform.position, Vector3.forward, _enemyStats.searchingTurnSpeed);
        }
        else
        {
            if(enemyEyes.target != null)
            {
                target = enemyEyes.target;
                aiDestinationSetter.target = target;
                aiPath.canMove = true; 
                SetAIState(EnemyAIStates.Chase); 
            }
            else
            {
                aiPath.canMove = true; 
                SetAIState(EnemyAIStates.Patrol); 
            }

        }
    }

    public void rotateTowardsTarget(Vector3 pointToLookAt)
    {
        Vector3 current = transform.up;
        Vector3 targetDirection = pointToLookAt - transform.position;
        transform.up = Vector3.RotateTowards(current, targetDirection, 360, _enemyStats.rotationSpeed * Time.deltaTime);
    }

    //Change Object Components Function
    //takes 2 parameters
    //bool isEnemyPatrolComponentOn
    //bool isAiDestinationSetterOn
    //true will turn on the component
    //false will turn off the component
    public void ChangeObjectComponents(bool isEnemyPatrolComponentOn, bool isAiDestinationSetterOn)
    {
        //sets enemyPatrolAI.enabled to true or false depending on what is sent in 
        enemyPatrolAI.enabled = isEnemyPatrolComponentOn; 

        //sets aiDestinationSetter.enabled to true or false depending on what is sent in 
        aiDestinationSetter.enabled = isAiDestinationSetterOn;
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

    //checks if attack duration exceeded
    public bool CheckIfCoolDownElapsed(float duration)
	{
		_enemyStats.attackCooldown += Time.deltaTime;
		return _enemyStats.attackCooldown >= duration;
	}
    
    //checks if search duration exceeded
    public bool CheckIfCountDownElapsed(float duration)
	{
		_enemyStats.stateTimeElapsed += Time.deltaTime;
		return _enemyStats.stateTimeElapsed >= duration;
	}

    public void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _enemyStats.patrolRadius);

    }
}