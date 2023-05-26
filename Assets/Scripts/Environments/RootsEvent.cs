using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsEvent : MonoBehaviour
{
    [SerializeField] public Collider breakPoint;
    [SerializeField] public Collider safePoint;

    private void Breaking()
    {
        if (breakPoint.CompareTag("Player"))
        {

        }
    }

    private void Safe()
    {
        if (safePoint.CompareTag("Player"))
        {

        }
    }
}
