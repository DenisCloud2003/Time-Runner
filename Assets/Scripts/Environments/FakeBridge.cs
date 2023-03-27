using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBridge : MonoBehaviour
{
    [SerializeField] GameObject fakeBridge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallingRock"))
        {
            fakeBridge.SetActive(false);
        }
    }
}
