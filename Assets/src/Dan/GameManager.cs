/* GameManager.cs
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public BoardManager boardScript;

    // test level
    private int level = 1;

    // Start is called before the first frame update
    void Awake()
    {   
        if (instance = null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
        // any other game objects go below here
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}