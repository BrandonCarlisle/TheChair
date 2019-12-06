using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class ToggleSteamVRLaser : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Boolean m_toggleAction;

    [SerializeField]
    private SteamVR_Input_Sources m_controller;

    private SteamVR_LaserPointer laserPointer;

    // Start is called before the first frame update
    void Start()
    {
        m_toggleAction.AddOnStateDownListener(Toggle, m_controller);
    }

    // Update is called once per frame
    private void Toggle(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        laserPointer = this.GetComponent<SteamVR_LaserPointer>();
        laserPointer.enabled = !laserPointer.enabled;
    }
}
