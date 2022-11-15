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

    // Start is called before the first frame update
    void Start()
    {
        CamWLoader = GameObject.Find("Main Camera");
        loaderRef = CamWLoader.GetComponent<Loader>();
        gameRef = loaderRef.gameManager.GetComponent<GameManager>();
        board = GameObject.Find("Board");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * @brief When a collision is detected with the item, a notification screen is called and the 
     *        upgrade is applied. The item is then destroyed.
     *
     * @param Collision2D col The collider that has been detected and can now be acted on
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("player collided with exit tile");
            // SceneManager.LoadScene(1); 


            board.SetActive(false);
            this.gameObject.SetActive(false);

            GameObject enemy;
            while(enemy = GameObject.FindWithTag("Enemy"))
            {
                EnemyObjectPooling.Instance.DespawnEnemy(enemy);
            }

            gameRef.level++;

            loaderRef.initialize();
            for(int i=0; i<gameRef.level+10; i++)
            {
                EnemyObjectPooling.Instance.RequestEnemy();
            }
            
            // GameManager.instance.InitGame();
            // NotificationManager.Instance.instantiateNotifications();
            // Destroy(NotificationManager.Instance);
        }
        
    }
}
