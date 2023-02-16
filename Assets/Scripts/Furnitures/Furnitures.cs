using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Furnitures : MonoBehaviour
{
    
    protected bool isInteractable;


    protected void OnTriggerEnter(Collider other)
    {
        isInteractable = true;
    }

    protected void OnTriggerExit(Collider other)
    {
        isInteractable = false;
        
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
