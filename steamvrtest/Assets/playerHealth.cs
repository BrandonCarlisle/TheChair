using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public EventManager eventManager;
    private EventManager events;

    public int Healthpool = 12;
    private int health;
    public float healthRegen = 3f;
    private float regenTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        health = Healthpool;
        events = eventManager.GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        regenTimer += Time.deltaTime;
        if (regenTimer > healthRegen)
        {
            if (health < Healthpool)
                health += 1;
            regenTimer = 0f;
        }
    }

    void TriggerDeath()
    {
        events.playerDeathTrigger.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "droneBlast")
        {
            health -= 1;
            if (health == 0)
                TriggerDeath();
        }
    }
}
