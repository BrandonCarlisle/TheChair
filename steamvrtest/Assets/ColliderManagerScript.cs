using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void makeSmall()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void makeBig()
    {
        gameObject.transform.localScale = new Vector3(2, 2, 2);
    }

    //public void DisableColliders()
    //{
    //    Debug.Log("dis");
    //    var cols = gameObject.GetComponents<BoxCollider>();
    //    foreach (var col in cols)
    //    {
    //        col.enabled = false;
    //    }

    //    var childCols = gameObject.GetComponentsInChildren<BoxCollider>();
    //    foreach (var childCol in childCols)
    //    {
    //        childCol.enabled = false;
    //    }
    //}

    //public void EnableColliders()
    //{
    //    Debug.Log("en");
    //    var cols = gameObject.GetComponents<BoxCollider>();
    //    foreach (var col in cols)
    //    {
    //        col.enabled = true;
    //    }

    //    var childCols = gameObject.GetComponentsInChildren<BoxCollider>();
    //    foreach (var childCol in childCols)
    //    {
    //        childCol.enabled = true;
    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        
    }
}
