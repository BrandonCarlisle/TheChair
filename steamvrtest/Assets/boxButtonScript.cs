using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxButtonScript : MonoBehaviour
{
    public GameObject eventManager;
    private EventManager events;

    public int boxPlaceID = 0;

    // Start is called before the first frame update
    void Start()
    {
        events = eventManager.GetComponent<EventManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "boxItem")
        {
            CheckState(collider);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "boxItem")
        {
            CheckState(collider);
        }
    }

    private void CheckState(Collider collider)
    {
        var spawnCol = gameObject.GetComponent<BoxCollider>();
        if (spawnCol.bounds.Intersects(collider.bounds))
        {
            var childrends = gameObject.GetComponentsInChildren<Renderer>();
            foreach (var childrend in childrends)
            {
                events.boxPlaced.Invoke(boxPlaceID);
                events.playSoundAt.Invoke("placedOn", .5f, gameObject.transform.position);
                childrend.material.color = Color.green;
            }
        }
        else
        {
            var childrends = gameObject.GetComponentsInChildren<Renderer>();
            foreach (var childrend in childrends)
            {
                events.boxRemoved.Invoke(boxPlaceID);
                events.playSoundAt.Invoke("placedOff", .5f, gameObject.transform.position);
                childrend.material.color = Color.red;
            }

        }
    }

}
