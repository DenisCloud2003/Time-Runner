using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject pauseMenuIcon;
    public GameObject tutorialText;

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        pauseMenuIcon = GameObject.FindGameObjectWithTag("Icon");
        tutorialText = GameObject.FindGameObjectWithTag("Text");
        
        pauseMenuIcon.SetActive(false);
        tutorialText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (tutorialText != null) tutorialText.SetActive(true);
            if (pauseMenuIcon != null) pauseMenuIcon.SetActive(true);
            gameObject.SetActive(false);
            GameManager.instance.UpdateGameState(GameState.Play);
        }
    }
}
