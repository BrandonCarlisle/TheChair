using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPressed : MonoBehaviour
{
    public GameObject eventManager;
    private EventManager events;

    public int buttonID;

    // Start is called before the first frame update
    void Start()
    {
        events = eventManager.GetComponent<EventManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Hand")
        {
            events.playVoiceLine.Invoke("buttonPress", .7f);
            events.buttonPressed.Invoke(buttonID);
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Hand")
        {
            events.playVoiceLine.Invoke("buttonPress", .7f);
            events.buttonPressed.Invoke(buttonID);
        }
    }
}
