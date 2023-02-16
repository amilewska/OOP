using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : Furnitures
{
    public Vector3 com;
    Rigidbody rb;
    public GameObject player;
    [SerializeField]Transform seatPosition;
    bool playerIsSitting = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        rb.ResetCenterOfMass();
    }

    private void Update()
    {
        rb.centerOfMass = com;


        //if press q and is not sitting, sit
        if (isInteractable && Input.GetKeyDown(KeyCode.Q))
        {
            
            playerIsSitting = !playerIsSitting;
            Debug.Log("q was pressed");
        
        }

        if (playerIsSitting) CanSeat();
        else  CanMove();
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * com, 1f);
    }

    private void CanSeat()
    {
        //block movement of the object and player
        rb.isKinematic = true;
        player.GetComponent<CharacterController>().minMoveDistance = 1;

        Quaternion target = Quaternion.Euler(0, 180, 0);
        //rotate the player 180 deegres 
        player.transform.position = Vector3.Lerp(player.transform.position, seatPosition.position + Vector3.up,Time.deltaTime*5);
        player.transform.LookAt(player.transform.position - transform.right);
        

    }

    private void CanMove()
    {
        rb.isKinematic = false;
        player.GetComponent<CharacterController>().minMoveDistance = 0.001f;

    }


}
