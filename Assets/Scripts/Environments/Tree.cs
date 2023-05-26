using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    Watch watch;

    public int currentProgression = 0;
    public int timeDelayGrowth;
    public int maxGrowth;
    public int minGrowth = 1;

    // Start is called before the first frame update
    private void Start()
    {
        watch = GameObject.Find("Watch").GetComponent<Watch>();
        Invoke("Growth", 0);

        maxGrowth = gameObject.transform.childCount;
    }

    public void InvokeFunction()
    {
        if (watch.isUsing)
        {
            if (watch.isForward)
            {
                CancelInvoke();
                InvokeRepeating("Growth", 1, timeDelayGrowth);
            }
            else if (watch.isBackward)
            {
                CancelInvoke();
                InvokeRepeating("ReverseGrowth", 1, timeDelayGrowth);
            }
        }
    }

    public void InvokeCancel()
    {
        CancelInvoke();
    }

    public void Growth()
    {
        if (currentProgression != maxGrowth)
        {
            gameObject.transform.GetChild(currentProgression).gameObject.SetActive(true);
        }
        if (currentProgression < maxGrowth && currentProgression > 0)
        {
            gameObject.transform.GetChild(currentProgression - 1).gameObject.SetActive(false);
        }
        if (currentProgression < maxGrowth)
        {
            currentProgression++;
        }
        if (currentProgression == maxGrowth)
        {
            CancelInvoke();
            watch.isUsing = false;
        }
    }

    public void ReverseGrowth()
    {
        if (currentProgression > minGrowth)
        {
            if (currentProgression == maxGrowth)
            {
                currentProgression -= 2;
            }
            else currentProgression--;
        }
        if (currentProgression != maxGrowth)
        {
            gameObject.transform.GetChild(currentProgression).gameObject.SetActive(true);
            Debug.Log("siu");
        }
        if (currentProgression >= minGrowth && currentProgression < maxGrowth)
        {
            gameObject.transform.GetChild(currentProgression + 1).gameObject.SetActive(false);
            
        }
        if (currentProgression == minGrowth)
        {
            CancelInvoke();
            watch.isUsing = false;
        }
    }
}
