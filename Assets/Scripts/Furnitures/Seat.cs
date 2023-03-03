using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : Furnitures
{
   
    private GameObject player;
    [SerializeField]private Transform seatPosition;
    private bool playerCanSeat = false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    override protected void Update()
    {
        base.Update();

        if (playerCanSeat) SeatPlayer();//StartCoroutine(Seating());


    }

    protected override void Interact()
    {
        playerCanSeat = !playerCanSeat;

        if (playerCanSeat) PlayerCantMove();
        else PlayerCanMove();

    }

    IEnumerator Seating()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, seatPosition.position, Time.deltaTime * 500);
        player.transform.LookAt(player.transform.position - transform.right);
        yield return new WaitForSeconds(10);
    }

    private void SeatPlayer()
    {
        Debug.Log("method seating player");
        //player.transform.position = Vector3.Lerp(player.transform.position, seatPosition.position,Time.deltaTime*500);
        player.transform.LookAt(player.transform.position - transform.right);
        player.transform.position = Vector3.MoveTowards(player.transform.position, seatPosition.position, Time.deltaTime * 5);
        //player.transform.rotation = Quaternion.LookRotation(seatPosition.forward);
    }

    private void PlayerCantMove()
    {
        //player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<CharacterController>().minMoveDistance = 100;
        player.GetComponentInChildren<MouseLook>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;


    }
    private void PlayerCanMove()
    {
        
        //player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<CharacterController>().minMoveDistance = 0.001f;
        player.GetComponentInChildren<MouseLook>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;


    }


}
