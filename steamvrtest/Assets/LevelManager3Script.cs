using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager3Script : MonoBehaviour
{
    public GameObject player;
    public GameObject playerRespawn;

    public GameObject eventManager;
    public GameObject doorLight;
    public GameObject door;

    private EventManager events;

    public int state = 0;
    private bool newState = false;

    private bool spawn1Disabled = false;
    private bool spawn2Disabled = false;
    private bool boxPlaced = false;

    private int platformPos = 0;


    // Start is called before the first frame update
    void Start()
    {
        newState = false;
        events = eventManager.GetComponent<EventManager>();
        events.levelStateTrigger.AddListener(levelState);
        events.spawnDisabled.AddListener(spawnDisabled);
        events.spawnEnabled.AddListener(spawnEnabled);
        events.playerDeathTrigger.AddListener(PlayerDeath);

        events.boxPlaced.AddListener(BoxPlaced);
        events.boxRemoved.AddListener(BoxRemoved);

        events.shootButtonHit.AddListener(ShootButtonHit);

        var doorScript = door.GetComponent<doorOpenScript>();
        doorScript.doorToggle = true;
        ChangeLightColor(Color.red);

     
        events.changeBackgroundNoise.Invoke("background", .2f);
        events.platformMoveTrigger.Invoke(1, 1);
        events.shootColorSet.Invoke(1);

  
    }


    void ShootButtonHit(int id)
    {
        // if (platformPos == id)
        //return;
        Debug.Log("shoot " + id);
        events.platformMoveTrigger.Invoke(1, id);
        platformPos = id;

        events.shootColorSet.Invoke(id);
    }

    void BoxPlaced(int id)
    {
        if (id == 1)
            boxPlaced = true;

        CheckComplete();
    }

    void BoxRemoved(int id)
    {
        if (id == 1)
            boxPlaced = false;
    }


    void PlayerDeath()
    {
        SceneManager.LoadScene(3);
    }


    void ChangeLightColor(Color color)
    {
        var doorLightRender = doorLight.GetComponent<Renderer>();
        Material mat = doorLightRender.material;

        float emission = Mathf.PingPong(Time.time, 1.0f);
        Color baseColor = color;

        mat.SetColor("_EmissionColor", baseColor);
    }

    void levelState(int nextState)
    {
        if (state == nextState - 1)
        {
            state = nextState;
            newState = true;
            Debug.Log("entered State" + nextState);
        }
    }


    void spawnDisabled(int i)
    {
        if (i == 1)
            spawn1Disabled = true;

        if (i == 2)
            spawn2Disabled = true;

        CheckComplete();
    }

    void CheckComplete()
    {
        if (spawn1Disabled && spawn2Disabled && boxPlaced)
            levelState(2);
    }

    void spawnEnabled(int i)
    {
        if (i == 1)
            spawn1Disabled = false;

        if (i == 2)
            spawn2Disabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
            State0();
        else if (state == 1)
            State1();
        else if (state == 2)
            State2();
    }

    void State0()
    {

    }

    //entered room
    void State1()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("third1", 1f);
            events.spawnEnabled.Invoke(1);
            events.spawnEnabled.Invoke(2);
            newState = false;
        }
    }


    // level Complete
    void State2()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("third2", 1f);

            var doorScript = door.GetComponent<doorOpenScript>();
            doorScript.doorToggle = true;

            ChangeLightColor(Color.green);

            newState = false;
        }
    }

}
