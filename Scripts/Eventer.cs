using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventer : MonoBehaviour
{
    private bool m_IsQuitting;

    private void OnEnable()
    {
        EventBus.StartListening("EventAction", EventAction);
    }

    private void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    private void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("EventAction", EventAction);
        }
    }

    void EventAction()
    {
        Debug.Log("Event activated");
    }
}
