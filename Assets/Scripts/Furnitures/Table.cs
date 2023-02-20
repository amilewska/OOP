using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Furnitures
{
    bool isFlipping;
   override protected void Update()
    {
        if (isInteractable && Input.GetMouseButton(0))
        {
            Pushable();
        }

        

        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            Pushable();

        }
    }
    protected override void Interact()
    {
        
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        GameObject player = GameObject.Find("Player");

        Vector3 playerDirection = transform.position;
        rb.AddForce(Vector3.up*100, ForceMode.Impulse);
        rb.AddTorque(-Vector3.forward * 1200 * Time.deltaTime,ForceMode.Impulse);

    }
}
