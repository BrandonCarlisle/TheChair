using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveScript : MonoBehaviour
{
    public GameObject eventManager;
    private EventManager events;

    public int platformID = 0;
    public float traverseSpeed = 3f;

    public bool attachObjects = true;

    private bool moving = false;
    private bool soundStart = false;
    private int moveTo = 0;

   // private AudioSource audio;

    public List<GameObject> movePoints;
    // Start is called before the first frame update
    void Start()
    {
        //audio = gameObject.GetComponent<AudioSource>();
        //audio.volume = 0;

        events = eventManager.GetComponent<EventManager>();
        events.platformMoveTrigger.AddListener(StartMove);
    }

    void StartMove(int id, int index)
    {
        if (id == platformID)
            MoveTo(index);
    }


    void MoveTo(int index)
    {
      
        var movingTo = movePoints[index];
        moveTo = index;

        moving = true;
        float step = traverseSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movingTo.transform.position, step);

        if (!soundStart)
        {
            //if (audio != null)
            //{
            //    audio.volume = .05f;
            //}
            soundStart = true;
        }

        if (Vector3.Distance(transform.position, movingTo.transform.position) < 0.001f)
        {
            //if (audio != null)
            //{
            //    audio.volume = .0f;
            //    soundStart = false;
            //}
            moving = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!attachObjects)
            return;

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "AIDrone" || other.gameObject.tag == "boxParent")
        {
            other.transform.parent = transform;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (!attachObjects)
            return;

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "AIDrone" || other.gameObject.tag == "boxParent")
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
