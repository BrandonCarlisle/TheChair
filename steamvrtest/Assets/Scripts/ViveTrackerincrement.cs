using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveTrackerincrement : MonoBehaviour
{
    public GameObject chair;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = chair.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
