# README for Base Weapon Prefab

The Base Weapon prefab is a basic gun for a player in a 2D top-down shooter. The base weapon prefab uses the script PlayerBaseWeapon, which inherits from the Base_Weapon class. This allows for potential weapon upgrades to be implemented through a decorator pattern.

## Includes

- 2D Collider
- Fire point gameobject that is automatically set
- Script functions to handle
  - Weapon firing
  - Weapon switching

## Dependencies

You will need the following scripts/prefabs before you can use the prefab.

- Base_Weapon.cs (script)
- PlayerBaseWeapon.cs (script and this prefab)
- Bullet.cs (script and prefab)
- AmmoManager.cs (script and prefab)
- Damageable.cs (to check if bullet can apply damage) (script)

## To Use

- Place prefab as a child of your player gameobject in the orientation you choose
- Weapon will detect when the default fire button is pressed
  - It will trigger a bullet to be spawned by the ammo manager
  - Bullet will then have force applied to move in the direction of the fire point
- Bullet will apply damage if able, and be destroyed upon collision
  - Bullet will apply damage if the other object has a Damageable script attached