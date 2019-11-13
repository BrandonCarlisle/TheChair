using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public GameObject moveObject;
    public float moveSpeed = 0f;
    public float rotateSpeed = 0f;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
       rigidBody = moveObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.W))
        {
            moveObject.transform.Translate((Vector3.forward * moveSpeed) * Time.deltaTime);
           
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveObject.transform.Translate(-((Vector3.forward * moveSpeed) * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveObject.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveObject.transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed, Space.World);
        }
    }
}
