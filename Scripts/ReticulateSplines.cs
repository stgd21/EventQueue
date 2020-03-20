using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticulateSplines : MonoBehaviour
{
    private bool m_IsQuitting;
    private bool m_IsLaunched = false;

    private void OnEnable()
    {
        EventBus.StartListening("Reticulate", Reticulate);
    }

    private void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    private void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Reticulate", Reticulate);
        }
    }

    void Reticulate()
    {
        if (m_IsLaunched == false)
        {
            m_IsLaunched = true;
            Debug.Log("Reticulating Splines");
        }
    }
}
