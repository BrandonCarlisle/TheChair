using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeManagerScript : MonoBehaviour
{
    public float small = 1;
    public float large = 2;

    public void makeSmall()
    {
        gameObject.transform.localScale = new Vector3(small, small, small);
    }

    public void makeBig()
    {
        gameObject.transform.localScale = new Vector3(large, large, large);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
