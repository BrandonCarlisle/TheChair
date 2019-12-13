using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L5Zone2 : MonoBehaviour
{
    public GameObject eventManager;
    private EventManager events;

    // Start is called before the first frame update
    void Start()
    {
        events = eventManager.GetComponent<EventManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            events.levelStateTrigger.Invoke(2);
        }
    }
}
