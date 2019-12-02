using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShootScript : MonoBehaviour
{
    public GameObject shootFrom;
    public GameObject projectileType;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        //var proj = Instantiate(projectileType, shootFrom.transform.position, Quaternion.identity);
     
    }
}
