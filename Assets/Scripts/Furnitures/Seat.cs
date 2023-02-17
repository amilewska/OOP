using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : Furnitures
{
   
    public GameObject player;
    [SerializeField]Transform seatPosition;
    bool playerIsSitting = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    override protected void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {

            playerIsSitting = !playerIsSitting;

        }

        if (playerIsSitting) CanSeat();
        else
        {
            CanMove();
        }
        base.Update();
    }


    private void CanSeat()
    {
        //block movement of the object and player
        player.GetComponent<CharacterController>().minMoveDistance = 1;

        //rotate the player 180 deegres 
        Quaternion target = Quaternion.Euler(0, 180, 0);
        player.transform.position = Vector3.Lerp(player.transform.position, seatPosition.position + Vector3.up,Time.deltaTime*5);
        player.transform.LookAt(player.transform.position - transform.right);
    }

    private void CanMove()
    {
        
        player.GetComponent<CharacterController>().minMoveDistance = 0.001f;
        

    }


}
