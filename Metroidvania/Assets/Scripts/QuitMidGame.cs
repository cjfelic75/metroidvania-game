using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMidGame : MonoBehaviour
{
    public void Quit()
    {
        if (Input.GetKey("Escape"))
            Application.Quit();
    }
}