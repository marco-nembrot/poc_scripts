using UnityEngine;
using UnityEngine.EventSystems;


public class CustomEvent : MonoBehaviour
{


    protected void Start()
    {
        if (GetComponent<EventTrigger>())
        {
            EventTrigger trigger = GetComponent<EventTrigger>();
            // Adding Pointer Down
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry);
            // Adding Pointer Enter
            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { OnPointerEnterDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry);
            // Adding Pointer Enter
            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerExit;
            entry.callback.AddListener((data) => { OnPointerExitDelegate((PointerEventData)data); });
            trigger.triggers.Add(entry);
        }
    }



    public virtual void OnPointerDownDelegate(PointerEventData data)
    {
        Debug.Log("OnPointerDownDelegate called.");
    }

    public virtual void OnPointerEnterDelegate(PointerEventData data)
    {
        Debug.Log("OnPointerEnterDelegate called.");
    }

    public virtual void OnPointerExitDelegate(PointerEventData data)
    {
        Debug.Log("OnPointerExitDelegate called.");
    }
}