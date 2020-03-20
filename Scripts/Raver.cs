using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raver : MonoBehaviour
{
    private bool m_IsQuitting;

    private void OnEnable()
    {
        EventBus.StartListening("Rave", Rave);
    }

    private void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    private void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Rave", Rave);
        }
    }

    void Rave()
    {
        Debug.Log("Rave activated (thanks, Jeremy)");
    }
}
