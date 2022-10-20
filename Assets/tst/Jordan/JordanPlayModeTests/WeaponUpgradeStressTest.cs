using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponUpgradeStressTest
{

    // this test will run A REALLY LONG TIME if your laptop is plugged in
    [UnityTest]
    public IEnumerator WeaponUpgradeRecursiveStressTest()
    {
        SceneManager.LoadScene("weapon_stress_test_scene");
        yield return new WaitForSeconds(3); // wait for scene to load

        GameObject weapon = GameObject.Find("base_weapon");
        GameObject dmgUpgrade = GameObject.Find("damage decorator");

        long numRecursiveCalls = 0;
        float fps = 21;
        while(fps > 20)
        {
            fps = 1.0f / Time.deltaTime;
            GameObject newDmgUpgrade = GameObject.Instantiate(dmgUpgrade);      // new weapon upgrade/decorator
            newDmgUpgrade.GetComponent<Base_Decorator>().setWrappee(weapon);    // wrap decorator around base weapon
            weapon = newDmgUpgrade; // don't lose wrapper call
            numRecursiveCalls++;

            Debug.Log("recursive calls now set to " + numRecursiveCalls + ". Testing fire...");

            // try firing
            weapon.GetComponent<Base_Decorator>().Fire();
            yield return null;
            Debug.Log("fps: " + fps);

            // find way to check distance traveled on bullets
            // if distance traveled is more than fire range of weapon, test fails
        }
        // yield return null;
        Debug.Log("final number of recursive calls: " + numRecursiveCalls);
    }
}
