using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    public void Setup()
    {
        Instantiate(playerPrefab, new Vector3(-9.4f, -4.51f, 0f), Quaternion.identity);   
    }
}
