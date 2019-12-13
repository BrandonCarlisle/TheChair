using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class SpawnBall : MonoBehaviour
{
    public GameObject eventManager;
    private EventManager events;

    public Transform prefab;
    private int hasBeenPressed = 0;
    public GameObject spawnLocation;
    public bool shouldSpawn = true;

    private GameObject spawnedObj;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        events = eventManager.GetComponent<EventManager>();
        events.shootColorSet.AddListener(ShootColorSet);
    }

    void ShootColorSet(int id)
    {
        var render = gameObject.GetComponent<Renderer>();
        render.material.color = Color.green;
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
            if (!shouldSpawn)
                return;
            if (hasBeenPressed == 0)
            {
                Instantiate(prefab, /*new Vector3(-6.73f, 8.486f, 2.297f)*/spawnLocation.transform.position, Quaternion.identity);
                // Debug.Log("------------Button Pressed by projectile");
                events.shootButtonHit.Invoke(-1);
                shouldSpawn = false;
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
                spawnedObj = Instantiate(prefab, spawnLocation.transform.position, Quaternion.identity).gameObject;
                
               // Debug.Log("------------Button Pressed by hand");
                shouldSpawn = false;
            }
            else
            {
               // spawnedObj.transform.position = spawnLocation.transform.position;
            }
       }
    }
}
