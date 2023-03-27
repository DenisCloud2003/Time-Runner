using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{ 
    [SerializeField] public bool isUsing;
    [HideInInspector] private int inputCount = 0;
    public ItemList itemList;


    public void Start()
    {
        itemList = GameObject.Find("Items").GetComponent<ItemList>();
    }

    //Use function
    protected void Use()
    {
        if (Input.GetKeyDown(KeyCode.F) && itemList.IsWatch())
        {
            if (inputCount == 0)
            {
                isUsing = true;
                inputCount++;
            }
            else
            {
                isUsing = false;
                inputCount--;
            }    
        }
    }

    //Uncheck the use condition
    protected void NotUse()
    {
        isUsing = false;
        inputCount = 0;
    }
}
