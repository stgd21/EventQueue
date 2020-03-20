using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private bool m_IsQuitting;

    private void OnEnable()
    {
        EventBus.StartListening("Shoot", Shoot);
    }

    private void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    private void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Shoot", Shoot);
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot event firing form cannon");
    }
}
