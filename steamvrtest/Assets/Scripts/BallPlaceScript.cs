using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlaceScript : MonoBehaviour
{
    private bool hasBeenPlaced = false;
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

    private void OnCollisionEnter(Collision collision)
    {
       // print("Detected collision between " + gameObject.name + " and " + collision.gameObject.name);
        //if (collision.gameObject == leftHand || collision.gameObject == rightHand)
        if (collision.collider.tag == "Target" && hasBeenPlaced == false)
        {
            Debug.Log("------------Target has been hit by ball");
            hasBeenPlaced = true;
            
            moveableWall = GameObject.FindGameObjectsWithTag("moveWall");
            Debug.Log("wall moving down");
            moveWall = true;
            // wallscript.MoveWallDown();
            //Instantiate(prefab, new Vector3(-6.73f, 8.486f, 2.297f), Quaternion.identity);
        }
    }
}
