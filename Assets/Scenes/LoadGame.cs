using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadGame : MonoBehaviour
{
public void loadScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
