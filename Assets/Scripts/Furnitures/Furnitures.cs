using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Furnitures : MonoBehaviour
{
    
    protected bool isInteractable;

    protected virtual void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Pushable();
        }
        else Stable();

        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            Interact();

        }
    }


    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player") isInteractable = true;
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player") isInteractable = false;
        
    }

    protected virtual void Interact()
    {

    }


    protected void Pushable()
    {
        if(isInteractable) GetComponent<Rigidbody>().isKinematic = false;
        else GetComponent<Rigidbody>().isKinematic = true;


    }

    protected void Stable()
    {
         GetComponent<Rigidbody>().isKinematic = true;
    }

}
