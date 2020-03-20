using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            EventBus.TriggerEvent("Shoot");
        }

        if (Input.GetKeyDown("l"))
        {
            EventBus.TriggerEvent("Launch");
        }

        if (Input.GetKeyDown("r"))
        {
            EventBus.TriggerEvent("Rave");
        }
        if (Input.GetKeyDown("v"))
        {
            EventBus.TriggerEvent("Reticulate");
        }
        if (Input.GetKeyDown("e"))
        {
            EventBus.TriggerEvent("EventAction");
        }
    }
}
