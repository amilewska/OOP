using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour
{
    [SerializeField] private Transform secondPortalDoor;
    private CharacterController characterController;
    private void Start()
    {
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        characterController.enabled = false;
        collision.gameObject.transform.position = secondPortalDoor.transform.position + Vector3.forward * 5;
        characterController.enabled = true;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        characterController.enabled = false;
        other.transform.position = secondPortalDoor.transform.position + secondPortalDoor.transform.forward * 2;
        characterController.enabled = true;
    }

}
