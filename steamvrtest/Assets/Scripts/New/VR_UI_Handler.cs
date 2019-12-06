using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class VR_UI_Handler : MonoBehaviour
{
    public SteamVR_LaserPointer rightLasterPointer;

    public SteamVR_LaserPointer leftLaserPointer;

    void Awake()
    {
        rightLasterPointer.PointerIn += PointerInside;
        rightLasterPointer.PointerOut += PointerOutside;
        rightLasterPointer.PointerClick += PointerClick;

        leftLaserPointer.PointerIn += PointerInside;
        leftLaserPointer.PointerOut += PointerOutside;
        leftLaserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        Debug.Log(e.target.name + " was Clicked");
        e.target.GetComponent<Button>().onClick.Invoke();
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        Debug.Log(e.target.name + " was Entered");
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        Debug.Log(e.target.name + " was Exited");
    }
}