using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USB : MonoBehaviour
{
    [Tooltip("Game Object to set active")]
    [SerializeField]
    private List<GameObject> m_gameObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Computer")
        {
            Debug.Log("USB Plugged in!");

            foreach(GameObject go in m_gameObjects)
                go.SetActive(true);
        }
    }
}
