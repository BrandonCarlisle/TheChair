using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneLaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 200.0f;
    private float timer = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
            Destroy(gameObject);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
