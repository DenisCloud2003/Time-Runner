using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishStage : MonoBehaviour
{
    [SerializeField] GameObject endGameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Win();
        }
    }

    private void Win()
    {
        endGameUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextStage()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }
}
