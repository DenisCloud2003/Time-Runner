using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree3 : MonoBehaviour
{
    private int anim3Count = 0;
    Animator tree3Anim;
    Watch watch;

    // Start is called before the first frame update
    private void Start()
    {
        tree3Anim = GetComponent<Animator>();
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
            if (watch.isForward && !watch.isBackward && anim3Count < 4)
            {
                tree3Anim.SetTrigger("Forward");
                anim3Count++;
            }
            else if (watch.isBackward && !watch.isForward && anim3Count > 0)
            {
                tree3Anim.SetTrigger("Backward");
                anim3Count--;
            }
            else StartCoroutine(Timer());

            if (watch.isForward && anim3Count == 4)
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
