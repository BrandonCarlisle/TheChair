using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField]
    private float m_speed;

    private int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1,5);
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * m_speed * randomNumber;
    }

    void Update()
    {
    }
}
