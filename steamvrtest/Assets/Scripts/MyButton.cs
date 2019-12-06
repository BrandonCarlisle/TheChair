using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class MyButton : MonoBehaviour
{
    public Transform prefab;
    private bool hasBeenPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       // print("Detected collision between " + gameObject.name + " and " + collision.gameObject.name);
        //if (collision.gameObject == leftHand || collision.gameObject == rightHand)
        if (collision.collider.tag == "Hand" && hasBeenPressed == false)
        {
            hasBeenPressed = true;
            var obj = Instantiate(prefab, new Vector3(-6.600503f, 8.054f, 2.155f), Quaternion.identity);
            
            Debug.Log("------------Button Pressed by Hand");
        }
    }
}
