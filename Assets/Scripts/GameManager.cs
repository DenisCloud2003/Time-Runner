using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;
    public static GameManager instance
    {
        get
        {
            if (GameManagerInstance == null)
            {
                GameManagerInstance = FindObjectOfType<GameManager>();
                if (GameManagerInstance == null)
                {
                    GameObject obj = new GameObject();
                    GameManagerInstance = obj.AddComponent<GameManager>();
                }
            }

            return GameManagerInstance;
        }
    }

    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public GameObject transPoint;

    public PlayerSetup playerSetup;
    public Dialogue dialogue;

    private void Awake()
    {
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
            case GameState.Dialogue:
                HandleDialogue();
                break;
            case GameState.Play:
                HandlePlay();
                break;
            case GameState.Transition:
                HandleTransition();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
        Debug.Log(newState);
    }

    private void HandleTransition()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 3) playerSetup.Unmovable();
    }

    private void HandlePlay()
    {
        playerSetup.Moveable();
    }

    private void HandleDialogue()
    {

        dialogue = GameObject.FindGameObjectWithTag("Dialogue Box").GetComponent<Dialogue>();
        dialogue.StartDialogue();

    }

    private async void HandleLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        await Task.Delay(300);
        UpdateGameState(GameState.Setup);
    }

    private void HandleSetup()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            playerSetup.Setup();

            transPoint = GameObject.FindGameObjectWithTag("Loader");
            transPoint.AddComponent<LoaderPoint>();

            UpdateGameState(GameState.Dialogue);
        }
    }

}

public enum GameState
{
    Menu,
    LoadScene,
    Setup,
    Dialogue,
    Play,
    Transition
}
