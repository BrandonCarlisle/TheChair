using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    [SerializeField]
    private GameObject m_door;

    [SerializeField]
    private Vector3 m_rotationAxis;

    [SerializeField]
    private float m_rotationAngle;

    [SerializeField]
    private GameObject m_key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == m_key)
        {
            OpenDoor();
            //m_key.gameObject.SetActive(false);
        }
    }

    void OpenDoor()
    {
        m_door.transform.Rotate(m_rotationAxis, m_rotationAngle);
    }
}
