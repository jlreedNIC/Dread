using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ammoManagerCountTest
{
    /*
        This test will see what happens when you add ammmo less than what the ammo maximum is.
        i.e. when you add 4 ammo and the max is 5
     */
    [Test]
    public void add_ammo_total_less_than_max_ammo()
    {
        AmmoManager newRef = AmmoManager.Instance;

        int ammoToAdd = 4;
        int ammoMax = 5;

        newRef.updateMaxTotal(ammoMax);
        newRef.updateAmmoCount(ammoToAdd);

        Debug.Log("add ammo less than max ammo totals: " + newRef.GetTotalAmmo() + "/" + newRef.GetMaxAmmo());

        Assert.That(newRef.GetTotalAmmo(), Is.InRange(0,ammoMax));

        // reset ammo manager
        newRef.updateMaxTotal(-ammoMax);
        newRef.updateAmmoCount(-ammoToAdd);
    }

    /*
        This test will see what happens when you add ammmo more than what the ammo maximum is.
        i.e. when you add 6 ammo and the max is 5
     */
    [Test]
    public void add_ammo_total_more_than_max_ammo()
    {
        AmmoManager newRef = AmmoManager.Instance;

        int ammoToAdd = 6;
        int ammoMax = 5;

        newRef.updateMaxTotal(ammoMax);
        newRef.updateAmmoCount(ammoToAdd);

        Debug.Log("add ammo more than max ammo totals: " + newRef.GetTotalAmmo() + "/" + newRef.GetMaxAmmo());

        Assert.That(newRef.GetTotalAmmo(), Is.InRange(0,ammoMax));

        // reset ammo manager
        newRef.updateMaxTotal(-ammoMax);
        newRef.updateAmmoCount(-ammoToAdd);
    }

    /*
        This test will see what happens when you add ammmo to what the ammo maximum is.
        i.e. when you add 6 ammo and the max is 5
     */
    [Test]
    public void add_ammo_total_to_max_ammo()
    {
        AmmoManager newRef = AmmoManager.Instance;

        int ammoToAdd = 5;
        int ammoMax = 5;

        newRef.updateMaxTotal(ammoMax);
        newRef.updateAmmoCount(ammoToAdd);

        Debug.Log("add ammo to max ammo totals: " + newRef.GetTotalAmmo() + "/" + newRef.GetMaxAmmo());

        Assert.That(newRef.GetTotalAmmo(), Is.InRange(0,ammoMax));

        // reset ammo manager
        newRef.updateMaxTotal(-ammoMax);
        newRef.updateAmmoCount(-ammoToAdd);
    }

    /*
        This test will see what happens when you add subtract ammo so the total is more than zero
        i.e. when you subtract 4 ammo from 5 total ammo
     */
    [Test]
    public void subtract_ammo_total_more_than_zero()
    {
        AmmoManager newRef = AmmoManager.Instance;

        int ammoToAdd = 6;
        int ammoMax = 5;

        newRef.updateMaxTotal(ammoMax);
        newRef.updateAmmoCount(ammoToAdd);

        ammoToAdd = -4;
        newRef.updateAmmoCount(ammoToAdd);

        Debug.Log("subtract ammo to more than zero ammo totals: " + newRef.GetTotalAmmo() + "/" + newRef.GetMaxAmmo());
        
        Assert.That(newRef.GetTotalAmmo(), Is.InRange(0,ammoMax));

        // reset ammo manager
        newRef.updateMaxTotal(-ammoMax);
        newRef.updateAmmoCount(-1);
    }

    /*
        This test will see what happens when you add subtract ammo so the total is zero
        i.e. when you subtract 5 ammo from 5 total ammo
     */
    [Test]
    public void subtract_ammo_total_equal_to_zero()
    {
        AmmoManager newRef = AmmoManager.Instance;

        int ammoToAdd = 6;
        int ammoMax = 5;

        newRef.updateMaxTotal(ammoMax);
        newRef.updateAmmoCount(ammoToAdd);

        ammoToAdd = -5;
        newRef.updateAmmoCount(ammoToAdd);

        Debug.Log("subtract ammo to zero ammo totals: " + newRef.GetTotalAmmo() + "/" + newRef.GetMaxAmmo());
        
        Assert.That(newRef.GetTotalAmmo(), Is.InRange(0,ammoMax));

        // reset ammo manager
        newRef.updateMaxTotal(-ammoMax);
    }

    /*
        This test will see what happens when you add subtract ammo so the total is less than zero
        i.e. when you subtract 6 ammo from 5 total ammo
     */
    [Test]
    public void subtract_ammo_total_less_than_zero  ()
    {
        AmmoManager newRef = AmmoManager.Instance;

        int ammoToAdd = 6;
        int ammoMax = 5;

        newRef.updateMaxTotal(ammoMax);
        newRef.updateAmmoCount(ammoToAdd);

        ammoToAdd = -6;
        newRef.updateAmmoCount(ammoToAdd);

        Debug.Log("subtract ammo to less than zero ammo totals: " + newRef.GetTotalAmmo() + "/" + newRef.GetMaxAmmo());
        
        Assert.That(newRef.GetTotalAmmo(), Is.InRange(0,ammoMax));

        // reset ammo manager
        newRef.updateMaxTotal(-ammoMax);
    }

}
