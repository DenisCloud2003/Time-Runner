using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void TriggerAction();
    public delegate void InputAction();

    public static event TriggerAction OnTrigger;
    public static event InputAction OnInput;

    public void EventInput()
    {
        if (OnInput != null)
        {
            OnInput();
        }
    }

    public void EventTrigger()
    {
        if (OnTrigger != null)
        {
            OnTrigger();
        }
    }
}
