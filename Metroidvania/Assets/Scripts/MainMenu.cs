using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LoadGame;

    public void Play()
    {
        SceneManager.LoadScene(LoadGame);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
