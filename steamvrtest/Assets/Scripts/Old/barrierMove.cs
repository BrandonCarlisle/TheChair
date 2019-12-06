using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierMove : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveUp()
    {
        if (gameObject.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
    }
}
