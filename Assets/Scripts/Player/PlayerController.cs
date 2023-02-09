using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 1f;

    public CharacterController controller;
    public float playerSpeed = 5;
    private Vector2 turn;

    private float pushForce = 2;



    public bool playerIsGrounded;
    public float gravity = -9.81f;
    public float jumpHeight = 30f;
    public Vector3 velocity;


    void Update()
    {
        LookAtMouse();
        Move();
        Jump();

        //Cursor.lockState = CursorLockMode.Locked;
    }

    ///<summary>
    ///Takes coordinates from mouse and rotate object to mouse position
    ///</summary>
    private void LookAtMouse() //ABSTRACTION
    {
        turn.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        turn.y += Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        
    }

    private void Move() //ABSTRACTION
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed *= 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed /= 2;
        }

        //check if player is grounded
        playerIsGrounded = controller.isGrounded;
        //if he's grounded and has less tha 0 velocity, change it to -2
        if (playerIsGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //vector which takes player's input (and its transforms directions) to move
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        
        //players move and gravity
        controller.Move(move * Time.deltaTime * playerSpeed);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }

    private void Jump() //ABSTRACTION
    {
        if (Input.GetButtonDown("Jump") && playerIsGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

    }

    /*protected void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("they hit");
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null)
        {
            rb.AddForce(hit.moveDirection*hit.controller.velocity.magnitude);// = hit.moveDirection * pushForce/rb.mass;
        }
    }*/


}