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
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public abstract class BaseEnemyAIStateMachine : MonoBehaviour
// {
//     //enumeration to hold our enemy AI state
//     public enum EnemyAIStates
//     {
//         Patrol,
//         Chase,
//         Attack,
//         Search
//     }

//     protected EnemyAIStates _currentState;
//     //references Enemy Stats SO. Holds _enemyStats. 
//     [SerializeField] protected EnemyStatsConfigSO _enemyStats; 
//     //The origin point of our enemy spawn
//     public Vector3  OriginPoint; 
//     //the next random waypoint generated that the enemy will move too. 
//     public Vector3 nextRandomWaypoint;    
//     //the target we want the enemy AI focus on. 
//     public Transform target; 
//     //square of the maxspeed
//     [SerializeField] protected float _maxSpeedSqr; 
//     //rigid body component for movement. 
//     protected Rigidbody _selfRB; 
//     //holds the amount of time elapsed while in a state
//     [HideInInspector] public float stateTimeElapsed;
//     //holds the amount of time elapsed while attacking
//     [HideInInspector] public float attackCooldown;
//     //ram speed for ramming attack
//     [SerializeField] protected float ramSpeed; 
//     protected bool isRammingAttackEnabled = false; 

//     // [SerializeField] AudioSource _audioSource;
//     // [SerializeField] AudioClipSO _audioClipSO;

//     // Start is called before the first frame update
//     void Start()
//     {
//         //_audioSource = GetComponent<AudioSource>();
//         // _audioSource.clip = _audioClipSO.Clip;
//         // _audioSource.Play(); 

//         //gets the rigid body component from game object
//         _selfRB = GetComponent<Rigidbody>();
//         // stores the square of enemy move speed
//         _maxSpeedSqr = _enemyStats.moveSpeed * _enemyStats.moveSpeed;
//         //stores the origin point of enemy game object
//         OriginPoint = transform.position; 
//         //sets the current state to the base state of patrolling 
//         //sets the Enemy Navigator AI to the base state of patrolling
//         SetAIState(EnemyAIStates.Patrol, EnemyNavigatorAI.navMeshStates.Patrol);
//         //gets the damageable component off the game object. for enemy health and taking damage. 
//         _enemyHealth = GetComponent<Damageable>();
//         //starts the check distance co routine to make sure the point 
//         //generate is within the enemy stats distanceToWaypoint. 
//         StartCoroutine(checkDistance(0.2f));
//     }

//     // Update is called once per frame
//     void FixedUpdate()
//     {
//         //calls AIStateMachine function to handle 
//         //and transition between states. 
//         AIStateMachine(); 

//         //makes the scout ship stay upright 
//         _selfRB.AddTorque(Vector3.Cross(transform.up, Vector3.up)*(_enemyStats.rotationSpeed * 5)); 
//     }

//     //AI State Machine Function 
//     //uses a switch statement
//     //and switches between states based on our state data type
//     //Patrol
//     //Chase
//     //Search
//     //Attack
//     //Flee
//     public void AIStateMachine()
//     {
//         switch(_currentState)
//         {
//             //Enemy Patrol State. 
//             // Base enemy state. 
//             // Patrol random points within enemy patrolRadius
//             case EnemyAIStates.Patrol:
//                                     {
//                                         //print patrolling string to console
//                                         //for debugging 
//                                         // Debug.Log("Light Enemy Patrolling"); 

//                                         //call state machine patrol function. 
//                                         Patrol(target, _enemyStats.NavOffset); 
//                                     }
//                                     break; 
//             //Enemy Search State. 
//             // Switches when player target is seen and 
//             // then leaves the look range of the enemy. 
//             case EnemyAIStates.Search:
//                                     {
//                                         //print searching string to console
//                                         //for debugging 
//                                         // Debug.Log("Light Enemy Searching"); 
//                                         //call enemy state machine search function. 
//                                         //rotates enemy and searches for the player target. 
//                                         //for a set time duration. 
//                                         Search(); 
//                                     }
//                                     break; 
//             //Enemy Chase State. 
//             //Switches when player target is seen 
//             //and is in the enemy look range. 
//             case EnemyAIStates.Chase:
//                                     {

//                                         //print chasing string to console
//                                         //for debugging 
//                                         // Debug.Log("Light Enemy Chasing"); 
//                                         //call State Machine Chase function
//                                         //to chase the player target. 
//                                         Chase();
//                                     }
//                                     break; 
//             //Enemy Attack State. 
//             //Switches when player target is seen 
//             //and with enemy attackRange
//             case EnemyAIStates.Attack:
//                                     {
//                                         //print attacking string to console
//                                         //for debugging 
//                                         // Debug.Log("Light Enemy Attacking"); 
//                                         //call State Machine Attack function
//                                         //to Attack the player target. 
//                                         Attack();
//                                     }
//                                     break; 
//         }
//     }

//     // GetNextPosition Function
//     //creates a raycast to see if there is an obstacle in the way of the point.
//     //if an obstacle is hit, get a new position
//     //else, update the waypoint 
//     public void GetNextPosition()
//     {
//         //get a position that is above our enemy navigator ai. 
//         //so that the enemy floats in space. 
//         Vector3 nextPoint = target.position + _enemyStats.NavOffset;
        
//         //creates a raycast to see if there is an obstacle in the way of the point.
//         if(Physics.Raycast(transform.position, transform.TransformDirection(nextPoint), Vector3.Distance(transform.position, nextPoint)))
//         {
//             //if an obstacle is hit, get a new position
//             GetNextPosition();
//         }
//         else 
//         {
//             //else, update the next wapoint
//             nextRandomWaypoint = nextPoint; 
//         }
//     }

//     //rotateTowardTarget Function
//     //makes a game object rotate towards a sent in Vector3 position
//     private void rotateTowardTarget(Vector3 pointToLookAt)
//     {
//         //computes the direction of the target
//         Vector3 targetDirection = pointToLookAt - transform.position; 
//         //adds torque to move the game object
//         if(_groundCollider.ObstacleDetected)
//         {
//             // Debug.Log("Light Enemy: Obstacle in way");
//             _selfRB.AddTorque(Vector3.Cross(transform.forward, Vector3.up)*_enemyStats.rotationSpeed*20);
//             _selfRB.AddTorque(transform.up * _enemyStats.rotationSpeed*20); 
//         }
//         else
//         {
//             _selfRB.AddTorque(Vector3.Cross(transform.forward, targetDirection)*_enemyStats.rotationSpeed);
//         }
//     }

//     //checkDistance Coroutine Function
//     //checks if the enemy is with a distance. 
//     //for stopping or performing another action like traversing to another point. 
//     IEnumerator checkDistance(float delay)
//     {
//         while(true)
//         {
//             if(Vector3.Distance(transform.position, nextRandomWaypoint) < _enemyStats.distanceToWaypoint)
//             {
//                 GetNextPosition(); 
//             }

//             yield return new WaitForSeconds(delay);
//         }
//     }

//     //Patrol State Function
//     //makes the enemy patrol/orbit around the space
//     //above the enemy navigator
//     public void Patrol(Transform target, Vector3 offSet)
//     {
//         if(target != null)
//         {   
//             //do I need to fix nav off set of chase state??
//             //rotate toward the target
//             rotateTowardTarget(target.position + offSet);
            
//             //if the game objest magnitude is less that the square of teh max speed. 
//             if(_selfRB.velocity.sqrMagnitude < _maxSpeedSqr)
//             {
//                 //add acceleration force to the enemy game object. for movement. 
//                 _selfRB.AddForce(transform.forward * _enemyStats.accelerationStep, ForceMode.Acceleration);
//             }

//             // add torque to rotate in the x axis direction
//             _selfRB.AddTorque(transform.forward * -_selfRB.angularVelocity.y * _enemyStats.XTiltModifier);

//             // add torque to rotate in the y axis direction
//             _selfRB.AddTorque(transform.right * _selfRB.velocity.y * _enemyStats.YTiltModifier);
//         }
//         //if player is within enemy look range 
//         //and is targetable by the target system 
//         if(_targetSystem._lockedTarget != null)
//         {  
//             //set the navigator target to the locked player target. 
//             _navSystem.SetTarget(_targetSystem._lockedTarget);

//             //change state to chase state. 
//             //change the state of the navigator to chase state. 
//             SetAIState(EnemyAIStates.Chase, EnemyNavigatorAI.navMeshStates.Chase); 
//         }
//     }

//     //checks if search duration exceeded
//     public bool CheckIfCountDownElapsed(float duration)
// 	{
// 		stateTimeElapsed += Time.deltaTime;
// 		return stateTimeElapsed >= duration;
// 	}

//     //checks if attack duration exceeded
//     public bool CheckIfCoolDownElapsed(float duration)
// 	{
// 		attackCooldown += Time.deltaTime;
// 		return attackCooldown >= duration;
// 	}

//     //Attack State Function
//     //if the player target is within the enemy attack range
//     //makes the enemy attack the player target
//     //calls a function within for type of attack 
//     public void Attack()
//     {
//         //if the enemy has a locked on player target
//         if(_targetSystem._lockedTarget != null)
//         {
//             //if the enemy health is below x% health 
//             // if(_enemyHealth.CurrentHealth <= _enemyHealth.BaseHealthSO.Value * 0.15f)
//             // {
//             //     isRammingAttackEnabled = true;
//             //     Debug.Log("Light Enemy Ramming"); 
//             //     rotateTowardTarget(_targetSystem._lockedTarget.transform.position);
//             //     //call what type of attack we want
//             //     RammingAttack(); 
//             // }
//             // else
//             // {
//                 //isRammingAttackEnabled = false;
//                 //RangedAttack if the enemy health is not too low
//                 //move to the right, using the x axis. 
//                 _selfRB.AddForce(transform.right * _enemyStats.moveSpeed, ForceMode.Acceleration);
//                 //rotate toward the locked player target
//                 rotateTowardTarget(_targetSystem._lockedTarget.transform.position);
//                 //call what type of attack we want
//                 RangedAttack();
//                 //move towards the locked player target
//                 _selfRB.AddForce(transform.forward * _enemyStats.accelerationStep, ForceMode.Acceleration);
//             //}
//         }
//         //when the enemy has no  player target start searching
//         else
//         {
//             SetAIState(EnemyAIStates.Search, EnemyNavigatorAI.navMeshStates.Stop); 
//         }
        
//     }

//     //RangedAttack Function 
//     //uses the target system to target player
//     //then uses the weaponSpawner Fire function to 
//     //fire a missle prefab
//     public void RangedAttack()
// 	{
// 		Vector3 position = transform.position;
// 		float radius = _enemyStats.lookSphereCastRadius;
// 		Vector3 direction = transform.forward;
// 		float attackRange = _enemyStats.attackRange;

//         //when the enemy is attacking, draw a ray in the direction of the target
//         //of length of attack range
//         //for debugging. 
//         Debug.DrawRay(position, direction.normalized * attackRange, Color.red);
//         //compares in game time to our set attack rate time
//         //lets the enemy fire missles after cooldown has passed
//         if(CheckIfCoolDownElapsed(_enemyStats.attackRate))
//         {
//             //prints string to console. for debugging. 
//             Debug.Log("Light Enemy Ranged Attacking");
            
//             //calls on our weapon spawner class method fire
//             //launches a missle prefab from 
//             //the weapon spawner prefab on the enemy game object
//             weaponSpawner.Fire(_targetSystem._lockedTarget); 
//             attackCooldown = 0;
//         }
//     }

//     //RammingAttack Function 
//     //uses the target system to target player
//     //then rams into the target player. 
//     // exploding and dealing damage.  
//    public void RammingAttack()
//    {
//         Vector3 position = transform.position;
// 		float radius = _enemyStats.lookSphereCastRadius;
// 		Vector3 direction = transform.forward;
// 		float attackRange = _enemyStats.attackRange;
        
//         Debug.Log("Light Enemy RammingAttack Function"); 
//         //when the enemy is attacking, draw a ray in the direction of the target
//         //of length of attack range
//         //for debugging. 
// 		Debug.DrawRay(position, direction.normalized * attackRange, Color.red);

//         // //ram the player ship
//         // //add acceleration force to the enemy game object. for movement. 
//         // _selfRB.AddForce(transform.forward * ramSpeed, ForceMode.Acceleration);
//         //compares in game time to our set attack rate time
//         //lets the enemy fire missles after cooldown has passed
//         if(CheckIfCoolDownElapsed(_enemyStats.attackRate))
//         {
//             //prints string to console. for debugging. 
//             Debug.Log("Light Enemy Ram Attacking");     
//             //ram the player ship
//             //add acceleration force to the enemy game object. for movement. 
//             _selfRB.AddForce(transform.forward * ramSpeed, ForceMode.Acceleration);
//         }
//     }


//     //Search State Function 
//     //searches for player target 
//     //that has left the enemy look range
//     //if in look range, chase player
//     //if the player target is not found after searching, 
//     //go back to patrolling
//     public void Search()
//     {
//         Debug.Log("Light Enemy Search Function"); 
//         //search here
//         //rotate enemy around in a circle 
//         //for a short duration
//         if(!CheckIfCountDownElapsed(_enemyStats.searchDuration))
//         {
//             Debug.Log("Light Enemy Rotating");
//             // rotate around the y axis(up) direction
//             transform.RotateAround(transform.position, Vector3.up, _enemyStats.searchingTurnSpeed);
//         }
//         else
//         {
//             //then handle state 
//             //if player is within enemy look range 
//             //and is targetable by the target system 
//             if(_targetSystem._lockedTarget != null)
//             {
//                 //set the navigator target to the locked player target. 
//                 _navSystem.SetTarget(_targetSystem._lockedTarget);

//                 //change the state of the navigator to chase state. 
//                 //change state to chase state. 
//                 SetAIState(EnemyAIStates.Chase, EnemyNavigatorAI.navMeshStates.Chase); 
//             }
//             //if the enemy target cannot be found. Go back to patrolling. 
//             else
//             {
//                 //change current state of enemy to patrol state.  
//                 //change current state of Enemy Navigator AI to the patrol state
//                 SetAIState(EnemyAIStates.Patrol, EnemyNavigatorAI.navMeshStates.Patrol);
//             }
//         }
//     }

//     //Chase State Function
//     //chases locked on player target
//     //if in attack range, attack player
//     //if the player target is locked, go back to patrolling
//     public void Chase()
//     {
//         //if player is within enemy look range 
//         //and is targetable by the target system 
//         if(_targetSystem._lockedTarget != null)
//         {
//             //set the enemy to patrol around the player target
//             Patrol(_targetSystem._lockedTarget.transform, Vector3.zero);

//             //if the player target is within the enemy attack range
//             if(Vector3.Distance(transform.position, _targetSystem._lockedTarget.transform.position) < _enemyStats.attackRange)
//             {   
//                 //changes the state of the enemy to the attack state
//                 SetAIState(EnemyAIStates.Attack, EnemyNavigatorAI.navMeshStates.Stop);
//             }
//         }
//         //when the enemy has no locked on player target
//         else
//         {
//             SetAIState(EnemyAIStates.Search, EnemyNavigatorAI.navMeshStates.Stop);
//         }
//     }
    
//     //when the drone is destroyed
//     //destroy the attached enemy navigator. 
//     public void OnDestroy()
//     {
//         if(_navSystem != null)
//         {
//             Destroy(_navSystem.gameObject); 
//         }
//         Destroy(transform.parent.gameObject);
//     }

//     //OncollisionEnter() Function
//     //Used for RammingAttack() Function
//     //Called when the enemy is in its attack state and rams the player target. 
//     private void OnCollisionEnter(Collision collision) 
//     {
//         if(isRammingAttackEnabled)
//         {
//             //retrive the PlayerHealth Component From player game object
//             if(collision.gameObject.TryGetComponent<Damageable>(out var damageable) && collision.gameObject == _targetSystem._lockedTarget.gameObject)
//             {
//                 //deal damage to the player, based on enemy stats attack damage
//                 damageable.TakeDamage(_enemyStats.attackDamage); 
//                 //call TakeDamage() and pass in the enemy CurrentHealth stat
//                 //setting the enemy health to 0
//                 //this will instantiate an explosion effect
//                 //and destroy the game object through the damageable class
//                 _enemyHealth.TakeDamage(_enemyHealth.CurrentHealth); 
//             }
//         }
//     }

//     //SetAIState() function
//     //sets the enemy AI state
//     //sets enemy Navigator AI state
//     //resets state time elapsed
//     public void SetAIState(EnemyAIStates currentAIState, EnemyNavigatorAI.navMeshStates currentNavState)
//     {
//         //update the enemy navigator AI state
//         _navSystem.SetState(currentNavState);
//         //update the enemy AI state
//         _currentState = currentAIState;
//         //reset elapsed state time 
//         stateTimeElapsed = 0;
//     }
// }