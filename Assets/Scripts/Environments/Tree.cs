using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private int animCount = 0;
    Animator treeAnim;
    Watch watch;

    // Start is called before the first frame update
    private void Start()
    {
        treeAnim = GetComponent<Animator>();
        watch = GameObject.Find("Watch").GetComponent<Watch>();
    }

    public void CheckInput()
    {
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);

        if (watch.isUsing)
        {
            if (watch.isForward && !watch.isBackward && animCount < 4)
            {
                treeAnim.SetTrigger("Forward");
                animCount++;
            }
            else if (watch.isBackward && !watch.isForward && animCount > 0)
            {
                treeAnim.SetTrigger("Backward");
                animCount--;
            }
            else StartCoroutine(Timer());

            if (watch.isForward && animCount == 4)
            {
                watch.isUsing = false;
            }
        }
        else
        {
            StartCoroutine(Timer());
        }
    }
}
