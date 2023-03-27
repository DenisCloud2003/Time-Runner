using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingRootsEvent : MonoBehaviour
{
    [SerializeField] GameObject rootsBreakingPoint;
    [SerializeField] Transform roots1;
    [SerializeField] Transform roots2;
    public EventManager eventManager;
    public Roots root1;
    public Roots2 root2;

    private void OnEnable()
    {
        EventManager.OnTrigger += Broken;
    }

    private void OnDisable()
    {
        EventManager.OnTrigger -= Broken;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        eventManager.EventTrigger();
    }

    void Broken()
    {
        root1.BrokenAnimState();
        root2.BrokenAnimState();
    }
}
