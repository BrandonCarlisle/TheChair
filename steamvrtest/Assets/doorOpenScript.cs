using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpenScript : MonoBehaviour
{
    public GameObject topHalf;

    public GameObject topOpen;
    public GameObject topClose;


    private bool open = true;
    public bool doorToggle = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (doorToggle)
        {
            if (!open)
            {
                float step = 2f * Time.deltaTime;
                topHalf.transform.position = Vector3.MoveTowards(topHalf.transform.position, topOpen.transform.position, step);

                if (Vector3.Distance(topHalf.transform.position, topOpen.transform.position) < 0.001f)
                {
                    doorToggle = false;
                    open = true;
                }              
            }
            else
            {
                float step = 2f * Time.deltaTime;
                topHalf.transform.position = Vector3.MoveTowards(topHalf.transform.position, topClose.transform.position, step);


                if (Vector3.Distance(topHalf.transform.position, topClose.transform.position) < 0.001f)
                {
                    doorToggle = false;
                    open = false;
                }

            }
        }
    }
}
