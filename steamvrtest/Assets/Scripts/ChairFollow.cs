using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairFollow : MonoBehaviour
{

    public GameObject player;
    public GameObject tracker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = tracker.transform.rotation;
        rotation.x = 0;
        rotation.z = 0;
        //Vector3 look = player.transform.rotation;
        this.transform.position = player.transform.position;
        this.transform.rotation = rotation;
        
        //this.transform.Rotate(0, player.transform.postion.y,)
    }
}
