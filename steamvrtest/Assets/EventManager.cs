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

[System.Serializable]
public class MySoundEvent : UnityEvent<string, float>
{
}

[System.Serializable]
public class MainAudioChangeEvent : UnityEvent<string, float>
{
}

[System.Serializable]
public class MySoundAtEvent : UnityEvent<string, float, Vector3>
{
}

[System.Serializable]
public class PlatformMoveEvent : UnityEvent<int, int>
{
}


public class EventManager : MonoBehaviour
{
    public MyIntEvent levelStateTrigger;
    public MyIntEvent spawnKilled;
    public MyIntEvent spawnEnabled;
    public MyIntEvent spawnDisabled;
    public MyIntEvent droneKilled;
    public UnityEvent killDrones;
    public UnityEvent playerDeathTrigger;
    public MyIntEvent boxPlaced;
    public MyIntEvent boxRemoved;

    public MyIntEvent shootColorSet;


    public MyIntEvent shootButtonHit;
    public PlatformMoveEvent platformMoveTrigger;


    public MyIntEvent buttonPressed;

    public MySoundAtEvent playSoundAt;
    public MySoundEvent playVoiceLine;
    public MainAudioChangeEvent changeBackgroundNoise;
    public MainAudioChangeEvent changeSecondaryNoise;
   

    // Start is called before the first frame update
    void Start()
    {
        if (levelStateTrigger == null)
            levelStateTrigger = new MyIntEvent();
        if (spawnKilled == null)
            spawnKilled = new MyIntEvent();
        if (spawnDisabled == null)
            spawnDisabled = new MyIntEvent();
        if (spawnEnabled == null)
            spawnEnabled = new MyIntEvent();
        if (droneKilled == null)
            droneKilled = new MyIntEvent();
        if (killDrones == null)
            killDrones = new UnityEvent();

        if (boxPlaced == null)
            boxPlaced = new MyIntEvent();
        if (boxRemoved == null)
            boxRemoved = new MyIntEvent();

        if (shootColorSet == null)
            shootColorSet = new MyIntEvent();

        if (shootButtonHit == null)
            shootButtonHit = new MyIntEvent();
        if (platformMoveTrigger == null)
            platformMoveTrigger = new PlatformMoveEvent();

        if (playerDeathTrigger == null)
            playerDeathTrigger = new UnityEvent();

        if (buttonPressed == null)
            buttonPressed = new MyIntEvent();

        if (playSoundAt == null)
            playSoundAt = new MySoundAtEvent();
        if (playVoiceLine == null)
            playVoiceLine = new MySoundEvent();
        if (changeBackgroundNoise == null)
            changeBackgroundNoise = new MainAudioChangeEvent();
        if (changeSecondaryNoise == null)
            changeSecondaryNoise = new MainAudioChangeEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
