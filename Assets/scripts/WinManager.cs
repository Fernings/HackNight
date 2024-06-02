using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public GameObject GameOverGui;
    public GameObject player2ui;
    public void Player1Win()
    {
        Time.timeScale = 0;
        GameOverGui.SetActive(true);
        player2ui.SetActive(false);  
    }

    public void Player2Win()
    {
        Time.timeScale = 0;
        GameOverGui.SetActive(true);
        player2ui.SetActive(false);
    }
}
