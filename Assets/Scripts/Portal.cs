using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenPortal()
    {
        anim.SetTrigger("Open");
    }

    public void ClosePortal()
    {
        anim.SetTrigger("Close");
    }
}
