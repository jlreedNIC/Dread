using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class GameMngrTst
{

    public BoardMngrTst boardScript;

    // test level
    private int level = 3;
    [Test]
    // Start is called before the first frame update
    void Awake()
    {   
        boardScript = GetComponent<BoardMngrTst>();
        InitGame();
    }
    [Test]
    void InitGame()
    {
        boardScript.SetupScene(level);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}