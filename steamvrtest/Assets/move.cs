using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    
    public GameObject spawner;
    Vector3 movefloor;
    Vector3 movespawner;

    float max = 10.4f;
    float start = 0.0f;
  // Start is called before the first frame update
  void Start()
    {
      //  start = this.transform.position.y;
       // movefloor = transform.position;
       // movespawner = spawner.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //movefloor.y += .01f;
        //this.transform.position= movefloor;
        //spawner.transform.position = movespawner;
        
        if (start < max)
        {
            this.transform.position = this.transform.position + new Vector3(0, 0.01f, 0);
            spawner.transform.position = spawner.transform.position + new Vector3(0, 0.01f, 0);
            start += 0.01f;
        }
        else
        {

        }

    }
}
