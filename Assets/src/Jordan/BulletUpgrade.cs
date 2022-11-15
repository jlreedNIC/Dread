/**
 * @file    BulletUpgrade.cs
 * @author  Jordan Reed
 *
 * @brief   This class handles the bullet upgrades. Generalized script to use for any bullet upgrade
 *
 *          Could have been implemented alongside the items. Inherited from base item class.
 *
 * @date    November 2022
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject bullet;         // prefab to assign into ammo manager


    /*
     * @brief   Applies a new bullet type in the ammo manager. 
     */
    public void applyBulletUpgrade()
    {
        AmmoManager.Instance.SetNewAmmoType(bullet);
    }

    /*
     * @brief   When a collision is detected with the item, a notification screen is called and the 
     *          upgrade is applied. The item is then destroyed.
     *
     * @param   Collision2D col The collider that has been detected and can now be acted on
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("player collided with new bullet");
            
            NotificationManager.Instance.showScreen("New ammo type picked up!");
            applyBulletUpgrade();
            Destroy(gameObject);
        }
        
    }
}
