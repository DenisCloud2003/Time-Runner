using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    public PlayerMovement playerMovement;

    public void Setup()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length != 0)
        {
            foreach (GameObject player in players)
            {
                Destroy(player);
            }
        }

        Instantiate(playerPrefab, new Vector3(-9.4f, -4.51f, 0f), Quaternion.identity);
    }

    public void Moveable()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (!player.GetComponent<PlayerMovement>())
        {
            player.AddComponent<PlayerMovement>();
            playerMovement = player.GetComponent<PlayerMovement>();  

            if (!player.GetComponent<PlayerMovement>())
            {
                Moveable();
            }
        }
        
    }

    public void Unmovable()
    {
        playerMovement.RemoveScripts();
    }
}
