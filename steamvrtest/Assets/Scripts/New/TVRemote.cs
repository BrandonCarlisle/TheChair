using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class TVRemote : MonoBehaviour
{
    [Tooltip("Game Object to set active")]
    [SerializeField]
    private GameObject m_gameObject = null;

    //Used to hold attached hand to gun
    private Hand m_attachedHand = null;

    //Used to handle which hand is holding gun
    private SteamVR_Input_Sources m_controller;

    //Used to handle if gun shootable or not
    private bool usable = false;

    // Update is called once per frame
    void Update()
    {
        //Chack to see if Player is holding the gun, so so it is shootable
        if (m_attachedHand != null)
        {
            usable = true;
        }
        else
        {
            usable = false;
        }

        //If shootable, then check to see if attached controller's trigger is pressed
        if (usable && m_attachedHand.grabPinchAction.GetStateDown(m_controller))
        {
            //Shoot the bullet!
            Debug.Log("Remote Trigger Pressed!");
            m_gameObject.SetActive(true);
        }
    }

    //Set attached hand assign left or right
    private void OnAttachedToHand(Hand attachedHand)
    {
        m_attachedHand = attachedHand;
        m_controller = attachedHand.handType;
    }

    //Reset attached hand
    private void OnDetachedFromHand(Hand hand)
    {
        m_attachedHand = null;
    }

}
