using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    PauseManager pauseManager;
    //AudioManager audioManager;
    private void Awake()
    {
        //audioManager = FindObjectOfType<AudioManager>();
        pauseManager = GetComponent<PauseManager>();
    }

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (panel.activeInHierarchy == false)
            {
                OpenMenu();
            }
            else
            {
                CloseMenu();
            }
        }
    }

    public void OpenMenu()
    {
        pauseManager.PauseGame();
        panel.SetActive(true);
    }

    public void CloseMenu()
    {
        //audioManager.Play("ButtonClick");
        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    public void MainMenu()
    {
        DontDestroyOnLoadManager.DestroyAll();
        //audioManager.Play("ButtonClick");
        SceneManager.LoadScene(0);

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void Quit()
    {
        //audioManager.Play("ButtonClick");
        Application.Quit();
    }
}
