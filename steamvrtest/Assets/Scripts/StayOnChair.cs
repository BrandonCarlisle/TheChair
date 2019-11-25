using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnChair : MonoBehaviour
{
   // Throwable refScript = GetComponent<Throwable>();
    private GameObject[] chairHolster;
    // Start is called before the first frame update
    void Start()
    {
        chairHolster = GameObject.FindGameObjectsWithTag("chairHolster");
        this.transform.position = chairHolster[0].transform.position;
        this.transform.rotation = chairHolster[0].transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Gun.m_attachedHand == null)
        {
            this.transform.position = chairHolster[0].transform.position;
           // transform.rotation = Quaternion.LookRotation(transform.position - target.position);
            this.transform.rotation = chairHolster[0].transform.rotation;
            // this.transform.LookAt(2 * this.transform.position - stareat.position);
        }
    }
}
