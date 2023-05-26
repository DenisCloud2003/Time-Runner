using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{ 
    [SerializeField] public bool isUsing;
    [HideInInspector] private int inputCount = 0;
    public ItemList itemList;
    public GameObject[] Trees;


    public void Start()
    {
        if (!GameObject.Find("Items"))
        {
            Debug.Log("No Item");
        }
        else itemList = GameObject.Find("Items").GetComponent<ItemList>();

        Trees = GameObject.FindGameObjectsWithTag("Tree");
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
                foreach (GameObject tr in Trees)
                {
                    Tree tree = tr.GetComponent<Tree>();
                    tree.InvokeFunction();
                }
            }
            else
            {
                isUsing = false;
                inputCount--;
                foreach (GameObject tr in Trees)
                {
                    Tree tree = tr.GetComponent<Tree>();
                    tree.InvokeCancel();
                }
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
