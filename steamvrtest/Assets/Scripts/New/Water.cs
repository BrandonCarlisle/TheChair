using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    private GameObject m_waterGlass;

    [SerializeField]
    private GameObject m_fire;

    [SerializeField]
    private GameObject m_number;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fireplace")
        {
            m_waterGlass.SetActive(false);
            m_fire.SetActive(false);
            m_number.SetActive(true);
        }
    }
}
