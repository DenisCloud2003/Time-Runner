using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    public Transform playerTransform;

    public PlayerSetup playerSetup;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);   
        
        playerSetup = gameObject.GetComponent<PlayerSetup>();
    }

    private void Start()
    {
        UpdateGameState(GameState.Menu);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Menu:
                break;
            case GameState.LoadScene:
                HandleLoadScene();
                break;
            case GameState.Setup:
                HandleSetup();
                break;
            case GameState.Play:
                break;
            case GameState.Transition:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);       
        }

        OnGameStateChanged?.Invoke(newState);
        Debug.Log(newState);
    }

    private void HandleSetup()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            playerSetup.Setup();
        }
    }

    private async void HandleLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        await Task.Delay(300);
        UpdateGameState(GameState.Setup);
    }
}

public enum GameState
{
    Menu,
    LoadScene,
    Setup,
    Play,
    Transition
}
