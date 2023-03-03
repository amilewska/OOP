using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 200f;

    public CharacterController controller;
    public float playerSpeed = 5;
    [Range(-90,90)]
    private Vector2 turn;
    [SerializeField] Transform playerBody;

   [SerializeField] private float pushForce = 2;

    public bool playerIsGrounded;
    public float gravity = -9.81f;
    public float jumpHeight = 30f;
    public Vector3 velocity;


    void Update()
    {
        //MouseLook();
        LookAtMouse();
        Move();
        Jump();

        Cursor.lockState = CursorLockMode.Locked;
    }

    ///<summary>
    ///Takes coordinates from mouse and rotate object to mouse position
    ///</summary>
    private void LookAtMouse() //ABSTRACTION
    {
        turn.x += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        turn.y += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        //transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0)*Time.deltaTime*mouseSensitivity);
        
    }

    private void MouseLook() 
    {
        float xRotation = 0;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up* mouseX);
    
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

    protected void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);


            
            //rb.AddForce(hit.moveDirection * hit.controller.velocity.magnitude * pushForce,ForceMode.Impulse);
        }
    }


}
