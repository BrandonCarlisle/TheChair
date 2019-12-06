using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGlass : MonoBehaviour
{
    [SerializeField]
    private GameObject m_water;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Glass")
        {
            m_water.SetActive(true);
        }
    }
}
