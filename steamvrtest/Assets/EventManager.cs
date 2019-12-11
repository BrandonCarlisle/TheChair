using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}

[System.Serializable]
public class MyStringEvent : UnityEvent<string>
{
}

[System.Serializable]
public class MyPositionEvent : UnityEvent<string, Vector3>
{
}


public class EventManager : MonoBehaviour
{
    public MyIntEvent levelStateTrigger;
    public MyIntEvent spawnKilled;
    public MyIntEvent spawnDisabled;
    public MyIntEvent droneKilled;
    public MyIntEvent spawnRenabled;

    public MyPositionEvent playSoundAt;
    public MyStringEvent playVoiceLine;

    // Start is called before the first frame update
    void Start()
    {
        if (levelStateTrigger == null)
            levelStateTrigger = new MyIntEvent();
        if (spawnKilled == null)
            spawnKilled = new MyIntEvent();
        if (spawnDisabled == null)
            spawnDisabled = new MyIntEvent();
        if (droneKilled == null)
            droneKilled = new MyIntEvent();
        if (spawnRenabled == null)
            spawnRenabled = new MyIntEvent();

        if (playSoundAt == null)
            playSoundAt = new MyPositionEvent();
        if (playVoiceLine == null)
            playVoiceLine = new MyStringEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
