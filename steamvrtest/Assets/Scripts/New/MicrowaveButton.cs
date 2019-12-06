using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveButton : MonoBehaviour
{
    [SerializeField]
    private GameObject m_door;

    [SerializeField]
    private Vector3 m_rotationAxis;

    [SerializeField]
    private float m_rotationAngle;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Microwave Button Pressed by: " + other.gameObject.name + " - " + other.gameObject.tag);
        if (other.gameObject.tag == "Hand")
        {
            //Debug.Log("Microwave Button Pressed");
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        m_door.transform.Rotate(m_rotationAxis, m_rotationAngle);
    }
}
