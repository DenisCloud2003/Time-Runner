using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGround : MonoBehaviour
{
    [SerializeField] GameObject fakeGround;

    private void Awake()
    {
        fakeGround.SetActive(true);
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fakeGround.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
