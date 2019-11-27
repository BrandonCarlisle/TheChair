using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlaceScript : MonoBehaviour
{
    // private bool hasBeenPlaced = false;
    private bool moveWall = false;
    //ReferencedScript wallMove = 
    //public moveWall wallscript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveWall)
        {
            Vector3 pos = moveableWall[0].transform.position;
            pos.y -= .05f;
            moveableWall[0].transform.position = pos;
        }
    }
    private GameObject[] moveableWall;
    public Material newMaterialRef;
    private bool haveOriginalColor = false;
    private Material originalColor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Target")
        {
            if (!haveOriginalColor)
            {
              originalColor = collision.gameObject.GetComponent<Material>();
              haveOriginalColor = true;
            }
            Renderer ren = collision.gameObject.GetComponent<Renderer>();
            Debug.Log("------------Target has been placed by cube");
            ren.material.color = Color.green;

            moveableWall = GameObject.FindGameObjectsWithTag("moveWall");        
            moveWall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Target")
        {
            Debug.Log("------------Target has been removed by cube");
            Renderer ren = collision.gameObject.GetComponent<Renderer>();
            ren.material.color = Color.red;
        }
    }
}