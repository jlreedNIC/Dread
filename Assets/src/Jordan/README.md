# What is the Basic Weapon Prefab

The Basic Weapon prefab is a basic gun object for a player in a 2D top-down shooter. The prefab is a base implementation that you can then apply your own graphics to customize it. It also can be implemented with weapon upgrades using a decorator design pattern.

https://user-images.githubusercontent.com/70190869/201775107-f5bddf9a-d3ec-4e41-91c3-07dc665c4936.mp4

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
- Place the weapon 'fire' controls in your player input script
- When Fire() is called:
  - It will trigger a bullet to be spawned by the ammo manager
  - Bullet will then have force applied to move in the direction of the fire point
- Bullet will apply damage if able, and be destroyed upon collision
  - Bullet will apply damage if the other object has a Damageable script attached
