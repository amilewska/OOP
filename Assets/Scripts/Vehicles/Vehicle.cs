using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    protected float speed;
    protected float speedRotation;

    protected GameObject player;
    protected GameObject playerCamera;
    protected Camera vehicleCamera;
    [SerializeField] protected Transform seatPositon;
    protected Vector3 leavePosition;

    protected bool inVehicle;

    protected virtual void Start()
    {
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("Main Camera");
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !inVehicle)
        {
            GetIn();
        }

        else if(Input.GetKeyDown(KeyCode.E) && inVehicle)
        {
            GetOut();
        }

        if (inVehicle) Move();
    }

    protected void GetOut()
    {
        player.transform.position = leavePosition;
    }

    protected virtual void GetIn()
    {
       
        leavePosition = player.transform.position;
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = seatPositon.position;
        player.GetComponentInChildren<MouseLook>().xRotation = 0;
        

    }

    protected virtual void Move()
    {

        player.transform.position = seatPositon.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * speedRotation);
    }
}
