using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : ItemBase
{
    [SerializeField] public List<GameObject> Items = new List<GameObject>();
    public GameObject watchUI;
    public GameObject axeUI;
    public bool isUsingWatch;
    [HideInInspector] private int rotateCount = 0;

    private void Awake()
    {
        watchUI.SetActive(false);
        axeUI.SetActive(false);
    }

    private void Update()
    {
        RotateItems();
    }
    private void RotateItems()
    {
        if (Items.Count > 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (rotateCount == 1)
                {
                    rotateCount = 0;
                }
                else rotateCount++;
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                if (rotateCount == 0)
                {
                    rotateCount = 1;
                }
                else rotateCount--;
            }

            ItemsChanger();
        } 
    }

    private void ItemsChanger()
    {
        if (rotateCount == 0)
        {
            watchUI.SetActive(true);
            axeUI.SetActive(false);
            isUsingWatch = true;
        }
        else
        {
            watchUI.SetActive(false);
            axeUI.SetActive(true);
            isUsingWatch = false;
        }
    }

    public bool IsWatch()
    {
        return isUsingWatch;
    }
}
