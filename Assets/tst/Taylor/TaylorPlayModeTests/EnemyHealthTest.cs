using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class EnemyHealthTest
{

    [SetUp] public void SetUp()
    {
        SceneManager.LoadScene("Taylor_Testing");
    }

    [UnityTest] public IEnumerator EnemyBelowMinimumHealth()
    {
        GameObject gameObject = GameObject.Find("Test_Enemy");
        Damageable enemy = gameObject.GetComponent<Damageable>();

        enemy.TakeDamage(enemy.baseHealth + 100);
        Assert.AreEqual(0, enemy.currentHealth);

        enemy.GainHealth(enemy.baseHealth);
        enemy.TakeDamage(enemy.baseHealth);
        Assert.AreEqual(0, enemy.currentHealth);

        enemy.GainHealth(enemy.baseHealth);
        enemy.TakeDamage(enemy.baseHealth-1);
        Assert.IsTrue(enemy.currentHealth > 0);
        yield return null;
    }

    [UnityTest] public IEnumerator EnemyAboveBaseHealth()
    {
        GameObject gameObject = GameObject.Find("Test_Enemy");

        Damageable enemy = gameObject.GetComponent<Damageable>();

        enemy.GainHealth(enemy.baseHealth + 100);
        Assert.AreEqual(enemy.baseHealth, enemy.currentHealth);

        enemy.TakeDamage(enemy.baseHealth);
        enemy.GainHealth(enemy.baseHealth);
        Assert.AreEqual(enemy.baseHealth, enemy.currentHealth);

        enemy.TakeDamage(1000);
        yield return null;
        Assert.IsTrue(enemy.currentHealth < enemy.baseHealth);
        yield return null;
    }
}