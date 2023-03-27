using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI outOfTimeText;
    [SerializeField] private TextMeshProUGUI fallText;
    [SerializeField] private TextMeshProUGUI fallIntoSpikeText;
    public string condition;

    private void Awake()
    {
        condition = null;
    }

    public void TextChanger(string condition)
    {
        if (condition == "OfT")
        {
            outOfTimeText.enabled = true;
            fallText.enabled = false;
            fallIntoSpikeText.enabled = false;
        }
        else if (condition == "fall")
        {
            fallText.enabled = true;
            outOfTimeText.enabled = false;
            fallIntoSpikeText.enabled = false;
        }
        else if (condition == "spike")
        {
            fallIntoSpikeText.enabled = true;
            outOfTimeText.enabled = false;
            fallText.enabled = false;
        }
    }
}
