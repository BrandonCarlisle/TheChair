using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveWallDown()
    {
        Debug.Log("wall moving down");
        for(int i = 0; i < 500000; i++)
        {
            Vector3 pos = this.transform.position;
            pos.y -= .001f;
            this.transform.position = pos;
        }


    }
}
