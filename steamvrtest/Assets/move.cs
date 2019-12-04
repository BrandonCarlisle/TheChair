using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public bool shouldMoveUp;
    float max;
    float start;
    float current;

  // Start is called before the first frame update
  void Start()
    {
        start = this.transform.position.y;
        current = start;
        max = 11f + start;
    }

    // Update is called once per frame
    void Update()
    {
  
        if (current < max && shouldMoveUp)
        {
            this.transform.position = this.transform.position + new Vector3(0, 0.01f, 0);
            current += 0.01f;
        }
        else if(current > start && !shouldMoveUp)
        {
            this.transform.position = this.transform.position + new Vector3(0, -0.01f, 0);
            current -= 0.01f;
        }

    }
}
