/**
 * @file    exitTile.cs
 * @author  Jordan Reed
 *
 * @brief   This class handles the bullet upgrades. Generalized script to use for any bullet upgrade
 *
 * @date    November 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class exitTile : MonoBehaviour
{
    [SerializeField] private GameObject CamWLoader;
    private Loader loaderRef;
    private GameManager gameRef;
    [SerializeField] private GameObject board;
    public GameObject loadScreen;

    // Start is called before the first frame update
    void Start()
    {
        // find the board and game manager references in the scene
        CamWLoader = GameObject.Find("Main Camera");
        loaderRef = CamWLoader.GetComponent<Loader>();
        gameRef = loaderRef.gameManager.GetComponent<GameManager>();
        board = GameObject.Find("Board");
    }

    /*
     * @brief When a collision is detected with the exit tile, increase the level and reinstantiate the scene.
     *
     * @param Collision2D col The collider that has been detected and can now be acted on
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("player collided with exit tile");
            // SceneManager.LoadScene(1); 

            // set bpard inactive
            board.SetActive(false);
            this.gameObject.SetActive(false);

            // find all enemies and despawn them
            GameObject enemy;
            while(enemy = GameObject.FindWithTag("Enemy"))
            {
                EnemyObjectPooling.Instance.DespawnEnemy(enemy);
            }

            // increase level
            gameRef.level++;

            // reload the board
            loaderRef.initialize();
        }
    }
}
