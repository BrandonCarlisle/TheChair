using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButtonScript : MonoBehaviour
{
    public GameObject eventManager;
    private EventManager events;

    public int shootButtonID = 0;

    // Start is called before the first frame update
    void Start()
    {
        events = eventManager.GetComponent<EventManager>();

        events.shootColorSet.AddListener(SetColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetColor(int id)
    {
        var render = gameObject.GetComponent<Renderer>();
        if (id == shootButtonID)
        {
           
            render.material.color = Color.green;
        }
        else
        {
            render.material.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile")
        {
            events.shootButtonHit.Invoke(shootButtonID);
        }
    }
}
