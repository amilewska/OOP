using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Furnitures : MonoBehaviour
{
    [SerializeField] GameObject player;
    protected float heaviness;
    protected bool isInteractable;
    protected float pushForce=1;

    protected void Moveable()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = player.transform.position;
        }
    }

    protected void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("they hit");
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null)
        {
            rb.AddForce(hit.moveDirection * pushForce);
        }
    }

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
