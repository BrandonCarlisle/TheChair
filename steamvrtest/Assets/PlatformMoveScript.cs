using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveScript : MonoBehaviour
{
    public GameObject eventManager;
    private EventManager events;

    public float traverseSpeed = 3f;

    private bool moving = false;
    private int moveTo = 0;

    public List<GameObject> movePoints;
    // Start is called before the first frame update
    void Start()
    {
        events = eventManager.GetComponent<EventManager>();
        events.platformMoveTrigger.AddListener(StartMove);
    }

    void StartMove(int id, int index)
    {
        MoveTo(index);
    }


    void MoveTo(int index)
    {
     

        Debug.Log("moveHit");

        var movingTo = movePoints[index];
        moveTo = index;

        moving = true;
        float step = traverseSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movingTo.transform.position, step);

        if (Vector3.Distance(transform.position, movingTo.transform.position) < 0.001f)
        {
            moving = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("onEnter");
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "AIDrone")
        {
            Debug.Log("playerSet");
            other.transform.parent = transform;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "AIDrone")
        {
            other.transform.parent = null;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            MoveTo(moveTo);
        }
    }
}
