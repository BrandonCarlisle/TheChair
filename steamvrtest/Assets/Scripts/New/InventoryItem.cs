using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class InventoryItem : MonoBehaviour
{
    [SerializeField]
    private Transform m_attachPoint;

    private Rigidbody body;
    private Interactable interactable;

    public float snapTime = 2;
    private float dropTimer;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        body = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "KeyAttachPoint")
        {
            Debug.Log("Key Colliding with Controller!");
            LockToPoint();
        }
    }

    void LockToPoint()
    {
        bool used = false;
        if (interactable != null)
            used = interactable.attachedToHand;

        if (used)
        {
            body.isKinematic = false;
            dropTimer = -1;
        }
        else
        {
            dropTimer += Time.deltaTime / (snapTime / 2);

            body.isKinematic = dropTimer > 1;

            if (dropTimer > 1)
            {
                //transform.parent = snapTo;
                transform.position = m_attachPoint.position;
                transform.rotation = m_attachPoint.rotation;
            }
            else
            {
                float t = Mathf.Pow(35, dropTimer);

                body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, Time.fixedDeltaTime * 4);
                if (body.useGravity)
                    body.AddForce(-Physics.gravity);

                transform.position = Vector3.Lerp(transform.position, m_attachPoint.position, Time.fixedDeltaTime * t * 3);
                transform.rotation = Quaternion.Slerp(transform.rotation, m_attachPoint.rotation, Time.fixedDeltaTime * t * 2);
            }
        }
    }
}
