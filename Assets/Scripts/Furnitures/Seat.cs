using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : Furnitures
{
   
    private GameObject player;
    [SerializeField]private Transform seatPosition;
    private bool playerCanSeat;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    override protected void Update()
    {
        base.Update();

        if (playerCanSeat)
        { 
            //SeatPlayer();
            StartCoroutine(Seating());
                         
        }


    }

    override protected void Interact()
    {
        playerCanSeat = !playerCanSeat;

        if (playerCanSeat) PlayerStopped();
        else PlayerCanMove();

    }

    IEnumerator Seating()
    {
        
        player.transform.position = Vector3.Lerp(player.transform.position, seatPosition.position, Time.deltaTime*0.5f);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.Euler(0, player.transform.rotation.y-90,0), Time.deltaTime * 0.5f);
        yield return null;
        //Quaternion.Euler(0, -90, 0)


    }

    private void SeatPlayer()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, seatPosition.position, Time.deltaTime);
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.Euler(0,180,0), Time.time);
    }

    private void PlayerStopped()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponentInChildren<MouseLook>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;


    }
    private void PlayerCanMove()
    {
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponentInChildren<MouseLook>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;


    }


}
