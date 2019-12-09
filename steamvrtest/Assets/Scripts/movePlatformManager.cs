using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatformManager : MonoBehaviour
{
    public int moveLocation = 1;
    public GameObject initialButtonLocation;
    public GameObject bottomButtonLocation;
    public GameObject topButtonLocation;

    private Vector3 topLocation;
    private Vector3 initialLocation;
    private Vector3 bottomLocation;
    private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        topLocation = topButtonLocation.transform.position;
        initialLocation = initialButtonLocation.transform.position;
        bottomLocation = bottomButtonLocation.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        if (moveLocation == 0)
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position, bottomLocation, step);
            
        }
        else if (moveLocation == 1)
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position, initialLocation, step);

        }
        else if (moveLocation == 2)
        {

            this.transform.position = Vector3.MoveTowards(this.transform.position, topLocation, step);

        }
    }
}
