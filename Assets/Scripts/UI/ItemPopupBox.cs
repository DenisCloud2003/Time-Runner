using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopupBox : MonoBehaviour
{
    public ItemList itemList;

    public GameObject watchSprite;
    public GameObject axeSprite;

    public GameObject popUpBox;
    public Animator animator;
    public Animator animator2;

    [SerializeField] int delay = 0;
    [SerializeField] int id;

    //For Item Popup
    public void WatchPopUp()
    {
        Time.timeScale = 0;
        popUpBox.SetActive(true);
        animator.SetTrigger("WatchPop");
        id = 0;
    }

    public void AxePopUp()
    {
        Time.timeScale = 0;
        popUpBox.SetActive(true);
        animator.SetTrigger("AxePop");
        id = 1;
    }

    public void Checker()
    {
        if (id == 0) WatchClose();
        else AxeClose();
    }

    public async void WatchClose()
    {
        animator.SetTrigger("WatchClose");
        await Task.Delay(delay);
        MoveItem();
    }

    public async void AxeClose()
    {
        animator.SetTrigger("AxeClose");
        await Task.Delay(delay);
        MoveItem();
    }

    public async void MoveItem()
    {
        if (id == 0) animator.SetTrigger("WatchMove");
        else animator.SetTrigger("AxeMove");

        await Task.Delay(delay + 50);

        itemList.IndexReturner();
        Time.timeScale = 1;
    }


    //For Item Flicker
    public async void Flicker()
    {
        animator2.SetTrigger("Flick1");
        await Task.Delay(delay + 150);
        End();
    }

    public async void Flicker2()
    {
        animator2.SetTrigger("Flick2");
        await Task.Delay(delay + 150);
        End2();
    }

    public void End()
    {
        animator2.SetTrigger("End1");
    }

    public void End2()
    {
        animator2.SetTrigger("End2");
    }
}
