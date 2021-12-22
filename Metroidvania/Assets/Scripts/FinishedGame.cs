using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedGame : MonoBehaviour
{
    public string EndGame;

    void Start()
    {
        GameEnd(false);
    }
    void OnTriggerEnter2D(Collider2D end)
    {
        if (end.tag == "Player")
        {
            GameEnd(true);
        }
    }
    
    void GameEnd(bool End)
    {
        if(End)
        {
            SceneManager.LoadScene(EndGame);
        }
    }
}
