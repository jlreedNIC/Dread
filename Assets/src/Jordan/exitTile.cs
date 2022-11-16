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
    [SerializeField] private GameObject winloss;

    // Start is called before the first frame update
    void Start()
    {
        winloss = GameObject.Find("WinLossMngr");

        CamWLoader = GameObject.Find("Main Camera");
        loaderRef = CamWLoader.GetComponent<Loader>();
        gameRef = loaderRef.gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * @brief When a collision is detected with the exit tile, increase the level and load the next scene.
     *
     * @param Collision2D col The collider that has been detected and can now be acted on
     */
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("player collided with exit tile");
            if(gameRef.level >= 7) // last level
            {
                int shipparts = WinLossMngr.getShipParts();
                // check if gathered enough ship parts
                if( shipparts< 7)
                {
                    winloss.GetComponent<WinLossMngr>().triggerDeathScreen();
                }
                else
                {
                    winloss.GetComponent<WinLossMngr>().triggerWinScreen();
                }
            }
            
            // not last level, load next level
            gameRef.level++;
            SceneManager.LoadScene(gameRef.level); 

        }
        
    }
}
