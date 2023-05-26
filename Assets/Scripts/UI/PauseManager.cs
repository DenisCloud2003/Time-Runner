using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    static public PauseManager instance;
    private void Awake()
    {
        gameObject.SetActive(true);

        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);

        if (SceneManager.GetActiveScene().buildIndex == 4) DontDestroyOnLoad(gameObject);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
    }
}
