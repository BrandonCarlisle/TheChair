using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager2Script : MonoBehaviour
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

    private int spawnsDisabled = 0;

    // Start is called before the first frame update
    void Start()
    {
        newState = false;
        events = eventManager.GetComponent<EventManager>();
        events.levelStateTrigger.AddListener(levelState);
        events.droneKilled.AddListener(droneKilled);
        events.spawnDisabled.AddListener(spawnDisabled);
        events.spawnEnabled.AddListener(spawnEnabled);
        events.buttonPressed.AddListener(ButtonTriggered);
        events.playerDeathTrigger.AddListener(PlayerDeath);

        var doorScript = door.GetComponent<doorOpenScript>();
        doorScript.doorToggle = true;
        ChangeLightColor(Color.red);

        events.changeBackgroundNoise.Invoke("background", .2f);
    }

    
    void PlayerDeath()
    {
        SceneManager.LoadScene(2);
    }

    void ButtonTriggered(int id)
    {
        if (id == 1 && state == 1)
        {

            levelState(2);
        }
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

    void droneKilled(int i)
    {
        levelState(3);
    }

    void spawnDisabled(int i)
    {
        if (i == 1)
            spawn1Disabled = true;

        if (i == 2)
            spawn2Disabled = true;

        if (spawn1Disabled && spawn2Disabled)
            levelState(4);

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
        else if (state == 3)
            State3();
        else if (state == 4)
            State4();
        else if (state == 5)
            State5();
        else if (state == 6)
            State6();
        else
            State7();
    }

    void State0()
    {
        
    }

    //entered room
    void State1()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("second1", 1f);
            newState = false;
        }
    }

    void State2()
    {
        if (newState)
        {
            events.spawnEnabled.Invoke(1);
            events.spawnEnabled.Invoke(2);
            newState = false;
        }
    }

    // 1st drone killed
    void State3()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("second2", 1f);
            newState = false;
        }
    }

    //spawners disabled
    void State4()
    {
        if (newState)
        {
            var doorScript = door.GetComponent<doorOpenScript>();
            doorScript.doorToggle = true;

            events.killDrones.Invoke();

            ChangeLightColor(Color.green);

            events.playVoiceLine.Invoke("second3", 1f);
            newState = false;
        }
    }

    //entered ele room
    void State5()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("second4", 1f);
            newState = false;
        }
    }

    //entered side room
    void State6()
    {
        if (newState)
        {
            events.changeBackgroundNoise.Invoke("horror", 1f);
            newState = false;
        }
    }


    //exit back to elevator
    void State7()
    {
        if (newState)
        {
            events.changeBackgroundNoise.Invoke("background", .2f);
            events.playVoiceLine.Invoke("powerOn", 1f);
            events.playVoiceLine.Invoke("second5", 1f);
            newState = false;
        }
    }
}
