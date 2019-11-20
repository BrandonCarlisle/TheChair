using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Gun : MonoBehaviour
{
    [Tooltip("Set bullet prefab")]
    [SerializeField]
    private GameObject m_bulletPrefab = null;

    [Tooltip("Set bullet spawn location")]
    [SerializeField]
    private Transform m_bulletSpawnLocation = null;

    [Tooltip("Set speed of the bullet")]
    [SerializeField]
    private float m_bulletSpeed = 1.0f;

    [Tooltip("How long in seconds the bullet will fly for.")]
    [SerializeField]
    private float m_bulletTravelTime = 1.0f;

    [Tooltip("What sound will play when the trigger is pressed.")]
    [SerializeField]
    private AudioSource m_bulletSound = null;

    //Used to hold attached hand to gun
    private Hand m_attachedHand = null;

    //Used to handle which hand is holding gun
    private SteamVR_Input_Sources m_controller;

    //Used to handle if gun shootable or not
    private bool shootable = false;

    // Update is called once per frame
    void Update()
    {
        //Chack to see if Player is holding the gun, so so it is shootable
        if (m_attachedHand != null)
        {
            shootable = true;
        }
        else
        {
            shootable = false;
        }

        //If shootable, then check to see if attached controller's trigger is pressed
        if(shootable && m_attachedHand.grabPinchAction.GetStateDown(m_controller))
        {
            //Shoot the bullet!
            //Debug.Log("Gun Trigger Pressed!");
            GameObject bullet = Instantiate(m_bulletPrefab, m_bulletSpawnLocation.position, m_bulletSpawnLocation.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = -(bullet.transform.forward * m_bulletSpeed);
            //bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * m_bulletSpeed);

            m_bulletSound.Play();

            Destroy(bullet, m_bulletTravelTime);
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
