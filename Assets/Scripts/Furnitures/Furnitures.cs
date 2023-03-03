using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Furnitures : MonoBehaviour
{
    
    [SerializeField]protected bool isInteractable;

    protected virtual void Update()
    {
        if (isInteractable && Input.GetMouseButton(0))
        {
            Pushable();
        }
        else Stable();

        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            Interact();

        }
    }

    protected abstract void Interact();

    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player") isInteractable = true;
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player") isInteractable = false;
        
    }

    


    protected void Pushable()
    {
        GetComponent<Rigidbody>().isKinematic = false;

    }

    protected virtual void Stable()
    {
         GetComponent<Rigidbody>().isKinematic = true;
    }

}
