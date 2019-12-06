using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressPlateTrigger : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent barrierToTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        barrierToTrigger.Invoke();
    }
}
