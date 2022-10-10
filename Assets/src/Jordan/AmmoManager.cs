using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    TO DO:
        
 */

// think about if we need the game object to be in the scene. if not, can we get rid of : MonoBehavior??
public sealed class AmmoManager : MonoBehaviour
{
    // singleton implementation
    private AmmoManager() {}
    public static AmmoManager Instance
    {
        get
        {
            return Nested.instance;
        }
    }

    private class Nested
    {
        static Nested() {}
        internal static readonly AmmoManager instance = new AmmoManager();
    }

    [SerializeField] private int totalAmmo;             // total amount of ammo available
    [SerializeField] private int maxTotal;              // total amount of ammo able to be carried
    [SerializeField] private int ammoDamage;            // ammount of damage that the ammo can do
    [SerializeField] private string currentAmmoType;    // type of ammo that is currently created

    // think about creating array of available ammo types with relevant information

    // function will return the total amount of ammo currently have
    public int GetTotalAmmo()
    {
        return totalAmmo;
    }

    // function will return the max amount of ammo able to be carried
    public int GetMaxAmmo()
    {
        return maxTotal;
    }

    public int GetAmmoDamage()
    {
        return ammoDamage;
    }

    public string GetCurrentType()
    {
        return currentAmmoType;
    }

    public void updateAmmoCount(int n)
    {
        totalAmmo += n;
        if(totalAmmo <= 0) totalAmmo = 0;
        else if(totalAmmo >= maxTotal) totalAmmo = maxTotal;
    }

    public void updateMaxTotal(int count)
    {
        maxTotal += count;
    }

    public void SetNewAmmoType()
    {
        // this function will set the currentAmmoType and ammoDamage
        // based off of what is received

        // this is designed for picking up new 'items' that will give upgraded bullets
    }
    
}
