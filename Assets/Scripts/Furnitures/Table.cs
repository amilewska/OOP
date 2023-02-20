using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Furnitures
{
   override protected void Update()
    {
        base.Update();
    }
    protected override void Interact()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        GameObject player = GameObject.Find("Player");

        Vector3 playerDirection = transform.position;
        rb.AddForce(Vector3.up*100, ForceMode.Impulse);
        rb.AddTorque(-Vector3.forward * 1200 * Time.deltaTime,ForceMode.Impulse);

    }
}
