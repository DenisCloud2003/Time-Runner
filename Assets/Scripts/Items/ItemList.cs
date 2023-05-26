using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField] public List<GameObject> Items = new List<GameObject>();
    public GameObject watchUI;
    public GameObject axeUI;
    public bool isUsingWatch;
    public int id;
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

    //Rotate & Change Items
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


    //For Popup UI
    public void IndexReturner()
    {
        if (Items != null)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] == GameObject.Find("Watch"))
                {
                    id = 0;
                }
                else id = 1;
            }
        }

        UIEnabler(id);
    }

    public void UIEnabler(int id)
    {
        if (id == 0)
            watchUI.SetActive(true);
        else axeUI.SetActive(true);
    }
}
