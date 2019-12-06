using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceKeyHole : MonoBehaviour
{
    [SerializeField]
    private GameObject m_door;

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
        }
    }

    void OpenDoor()
    {
        m_door.gameObject.SetActive(false);
    }
}
