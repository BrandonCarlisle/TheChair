using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatformMiddle : MonoBehaviour
{
    public movePlatformManager manager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "projectile")
        {
            Debug.Log("Middle Button Pressed");

            manager.moveLocation = 1;

        }
    }
}
