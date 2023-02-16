using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Furnitures : MonoBehaviour
{
    
    protected bool isInteractable;

    

    protected void OnTriggerEnter(Collider other)
    {
        isInteractable = true;
        //Debug.Log("can play now");
    }

    protected void OnTriggerExit(Collider other)
    {
        isInteractable = false;
    }

    

}
