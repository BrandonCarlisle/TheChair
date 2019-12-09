﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class SpawnBall : MonoBehaviour
{
    public Transform prefab;
    private int hasBeenPressed = 0;
    public GameObject spawnLocation;
    public bool shouldSpawn = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        // print("Detected collision between " + gameObject.name + " and " + collision.gameObject.name);
        //if (collision.gameObject == leftHand || collision.gameObject == rightHand)
        if (collision.collider.tag == "projectile")
        {
            if (hasBeenPressed >= 2)
            {
                Instantiate(prefab, /*new Vector3(-6.73f, 8.486f, 2.297f)*/spawnLocation.transform.position, Quaternion.identity);
                Debug.Log("------------Button Pressed by projectile");
            }
            else
            {
                hasBeenPressed++;
            }
        }
        else if (collision.collider.tag == "Hand")
        {
            if (shouldSpawn)
            {
                Instantiate(prefab, spawnLocation.transform.position, Quaternion.identity);
                Debug.Log("------------Button Pressed by hand");
                shouldSpawn = false;
            }
            else
            {

            }
       }
    }
}
