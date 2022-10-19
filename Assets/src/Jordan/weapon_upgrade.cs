using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_upgrade : MonoBehaviour
{
    // generalized script to use for any weapon upgrade
    [SerializeField] private GameObject upgradeWrapper;
    public GameObject upgrade_type;

    public GameObject applyUpgrade(GameObject currentWeapon)
    {
        Debug.Log("picked up weapon upgrade. applying now...");

        // give the new weapon the position, rotation, and parent of the old weapon
        upgradeWrapper.transform.position = currentWeapon.transform.position;
        upgradeWrapper.transform.rotation = currentWeapon.transform.rotation;
        upgradeWrapper.transform.parent = currentWeapon.transform.parent;

        // remove the parent and rotation of the old weapon
        currentWeapon.transform.parent = upgradeWrapper.transform;
        currentWeapon.transform.rotation = new Quaternion(0,0,0,0);

        // hide old weapon
        currentWeapon.GetComponent<SpriteRenderer>().enabled = !currentWeapon.GetComponent<SpriteRenderer>().enabled;
        currentWeapon.GetComponent<Collider2D>().enabled = !currentWeapon.GetComponent<Collider2D>().enabled;


        upgradeWrapper.GetComponent<Base_Decorator>().setWrappee(currentWeapon);

        // enable new weapon to be seen and collided with
        upgradeWrapper.GetComponent<SpriteRenderer>().enabled = !upgradeWrapper.GetComponent<SpriteRenderer>().enabled;
        upgradeWrapper.GetComponent<Collider2D>().enabled = !upgradeWrapper.GetComponent<Collider2D>().enabled;

        // hide item
        // GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        // GetComponent<Collider2D>().enabled = !GetComponent<Collider2D>().enabled;
        // transform.parent = currentWeapon.transform;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
