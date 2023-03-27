using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots2 : MonoBehaviour
{
    protected int anim2Count = 0;

    [HideInInspector] Animator roots2Anim;
    Watch watch;

    // Start is called before the first frame update
    private void Awake()
    {
        roots2Anim = GetComponent<Animator>();
        watch = GameObject.Find("Watch").GetComponent<Watch>();
    }

    public void CheckInput2()
    {
        StartCoroutine(Timer());
    }

    public void BrokenAnimState()
    {
        roots2Anim.SetTrigger("Broken");
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);

        if (watch.isUsing)
        {
            if (watch.isForward && !watch.isBackward && anim2Count < 3)
            {
                roots2Anim.SetTrigger("Forward");
                anim2Count++;
            }
            else if (watch.isBackward && !watch.isForward && anim2Count > 0)
            {
                roots2Anim.SetTrigger("Backward");
                anim2Count--;
            }
            else StartCoroutine(Timer());

            if (watch.isForward && anim2Count == 3)
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
