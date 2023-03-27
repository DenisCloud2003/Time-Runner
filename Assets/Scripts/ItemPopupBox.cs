using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopupBox : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public Image itemImage;

    [SerializeField] int delay = 0;
    private void Start()
    {
        itemImage = GameObject.Find("Item Image").GetComponent<Image>();
    }

    public void PopUp(Sprite image)
    {
        Time.timeScale = 0;
        itemImage.sprite = image;
        popUpBox.SetActive(true);
        animator.SetTrigger("Pop");
    }

    public async void Close()
    {
        animator.SetTrigger("Close");
        await Task.Delay(delay);
        Time.timeScale = 1;
    }
}
