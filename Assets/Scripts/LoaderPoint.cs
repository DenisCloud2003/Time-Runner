using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderPoint : MonoBehaviour
{
    public Transition trans;

    public void Start()
    {
        trans = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            gameObject.SetActive(false);
            GameManager.instance.UpdateGameState(GameState.Transition);
            trans.LoadNextLevel();
        }
    }
}
