using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlaceScript : MonoBehaviour
{
    private bool hasBeenPlaced = false;
    public GameObject objectCollindingWith;
    public GameObject moveableWall;
    //ReferencedScript wallMove = 
    //public moveWall wallscript;
    private bool moveWall = false;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveWall)
        {
            Vector3 pos = moveableWall.transform.position;
            pos.y -= .05f;
            moveableWall.transform.position = pos;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
       // print("Detected collision between " + gameObject.name + " and " + collision.gameObject.name);
        //if (collision.gameObject == leftHand || collision.gameObject == rightHand)
        if (collision.gameObject == objectCollindingWith && hasBeenPlaced == false)
        {
            Debug.Log("------------Object Has been placed");
            hasBeenPlaced = true;
            Debug.Log("wall moving down");
            moveWall = true;
            // wallscript.MoveWallDown();
            //Instantiate(prefab, new Vector3(-6.73f, 8.486f, 2.297f), Quaternion.identity);
        }
    }
}
