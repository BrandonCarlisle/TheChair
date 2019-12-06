using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerTrigger : MonoBehaviour
{

    public UnityEngine.Events.UnityEvent barrelToTrigger;

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
        barrelToTrigger.Invoke();
    }
}
