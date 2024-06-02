using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public GameObject GameOverGui;
    public GameObject player2ui;
    public TMP_Text winnertxt;
    public TMP_Text reasontxt;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void EndGame(string winner, string reason)
    {
        Time.timeScale = 0;
        GameOverGui.SetActive(true);
        player2ui.SetActive(false);
        winnertxt.text = winner + "wins!";
        reasontxt.text = reason;
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
