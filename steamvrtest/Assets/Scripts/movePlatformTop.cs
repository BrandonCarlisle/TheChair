using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatformTop : MonoBehaviour
{
    public movePlatformManager manager;
    public SpawnBall ballSpawn;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "projectile")
        {
            Debug.Log("Top Button Pressed");
            ballSpawn.shouldSpawn = true;
            manager.moveLocation = 2;

        }
    }
}
