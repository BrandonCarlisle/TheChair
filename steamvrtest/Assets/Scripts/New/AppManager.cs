using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    [SerializeField]
    public UnityEngine.Events.UnityEvent IntroTrigger;

    [SerializeField]
    public UnityEngine.Events.UnityEvent EndTrigger;

    bool foundFirstNumber = false;
    bool lookingForFirst = false;

    bool foundSecondNumber = false;
    bool lookingForSecond = false;

    bool foundThirdNumber = false;
    bool lookingForThird = false;

    bool foundFourthNumber = false;
    bool lookingForFourth = false;

    bool finished = false;
    
    public void FoundFirst()
    {
        foundFirstNumber = true;
    }

    public void FoundSecond()
    {
        foundSecondNumber = true;
    }

    public void FoundThird()
    {
        foundThirdNumber = true;
    }

    public void FoundFourth()
    {
        foundFourthNumber = true;
    }

    public void Finish()
    {
        finished = true;
    }

    void Update()
    {
        if(!foundFirstNumber && lookingForFirst)
        {
            //InvokeRepeating("PlaySound", 10.0f, 10.0f);
        }

        if(finished)
        {
            CancelInvoke();
        }
    }

    private void PlaySound()
    {
    }
}
