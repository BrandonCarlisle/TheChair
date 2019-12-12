using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class dronespawnscript : MonoBehaviour
{

    public GameObject eventManager;
    private EventManager events;

    public GameObject spawnObj;
    public GameObject spawnPos;

    public int spawnerID = 0;
    public float spawnTime = 30f;
    public bool isDisabled = true;
    private float spawnCheckTimer = 0f;
    public float initalDelay = 0f;

    private bool spawnReady = true;

    // Start is called before the first frame update
    void Start()
    {
        var droneScript = spawnObj.GetComponent<DroneScript>();
        droneScript.spawnerID = spawnerID;
        droneScript.isDead = false;

        events = eventManager.GetComponent<EventManager>();   
        events.spawnKilled.AddListener(Killed);
        events.spawnDisabled.AddListener(Disabled);
        events.spawnEnabled.AddListener(Enabled);

        if (!isDisabled)
            Spawn();
        else
            spawnCheckTimer = spawnTime;

    }

    void Spawn()
    {
        //spawn new
        GameObject drone = Instantiate(spawnObj, spawnPos.transform.position, spawnPos.transform.rotation) as GameObject;
        spawnCheckTimer = 0f;
        spawnReady = false;
    }

    void Killed(int id)
    {
        if (spawnerID == id)
        {
            events.droneKilled.Invoke(1);
            spawnReady = true;
        }
            
    }

    void Disabled(int id)
    {
        if (spawnerID == id)
        {
            isDisabled = true;
        }
            
    }

    void Enabled(int id)
    {
        if (spawnerID == id)
            isDisabled = false;
        spawnCheckTimer -= initalDelay;
    }

    // Update is called once per frame
    void Update()
    {     
        if (isDisabled)
            return;
     
        if (spawnReady)
        {
            spawnCheckTimer += Time.deltaTime;
            if (spawnCheckTimer >= spawnTime)
                Spawn();
        }
    }
}
