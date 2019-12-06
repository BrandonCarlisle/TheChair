using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Number : MonoBehaviour
{
    [SerializeField]
    private GameObject m_inventoryNumber = null;

    private Interactable interactable = null;

    // Start is called before the first frame update
    void Start()
    {
        interactable = this.GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnHandHoverBegin(Hand hand)
    {
        m_inventoryNumber.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
