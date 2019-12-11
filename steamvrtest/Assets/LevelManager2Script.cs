using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager2Script : MonoBehaviour
{
    public GameObject eventManager;

    private EventManager events;

    public int state = 0;
    private bool newState = false;

    private int spawnsDisabled = 0;

    // Start is called before the first frame update
    void Start()
    {
        newState = false;
        events = eventManager.GetComponent<EventManager>();
        events.levelStateTrigger.AddListener(levelState);
        events.droneKilled.AddListener(droneKilled);
        events.spawnDisabled.AddListener(spawnDisabled);
        events.spawnRenabled.AddListener(spawnRenabled);
    }

    void levelState(int nextState)
    {
        if (state == nextState - 1)
        {
            state = nextState;
            newState = true;
            Debug.Log("entered State " + nextState);
        }
    }

    void droneKilled(int i)
    {
        levelState(2);
    }

    void spawnDisabled(int i)
    {
        spawnsDisabled += 1;
        if (spawnsDisabled == 2)
        {
            levelState(3);
        }
    }

    void spawnRenabled(int i)
    {
        if (state < 3)
        {
            spawnsDisabled -= 1;
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
        else
            State6();
    }

    void State0()
    {
        
    }

    //entered room
    void State1()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("second1");
            newState = false;
        }
    }

    // 1st drone killed
    void State2()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("second2");
            newState = false;
        }
    }

    //spawners disabled
    void State3()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("second3");
            newState = false;
        }
    }

    //entered ele room
    void State4()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("second4");
            newState = false;
        }
    }

    //entered side room
    void State5()
    {
        if (newState)
        {

            newState = false;
        }
    }


    //exit back to elevator
    void State6()
    {
        if (newState)
        {
            events.playVoiceLine.Invoke("second5");
            newState = false;
        }
    }
}
