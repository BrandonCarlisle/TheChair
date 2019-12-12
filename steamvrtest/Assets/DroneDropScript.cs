using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DroneDropScript : MonoBehaviour
{
    public GameObject eventManager;
    private EventManager events;

    public int spawnerID = 0;

    // Start is called before the first frame update
    void Start()
    {
        events = eventManager.GetComponent<EventManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "AIDrone")
        {
            CheckState(collider);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "AIDrone")
        {        
            CheckState(collider);
        }
    }

    
    private void CheckState(Collider collider)
    {
        var spawnCol = gameObject.GetComponent<BoxCollider>();
        if (spawnCol.bounds.Intersects(collider.bounds))
        {
            events.spawnDisabled.Invoke(spawnerID);
            events.playSoundAt.Invoke("placedOn", .5f, gameObject.transform.position);
            var childrends = gameObject.GetComponentsInChildren<Renderer>();
            foreach (var childrend in childrends)
            {
                childrend.material.color = Color.green;
            }
        }
        else
        {
            events.spawnEnabled.Invoke(spawnerID);
            events.playSoundAt.Invoke("placedOff", .5f, gameObject.transform.position);
            var childrends = gameObject.GetComponentsInChildren<Renderer>();
            foreach (var childrend in childrends)
            {
                childrend.material.color = Color.red;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
       // var events = eventManager.GetComponent<EventManagerL2>();
       // events.spawnDisabled.Invoke(spawnerID);
    }
}
