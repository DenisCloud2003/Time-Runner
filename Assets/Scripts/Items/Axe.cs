using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : ItemBase
{
    [SerializeField] public UsePoint usePoint;
    [SerializeField] public Tree2 tree;
    [SerializeField] bool isPickedUp;

    public Sprite sprite;

    SpriteRenderer axeSprite;
    EventManager eventManager;
    public ItemPopupBox popupBox;

    private void Awake()
    {
        axeSprite = GetComponent<SpriteRenderer>();
        eventManager = GameObject.Find("Game Manager").GetComponent<EventManager>();
        isPickedUp = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !itemList.IsWatch())
        {
            eventManager.EventInput();
        }
    }

    private void OnEnable()
    {
        EventManager.OnInput += UseAxe;
    }

    private void OnDisable()
    {
        EventManager.OnInput -= UseAxe;
    }

    //Use the axe
    public void UseAxe()
    {
        if (isPickedUp && usePoint.UseState() && !itemList.IsWatch() && Input.GetKeyDown(KeyCode.F))
        {
            tree.CutTree();
        }
    }

    //Pick up axe
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            axeSprite.enabled = false;
            isPickedUp = true;
            itemList.Items.Add(GameObject.FindGameObjectWithTag("Axe"));

            Collider2D collider = GetComponent<Collider2D>();
            collider.enabled = false;

            popupBox.AxePopUp();
        }
    }
}