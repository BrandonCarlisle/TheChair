using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startNewScene : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Hand")
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(++scene);

        }
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Hand")
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(++scene);
        }
    }
}
