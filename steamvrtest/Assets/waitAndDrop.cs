using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitAndDrop : MonoBehaviour
{
    public float waitTime;
    bool shouldDrop = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
        shouldDrop = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (shouldDrop)
        {
            Vector3 temp = this.transform.position;
            temp.y -= .02f;
            this.transform.position = temp;
        }
    }
}
