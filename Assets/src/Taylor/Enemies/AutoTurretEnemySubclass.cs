using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AutoTurretEnemySubclass : EnemyAIStateMachine
{
    // Start is called before the first frame update
    public override void OnEnable()
    {
        //gets the rigid body component from game object
        _selfRB = GetComponent<Rigidbody>();

        aiPath = GetComponent<AIPath>();

        // aiPath.isStopped = true; 
        
        //sets the current state to the base state of patrolling 
        SetAIState(EnemyAIStates.Search);
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        //calls AIStateMachine function to handle 
        //and transition between states. 
        AIStateMachine();
    }


    //AI State Machine Function 
    //uses a switch statement
    //and switches between states based on our state data type
    //Search
    //Attack
    protected override void AIStateMachine()
    {
        switch(_currentState)
        {
            //Enemy Search State. 
            // Switches when player target is seen and 
            // then leaves the look range of the enemy. 
            case EnemyAIStates.Search:
                                    {
                                        ChangeObjectComponents(false,false); 
                                        //print searching string to console
                                        //for debugging 
                                        // Debug.Log("Light Enemy Searching"); 
                                        //call enemy state machine search function. 
                                        //rotates enemy and searches for the player target. 
                                        //for a set time duration. 
                                        Search();
                                    }
                                    break; 
            //Enemy Attack State. 
            //Switches when player target is seen 
            //and with enemy attackRange
            case EnemyAIStates.Attack:
                                    {
                                        ChangeObjectComponents(false,true); 
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

    //Attack State Function
    protected override void Attack() 
    {
        if(enemyEyes.target == null)
        {
            target = null;
            aiDestinationSetter.target = target;
            SetAIState(EnemyAIStates.Search);
        }

        if(target != null)
        {
            target = enemyEyes.target;
            aiDestinationSetter.target = target;
            rotateTowardsTarget(target.position); 

            if(Vector2.Distance(transform.position, target.transform.position) < _enemyStats.attackRange)
            {
                if(CheckIfCoolDownElapsed(_enemyStats.attackRate))
                {

                    //prints string to console. for debugging. 
                    Debug.Log("Enemy Ranged Attacking");
                    
                    //calls on our weapon spawner class method fire
                    //launches a missle prefab from 
                    //the weapon spawner prefab on the enemy game object
                    weaponSpawner.Fire(); 
                    _enemyStats.attackCooldown = 0;
                }
            }
        }
    }

    //Search State Function
    protected override void Search() 
    {

        if(enemyEyes.target != null)
        {
            target = enemyEyes.target;
            aiDestinationSetter.target = target;
            aiPath.isStopped = true;  
            SetAIState(EnemyAIStates.Attack); 
        }
        if(!CheckIfCountDownElapsed(_enemyStats.searchDuration))
        {
            Debug.Log("Enemy Searching");
            // aiPath.isStopped = true;  
            // Spin the object around the target at 20 degrees/second.
            transform.RotateAround(transform.position, Vector3.forward, _enemyStats.searchingTurnSpeed);

            if(enemyEyes.target != null)
            {
                target = enemyEyes.target;
                aiDestinationSetter.target = target;
                // aiPath.isStopped = true;  
                SetAIState(EnemyAIStates.Attack); 
            }
        }
        else
        {
            SetAIState(EnemyAIStates.Search);
        } 
    }
}