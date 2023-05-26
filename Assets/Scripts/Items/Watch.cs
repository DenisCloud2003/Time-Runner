using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watch : ItemBase
{
    [SerializeField] public bool isForward;
    [SerializeField] public GameObject forwardUI;
    [SerializeField] public bool isBackward;
    [SerializeField] public GameObject backwardUI;
    [SerializeField] SpriteRenderer watchSprite;
    public ItemPopupBox box;
    public Portal p;

    [HideInInspector] public int count = 0;
    public float cooldownTimer;
    public bool watchPickedUp;
    [HideInInspector] public Sprite sprite;

    private void Awake()
    {
        watchSprite = GameObject.Find("Watch").GetComponent<SpriteRenderer>();
        watchPickedUp = false;

        if (GameObject.FindGameObjectWithTag("Portal"))
        {
            p = GameObject.FindGameObjectWithTag("Portal").GetComponent<Portal>();
        }
        else Debug.Log("No Portal Found!!");
    }

    public void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer < 0f)
            {
                cooldownTimer = 0f;
            }
        }
        else
        {
            KeyInput();
        }
    }

    public void KeyInput()
    {

        if (Input.GetKeyDown(KeyCode.R) && cooldownTimer == 0 && !isUsing && watchPickedUp)
        {
            if (count == 0)
            {
                forwardUI.SetActive(true);
                backwardUI.SetActive(false);
                ForwardMode();
                count++;
            }
            else if (count == 1)
            {
                forwardUI.SetActive(false);
                backwardUI.SetActive(true);
                BackwardMode();
                count--;
            }

            cooldownTimer = 1.5f;
        }

        Use();
    }

    void ForwardMode()
    {
        isForward = true;
        isBackward = false;
    }

    void BackwardMode()
    {
        isBackward = true;
        isForward = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (itemList != null)
        {
            itemList.isUsingWatch = true;
            itemList.Items.Add(GameObject.FindGameObjectWithTag("Watch"));
        }
        
        Collider2D collider = GetComponent<CircleCollider2D>();
        collider.enabled = false;

        if (box != null) box.WatchPopUp();

        watchSprite.enabled = false;
        watchPickedUp = true;
        
        p.OpenPortal();
    }
}
