# 513 Studios 

![513 Studios Logo](Dread/CompanyLogo/Company_Logo.png)

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