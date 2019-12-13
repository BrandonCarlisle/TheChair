using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager1Script : MonoBehaviour
{
    public GameObject player;
    public GameObject playerRespawn;

    public GameObject eventManager;
    public GameObject doorLight;
    public GameObject door;

    private EventManager events;

    public int state = 0;
    private bool newState = false;


    private bool boxPlaced = false;

    private int platformPos = 0;


    // Start is called before the first frame update
    void Start()
    {
        newState = false;
        events = eventManager.GetComponent<EventManager>();
        events.levelStateTrigger.AddListener(levelState);
        events.playerDeathTrigger.AddListener(PlayerDeath);
        events.buttonPressed.AddListener(ButtonPressed);

        events.boxPlaced.AddListener(BoxPlaced);
        events.boxRemoved.AddListener(BoxRemoved);

        events.shootButtonHit.AddListener(ShootButtonHit);

        var doorScript = door.GetComponent<doorOpenScript>();
        doorScript.doorToggle = true;
        ChangeLightColor(Color.red);

        events.shootColorSet.Invoke(1);
        // events.changeBackgroundNoise.Invoke("background", .2f);
        events.platformMoveTrigger.Invoke(0, 1);
        events.platformMoveTrigger.Invoke(2, 0);
        events.platformMoveTrigger.Invoke(3, 1);

    }

    void BoxPlaced(int id)
    {
        if (state == 3)
        {
            events.platformMoveTrigger.Invoke(id, 0);
            levelState(4);
        }
        else if (state == 4)
        {
            if (id == 2)
            {
                events.platformMoveTrigger.Invoke(id, 1);
            }
        }
    }

    void BoxRemoved(int id)
    {
        if (state == 4)
        {
            if (id == 2)
            {
                events.platformMoveTrigger.Invoke(id, 0);
            }
            else if (id == 3)
            {
                levelState(5);
            }
        }
    } 

    void ButtonPressed(int id)
    {
        levelState(2);
    }


    void ShootButtonHit(int id)
    {
        events.shootColorSet.Invoke(id);

        if (state == 2)
            levelState(3);

        if (state > 3)
        {
            events.platformMoveTrigger.Invoke(3, id);
        }
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

    }

    void State0()
    {

    }

    //entered Game
    void State1()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("introMain", 1f);
            newState = false;
        }
    }

    //Button Pressed
    void State2()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("intro5", 1f);
            newState = false;
        }
    }

    //Shoot Button Shot
    void State3()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("intro6", 1f);
            newState = false;
        }
    }

    //boxPlaced
    void State4()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("joke1b", 1f);
            newState = false;
        }
    }

    //Level Completed
    void State5()
    {
        var doorScript = door.GetComponent<doorOpenScript>();
        doorScript.doorToggle = true;

        ChangeLightColor(Color.green);

        newState = false;
    }


}
