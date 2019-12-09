using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatformBottom : MonoBehaviour
{
    public movePlatformManager manager;
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "projectile")
        {
            Debug.Log("Bottom Button Pressed");
            manager.moveLocation = 0;

        }
    }
}
