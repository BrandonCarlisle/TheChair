using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3Zone1 : MonoBehaviour
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
            events.levelStateTrigger.Invoke(1);
        }
    }
}
