using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsEvent : MonoBehaviour
{
    public GameObject collider1;
    public GameObject collider2;
    public GameObject breakPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        breakPoint.SetActive(false);

        collider1.SetActive(true);
        collider2.SetActive(true);
    }
}
