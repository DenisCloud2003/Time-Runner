using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayUI;

    public void Playgame()
    {
        Time.timeScale = 1f;
        GameManager.instance.UpdateGameState(GameState.LoadScene);
    }

    public void HowToPlay()
    {
        howToPlayUI.SetActive(true);
    }

    public void Close()
    {
        howToPlayUI.SetActive(false);
    }
    
    public void Quitgame()
    {
        Application.Quit();
    }
}
