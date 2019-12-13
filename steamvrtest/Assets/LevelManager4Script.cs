using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager4Script : MonoBehaviour
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
        events.playerDeathTrigger.AddListener(PlayerDeath);
        events.spawnKilled.AddListener(DroneKilled);

        events.shootButtonHit.AddListener(ShootButtonHit);

        var doorScript = door.GetComponent<doorOpenScript>();
        doorScript.doorToggle = true;
        ChangeLightColor(Color.red);


        events.changeBackgroundNoise.Invoke("background", .2f);
    }


    void DroneKilled(int id)
    {
        levelState(4);
    }

    void ShootButtonHit(int id)
    {
        events.shootColorSet.Invoke(id);

        levelState(3);
    }



    void PlayerDeath()
    {
        SceneManager.LoadScene(4);
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

        levelState(6);
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
        else if (state == 3)
            State3();
        else if (state == 4)
            State4();
    }

    void State0()
    {

    }

    //entered room
    void State1()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("fourth1", 1f);
            newState = false;
        }
    }

    //entered side room
    void State2()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("fourth2", 1f);
            events.changeBackgroundNoise.Invoke("alarm", .15f);
            newState = false;
        }
    }


    //boxroom Complete
    void State3()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("fourth3", 1f);
            var doorScript = door.GetComponent<doorOpenScript>();
            doorScript.doorToggle = true;
            newState = false;
        }
    }


    // level Complete
    void State4()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("fourth4", 1f);
            newState = false;
        }
    }
}
