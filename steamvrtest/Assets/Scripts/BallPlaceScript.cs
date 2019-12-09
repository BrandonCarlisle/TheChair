using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlaceScript : MonoBehaviour
{
    private bool moveWall = false;
    private bool moveOtherWall = false;

    public GameObject floorMoveUp;
  

    // Update is called once per frame
    void Update()
    {
        if (moveWall)
        {
            Vector3 pos = moveableWall[0].transform.position;
            pos.y -= .05f;
            moveableWall[0].transform.position = pos;
        }
        if(moveOtherWall)
        {
            Vector3 pos = moveableOtherWall[0].transform.position;
            pos.y -= .05f;
            moveableOtherWall[0].transform.position = pos;
        }
    }
    private GameObject[] moveableWall;
    private GameObject[] moveableOtherWall;

    private GameObject[] moveFloorUp;

    public Material newMaterialRef;
    move moveScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "moveWallTarget")
        {
            //if (!haveOriginalColor)
            //{
            //  originalColor = collision.gameObject.GetComponent<Material>();
            //  haveOriginalColor = true;
            //}
            Renderer ren = collision.gameObject.GetComponent<Renderer>();
            Debug.Log("------------moveWallTarget has been triggered by cube");
            ren.material.color = Color.green;

            moveableWall = GameObject.FindGameObjectsWithTag("moveWall");        
            moveWall = true;
        }
        else if (collision.collider.tag == "moveFloorUpTarget")
        {
          
            Renderer ren = collision.gameObject.GetComponent<Renderer>();
            Debug.Log("------------moveFloorUpTarget has been triggered by cube");
            ren.material.color = Color.green;

            moveFloorUp = GameObject.FindGameObjectsWithTag("moveFloorUp");
            moveScript = moveFloorUp[0].GetComponent<move>();
            moveScript.shouldMoveUp = true;
            
        }
        else if (collision.collider.tag == "moveOtherWallTarget")
        {
          
            Renderer ren = collision.gameObject.GetComponent<Renderer>();
            Debug.Log("------------moveOtherWallTarget has been triggered by cube");
            ren.material.color = Color.green;

            moveableWall = GameObject.FindGameObjectsWithTag("moveOtherWall");
            moveWall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "moveWallTarget")
        {
            Debug.Log("------------moveWallTarget has been removed by cube");
            Renderer ren = collision.gameObject.GetComponent<Renderer>();
            ren.material.color = Color.red;
        }
        else if (collision.collider.tag == "moveFloorUpTarget")
        {
            Debug.Log("------------moveFloorUpTarget has been removed by cube");
            Renderer ren = collision.gameObject.GetComponent<Renderer>();
            ren.material.color = Color.red;
            moveFloorUp = GameObject.FindGameObjectsWithTag("moveFloorUp");
            moveScript = moveFloorUp[0].GetComponent<move>();
            moveScript.shouldMoveUp = false;
        }
    }
}