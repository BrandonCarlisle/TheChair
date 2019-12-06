using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelGone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void disapear()
    {
        if (gameObject.CompareTag("Barrel"))
        {
            gameObject.SetActive(false);
        }
    }
}
