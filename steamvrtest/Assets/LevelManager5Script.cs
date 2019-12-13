using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager5Script : MonoBehaviour
{
    public GameObject player;

    public GameObject eventManager;


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
        events.playerDeathTrigger.AddListener(PlayerDeath);

        events.changeBackgroundNoise.Invoke("background", .2f);
    }


    void PlayerDeath()
    {
        SceneManager.LoadScene(5);
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
    }

    void State0()
    {

    }

    //entered Rooftop
    void State1()
    {
        if (newState)
        {
            events.changeBackgroundNoise.Invoke("wind", .2f);
            newState = false;
        }
    }

    //Jumped
    void State2()
    {
        if (newState)
        {
            events.changeBackgroundNoise.Invoke("horror", .5f);
            newState = false;
        }
    }

}
