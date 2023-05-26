using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f; 

    private void Awake()
    {
        gameObject.DontDestroyOnLoad();
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

        yield return new WaitForSeconds(0.5f);

        transition.SetTrigger("End");

        yield return new WaitForSeconds(0.5f);

        GameManager.instance.UpdateGameState(GameState.Setup);
    }
}
