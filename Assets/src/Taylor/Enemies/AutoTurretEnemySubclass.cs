using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurretEnemySubclass : EnemyAIStateMachine
{
    // Start is called before the first frame update
    // public override void OnEnable()
    // {
    //     //gets the rigid body component from game object
    //     _selfRB = GetComponent<Rigidbody>();

    //     aiPath = GetComponent<AIPath>();
        
    //     //sets the current state to the base state of patrolling 
    //     SetAIState(EnemyAIStates.Patrol);
    // }


    //AI State Machine Function 
    //uses a switch statement
    //and switches between states based on our state data type
    //Patrol
    //Chase
    //Search
    //Attack
    //Flee
    // protected override void AIStateMachine()
    // {
    //     switch(_currentState)
    //     {
    //         //Enemy Search State. 
    //         // Switches when player target is seen and 
    //         // then leaves the look range of the enemy. 
    //         case EnemyAIStates.Search:
    //                                 {
    //                                     //print searching string to console
    //                                     //for debugging 
    //                                     // Debug.Log("Light Enemy Searching"); 
    //                                     //call enemy state machine search function. 
    //                                     //rotates enemy and searches for the player target. 
    //                                     //for a set time duration. 
    //                                     Search();
    //                                 }
    //                                 break; 
    //         //Enemy Attack State. 
    //         //Switches when player target is seen 
    //         //and with enemy attackRange
    //         case EnemyAIStates.Attack:
    //                                 {
    //                                     //print attacking string to console
    //                                     //for debugging 
    //                                     // Debug.Log("Light Enemy Attacking"); 
    //                                     //call State Machine Attack function
    //                                     //to Attack the player target. 
    //                                     Attack();
    //                                 }
    //                                 break; 
    //     }
    // }

       // //Attack State Function
    // protected override void Attack() 
    // {
    //     if(enemyEyes.target == null)
    //     {
    //         target = null;
    //         aiDestinationSetter.target = target;
    //         SetAIState(EnemyAIStates.Search);
    //     }

    //     if(target != null)
    //     {
    //         if(Vector2.Distance(transform.position, target.transform.position) < _enemyStats.attackRange)
    //         {
    //             if(CheckIfCoolDownElapsed(_enemyStats.attackRate))
    //             {
    //                 target = enemyEyes.target;
    //                 aiDestinationSetter.target = target;

    //                 //prints string to console. for debugging. 
    //                 Debug.Log("Enemy Ranged Attacking");
                    
    //                 //calls on our weapon spawner class method fire
    //                 //launches a missle prefab from 
    //                 //the weapon spawner prefab on the enemy game object
    //                 weaponSpawner.Fire(); 
    //                 _enemyStats.attackCooldown = 0;
    //             }
    //         }
    //         else
    //         {
    //             target = enemyEyes.target;
    //             aiDestinationSetter.target = target;
    //             // SetAIState(EnemyAIStates.Patrol);
    //             SetAIState(EnemyAIStates.Chase);
    //         }
    //     }
    // }

    // //Search State Function
    // protected override void Search() 
    // {
    //     if(!CheckIfCountDownElapsed(_enemyStats.searchDuration))
    //     {
    //         Debug.Log("Enemy Searching");
    //         aiPath.canMove = false; 
    //         // Spin the object around the target at 20 degrees/second.
    //         transform.RotateAround(transform.position, Vector3.forward, _enemyStats.searchingTurnSpeed);
    //     }
    //     else
    //     {
    //         if(enemyEyes.target != null)
    //         {
    //             target = enemyEyes.target;
    //             aiDestinationSetter.target = target;
    //             aiPath.canMove = true; 
    //             SetAIState(EnemyAIStates.Chase); 
    //         }
    //         else
    //         {
    //             aiPath.canMove = true; 
    //             SetAIState(EnemyAIStates.Patrol); 
    //         }

    //     }
    // }
}

    // Start is called before the first frame update
    // void OnEnable()
    // {
    //     //gets the rigid body component from game object
    //     _selfRB = GetComponent<Rigidbody>();

    //     aiPath = GetComponent<AIPath>();
        
    //     //sets the current state to the base state of patrolling 
    //     SetAIState(EnemyAIStates.Patrol);
    // }
    //AI State Machine Function 
    //uses a switch statement
    //and switches between states based on our state data type
    //Patrol
    //Chase
    //Search
    //Attack
    //Flee
    // protected virtual void AIStateMachine()
    // {
    //     switch(_currentState)
    //     {
    //         //Enemy Patrol State. 
    //         // Base enemy state. 
    //         // Patrol random points within enemy patrolRadius
    //         case EnemyAIStates.Patrol:
    //                                 {

    //                                     //enables EnemyPatrolAI script. For random point patrolling. 
    //                                     //disables aiDestinationSetter script. There is no destination set.
    //                                     //patrols random points
    //                                     ChangeObjectComponents(true, false); 

    //                                     //call state machine patrol function. 
    //                                     Patrol(); 
    //                                 }
    //                                 break; 
    //         //Enemy Search State. 
    //         // Switches when player target is seen and 
    //         // then leaves the look range of the enemy. 
    //         case EnemyAIStates.Search:
    //                                 {
                                        
    //                                     ChangeObjectComponents(false, false); 
    //                                     //print searching string to console
    //                                     //for debugging 
    //                                     // Debug.Log("Light Enemy Searching"); 
    //                                     //call enemy state machine search function. 
    //                                     //rotates enemy and searches for the player target. 
    //                                     //for a set time duration. 
    //                                     Search();
    //                                 }
    //                                 break; 
    //         //Enemy Chase State. 
    //         //Switches when player target is seen 
    //         //and is in the enemy look range. 
    //         case EnemyAIStates.Chase:
    //                                 {

    //                                     //disables EnemyPatrolAI script. Stops patrolling random points. 
    //                                     //enables aiDestinationSetter script. There is a destination set. chase destination.
    //                                     ChangeObjectComponents(false, true); 

    //                                     //call State Machine Chase function
    //                                     //to chase the player target. 
    //                                     Chase();
    //                                 }
    //                                 break; 
    //         //Enemy Attack State. 
    //         //Switches when player target is seen 
    //         //and with enemy attackRange
    //         case EnemyAIStates.Attack:
    //                                 {

    //                                     //disables EnemyPatrolAI script. Stops patrolling random points. 
    //                                     //enables aiDestinationSetter script. There is a destination set. chase destination.
    //                                     ChangeObjectComponents(false, true); 

    //                                     //print attacking string to console
    //                                     //for debugging 
    //                                     // Debug.Log("Light Enemy Attacking"); 
    //                                     //call State Machine Attack function
    //                                     //to Attack the player target. 
    //                                     Attack();
    //                                 }
    //                                 break; 
    //     }
    // }


    // //Attack State Function
    // protected virtual void Attack() 
    // {
    //     if(enemyEyes.target == null)
    //     {
    //         target = null;
    //         aiDestinationSetter.target = target;
    //         // SetAIState(EnemyAIStates.Patrol);
    //         SetAIState(EnemyAIStates.Search);
    //     }

    //     if(target != null)
    //     {
    //         if(Vector2.Distance(transform.position, target.transform.position) < _enemyStats.attackRange)
    //         {
    //             if(CheckIfCoolDownElapsed(_enemyStats.attackRate))
    //             {
    //                 target = enemyEyes.target;
    //                 aiDestinationSetter.target = target;

    //                 //prints string to console. for debugging. 
    //                 Debug.Log("Enemy Ranged Attacking");
                    
    //                 //calls on our weapon spawner class method fire
    //                 //launches a missle prefab from 
    //                 //the weapon spawner prefab on the enemy game object
    //                 weaponSpawner.Fire(); 
    //                 _enemyStats.attackCooldown = 0;
    //             }
    //         }
    //         else
    //         {
    //             target = enemyEyes.target;
    //             aiDestinationSetter.target = target;
    //             // SetAIState(EnemyAIStates.Patrol);
    //             SetAIState(EnemyAIStates.Chase);
    //         }
    //     }
    // }

    // //Search State Function
    // protected virtual void Search() 
    // {
    //     if(!CheckIfCountDownElapsed(_enemyStats.searchDuration))
    //     {
    //         Debug.Log("Enemy Searching");
    //         aiPath.canMove = false; 
    //         // Spin the object around the target at 20 degrees/second.
    //         transform.RotateAround(transform.position, Vector3.forward, _enemyStats.searchingTurnSpeed);
    //     }
    //     else
    //     {
    //         if(enemyEyes.target != null)
    //         {
    //             target = enemyEyes.target;
    //             aiDestinationSetter.target = target;
    //             aiPath.canMove = true; 
    //             SetAIState(EnemyAIStates.Chase); 
    //         }
    //         else
    //         {
    //             aiPath.canMove = true; 
    //             SetAIState(EnemyAIStates.Patrol); 
    //         }

    //     }
    // }