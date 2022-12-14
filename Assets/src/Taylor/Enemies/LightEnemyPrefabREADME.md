# 513 Studios 

![513 Studios Logo](Dread/CompanyLogo/Company_Logo.png)

## Light Enemy Prefab Demo:
https://youtu.be/YD6-Y_WTV9I

# Dread
513 Studios debut 2D sci-fi shooter. 

# Taylor Martin CS-383 Prefab Documentation README File
This is documentation for one of the enemy prefabs I made for D.R.E.A.D<br />
<br />
Light Enemy Prefab<br />
</br>

## Light Enemy Prefab Components:
-------------------
- Is a subclass of EnemyAIStateMachine superclass. Inherits all of its member variables and methods.<br />
    -Has a AIStateMachine() function that is used to handle the state actions and transitions.<br />
    -Has a SetAIState() function to set the state of the enemy.<br />
    -Has a Attack() function that is used to shoot at the target once in attack range.<br />
    -Has a Patrol() function that will call my AIPatrol script to generate movement graph and wander in level.<br />
    -Has a Chase() function that will call the seeker and AIDestinationSetter script to chase set target.<br />
    -Has a search function once the enemy loses sight of the target and will rotate and look around for the lost target.<br />
    -Has a RotateTowards() function that is used to rotate the enemy towards the target.<br />
    -Has a ChangeObjectComponents() function that is used to turn on and off the AIDestinationSetter and AIPatrol scripts when needed.<br />
    -Has a CheckIfCoolDownElapsed() function for checking attack cooldown.<br />
    -Has a CheckIfCountDownElapsed() function for checking Search duration.<br />
- Has a RigidBody 2D<br />
- Has a Circle Collider<br />
- Has a Enemy Eyes Component<br />
    -Enemy Eyes has a circle collider 
    -Enemy Eyes Script to control collider and send target info to enemy.
- Has A Damageable Script component, for health and damage<br />
- Has a EnemyStatsSO for Enemy stats<br />
- Uses A* Pathfinding Package<br />
  - Has a AI Path Component, to handle AI agent movement
  - Has a seeker component, for following a target
  - Has a AIDestinationSetter component for setting AI target for Seekrer and Path
  - Has a AI Patrol script component I wrote for random point wandering movement in level
  - Has a simple and advanced smooth component for more accurate path generation and smooth movement

<br />

## Light Enemy Prefab Behavior:
-------------------
### This state machine has the base 4 states
- Patrol, Chase, Attack, and Search. 
- The enemy type will in default patrol around the map within its givin patrol radius.
- Once the player is seen, the enemy will chase the player.
- once targeted and in attack range, the enemy will fire missles at the player.
- If sight of the player is lost, the enemy will rotate and search for the player. 
- If the player is not found, go back to patrolling. 
<br />