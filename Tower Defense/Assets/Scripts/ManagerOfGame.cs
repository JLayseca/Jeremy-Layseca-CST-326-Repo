using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfGame : MonoBehaviour
{

    public static bool GameIsOver;
    
    public GameObject gameOverUI;

    void Start ()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
            return; 
            
        if (PlayerStats.HP <= 0)
        {
            EndGame();
        }
    }

    void EndGame ()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);

    }
}
