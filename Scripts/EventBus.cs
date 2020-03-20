using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : Singleton<EventBus>
{
    private Dictionary<string, UnityEvent> m_EventDictionary;

    //ring buffer stuff
    private static int head;
    private static int tail;
    private static UnityEvent[] pending;
    private static int MAX_PENDING = 20;

    private float lastEventFiringTime = 0f;
    private float eventSpacingTime = 1f;

    public override void Awake()
    {
        head = 0;
        tail = 0;
        pending = new UnityEvent[MAX_PENDING];
        base.Awake();
        Instance.Init();
    }

    private void Init()
    {
        if (Instance.m_EventDictionary == null)
        {
            Instance.m_EventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out thisEvent))
        {
            pending[tail] = thisEvent;
            tail = (tail + 1) % MAX_PENDING;
            //thisEvent.Invoke();
        }
    }

    private void Update()
    {
        //If no pending requests, do nothing
        if (head == tail)
            return;

        //Space out the execution of events
        if (Time.time - lastEventFiringTime > eventSpacingTime)
        {
            lastEventFiringTime = Time.time;
            pending[head].Invoke();
            head = (head + 1) % MAX_PENDING;
        }
    }
}
