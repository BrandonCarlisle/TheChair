using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlaceScript : MonoBehaviour
{
    // private bool hasBeenPlaced = false;
    private bool moveWall = false;
    public GameObject floorMoveUp;
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
    private GameObject[] moveFloorUp;

    public Material newMaterialRef;
    //private bool haveOriginalColor = false;
    //private Material originalColor;
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
        if (collision.collider.tag == "moveFloorUpTarget")
        {
          
            Renderer ren = collision.gameObject.GetComponent<Renderer>();
            Debug.Log("------------moveFloorUpTarget has been triggered by cube");
            ren.material.color = Color.green;

            moveFloorUp = GameObject.FindGameObjectsWithTag("moveFloorUp");
            moveScript = moveFloorUp[0].GetComponent<move>();
            moveScript.shouldMoveUp = true;
            
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