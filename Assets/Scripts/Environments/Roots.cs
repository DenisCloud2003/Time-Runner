using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    public GameObject triggerPoint;

    protected int animCount = 0;
    
    [HideInInspector] Animator rootsAnim;
    Watch watch;

    // Start is called before the first frame update
    private void Awake()
    {
       rootsAnim = GetComponent<Animator>();
       watch = GameObject.Find("Watch").GetComponent<Watch>();
    }

    public void CheckInput()
    {
        StartCoroutine(Timer());
    }

    public void BrokenAnimState()
    {
        rootsAnim.SetTrigger("Broken");
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);

        if (watch.isUsing)
        {
            if (watch.isForward && !watch.isBackward && animCount < 3)
            {
                rootsAnim.SetTrigger("Forward");
                animCount++;
            }
            else if (watch.isBackward && !watch.isForward && animCount > 0)
            {
                rootsAnim.SetTrigger("Backward");
                animCount--;
            }
            else StartCoroutine(Timer());

            if (watch.isForward && animCount == 3)
            {
                watch.isUsing = false;
                triggerPoint.SetActive(true);
            }
        }
        else
        {
            StartCoroutine(Timer());
        }
    }
}
