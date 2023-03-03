using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : Furnitures
{
   
    private GameObject player;
    [SerializeField]private Transform seatPosition;
    private bool playerIsSitting = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    override protected void Update()
    {
        base.Update();

        if (playerIsSitting) CanSeat();

        else
        {
            CanMove();
        }
        
    }

    protected override void Interact()
    {
        playerIsSitting = !playerIsSitting;

    }

    private void CanSeat()
    {
        //block movement of the object and player
        player.GetComponent<CharacterController>().enabled = false;

        //rotate the player 180 deegres 
        Quaternion target = Quaternion.Euler(0, 180, 0);
        //player.transform.position = Vector3.Lerp(player.transform.position, seatPosition.position,Time.deltaTime*5);
        //player.transform.LookAt(player.transform.position - transform.right);
        player.transform.position = Vector3.MoveTowards(player.transform.position, seatPosition.position, Time.deltaTime * 5);
        player.transform.rotation = Quaternion.LookRotation(seatPosition.forward);
    }

    private void CanMove()
    {
        
        player.GetComponent<CharacterController>().enabled = true;
        

    }


}
