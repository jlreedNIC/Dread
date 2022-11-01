/**
 * @file    weapon_upgrade.cs
 * @author  Jordan Reed
 *
 * @brief   This class is the weapon upgrade item class.
 *
 * @date    October 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_upgrade : MonoBehaviour
{
    // generalized script to use for any weapon upgrade
    [SerializeField] private GameObject upgradeWrapper;     // weapon upgrade to create
    public GameObject upgrade_type;                         // prefab of type to create


    /*
     * @brief Applies an upgrade to the weapon object given as a parameter. 
     *        This function will give the new weapon the same location, rotation, and parent gameobject as the current weapon.
     *        It will change the parent of the old weapon to the new weapon. 
     *        It will hide the old weapon object and activate the new weapon object.
     *        It will also apply the decorator (new weapon) to wrap around the old weapon.
     *        It will also trigger a notification to show what the player has picked up.
     *
     * @param int currentWeapon A gameobject that is what the player (potentially enemy) is currently holding
     *
     * @returns GameObject that the player WILL be holding, ie new weapon
     */
    public GameObject applyUpgrade(GameObject currentWeapon)
    {
        Debug.Log("picked up weapon upgrade. showing notification and applying now...");
        NotificationManager.Instance.showScreen("Weapon Upgrade: " + upgradeWrapper.GetComponent<Base_Weapon>().getWeaponName());

        // give the new weapon the position, rotation, and parent of the old weapon
        upgradeWrapper.transform.position = currentWeapon.transform.position;
        upgradeWrapper.transform.rotation = currentWeapon.transform.rotation;
        upgradeWrapper.transform.parent = currentWeapon.transform.parent;
        upgradeWrapper.transform.localScale = currentWeapon.transform.localScale;

        // remove the parent and rotation of the old weapon
        currentWeapon.transform.parent = upgradeWrapper.transform;
        currentWeapon.transform.rotation = new Quaternion(0,0,0,0);

        // hide old weapon
        currentWeapon.GetComponent<SpriteRenderer>().enabled = !currentWeapon.GetComponent<SpriteRenderer>().enabled;
        currentWeapon.GetComponent<Collider2D>().enabled = !currentWeapon.GetComponent<Collider2D>().enabled;

        // Debug.Log("setting wrapper and wrappee");
        upgradeWrapper.GetComponent<Base_Decorator>().setWrappee(currentWeapon);
        // Debug.Log("wrappee: " + currentWeapon);

        // enable new weapon to be seen and collided with
        upgradeWrapper.GetComponent<SpriteRenderer>().enabled = !upgradeWrapper.GetComponent<SpriteRenderer>().enabled;
        upgradeWrapper.GetComponent<Collider2D>().enabled = !upgradeWrapper.GetComponent<Collider2D>().enabled;

        // Debug.Log("destroying " + gameObject);
        Destroy(gameObject);

        // return the new weapon to be set in the player script
        return upgradeWrapper;
    }

    // Start is called before the first frame update
    void Start()
    {
        // instantiate weapon upgrade and make it not visible and not collidable
        upgradeWrapper = Instantiate(upgrade_type);
        
        upgradeWrapper.GetComponent<SpriteRenderer>().enabled = !upgradeWrapper.GetComponent<SpriteRenderer>().enabled;
        upgradeWrapper.GetComponent<Collider2D>().enabled = !upgradeWrapper.GetComponent<Collider2D>().enabled;
        upgradeWrapper.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
