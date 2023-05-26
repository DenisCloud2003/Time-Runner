using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree2 : MonoBehaviour
{
    [SerializeField] GameObject usePoint;
    private int animCount = 0;
    Animator tree2Anim;
    Watch watch;

    // Start is called before the first frame update
    private void Awake()
    {
        watch  =GameObject.Find("Watch").GetComponent<Watch>();
        tree2Anim = GetComponent<Animator>();
        usePoint.SetActive(false);
    }

    //Run cut tree Anim
    public void CutTree()
    {
        tree2Anim.SetTrigger("Cut");
        usePoint.SetActive(false);
    }

    //Check for item input
    public void CheckInput()
    {
        StartCoroutine(Timer());
    }

    //Delay && Anim runner
    public IEnumerator Timer()
    {
        //Time delay for each Anim state
        yield return new WaitForSeconds(1.5f);

        if (watch.isUsing)
        {
            //If Anim at right tree, set the use point to true
            if (animCount == 2)
            {
                usePoint.SetActive(true);
            }

            //Run anim base on the item ouput
            if (watch.isForward && !watch.isBackward && animCount < 4)
            {
                tree2Anim.SetTrigger("Forward");
                animCount++;
            }
            else if (watch.isBackward && !watch.isForward && animCount > 0)
            {
                tree2Anim.SetTrigger("Backward");
                animCount--;
            }
            else StartCoroutine(Timer());

            //If at the last Anim, set using state to false
            if (watch.isForward && animCount == 4)
            {
                watch.isUsing = false;
            }
        }
        else //Infinite loop to check the condition
        {
            StartCoroutine(Timer());
        }
    }
}
