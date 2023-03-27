using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    [SerializeField] GameObject fallingRockPrefab;
    [SerializeField] Transform fallingRockTransform;
    [SerializeField] Transform rockPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Instantiate(fallingRockPrefab, fallingRockTransform);
        }
    }

 
}
