using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    
    protected float movementSpeed = 3;
    public float angleRotation = 30;
    protected float jumpForce = 300f;
    protected float timeBeforeNextJump = 5f;
    protected float canJump = 0;
    protected float canMove = 0;

    protected float timeInterval = 2;
    protected float timeBeforeNextMove = 2f;
    Animator anim;
    Rigidbody rb;


    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    protected virtual void Update()
    {
        Move();
        //Jump(jumpForce);
        //MakeSound();
    }


    public void Move()
    {
        timeInterval -= Time.deltaTime;

        if (timeInterval > 1 && timeInterval < 5)
        {
            Walk(movementSpeed);
            Jump(jumpForce);
        }

        if (timeInterval > 0 && timeInterval < 1)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 30);
            //Rotate(RandomAngle());
        }

        if (timeInterval < 0)
        {
            timeInterval = 5;
        }


    }

    protected void Walk(float _movementSpeed)
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
        anim.SetInteger("Walk", 1);
    }

    public void Rotate(float _speedRotation)
    {
        transform.Rotate(Vector3.up*Time.deltaTime* _speedRotation);
        //transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), slerpValue);
        anim.SetInteger("Walk", 0);
    }

    protected void Jump(float _jumpForce)
    {

        if (Time.time > canJump)
        {
            rb.AddForce(0, _jumpForce, 0);
            canJump = Time.time + timeBeforeNextJump;
            anim.SetTrigger("jump");
        }
    }

    public float RandomAngle()
    {
        int x = Random.Range(0, 2)*2-1;
        int y = Random.Range(30, 90);
        float randomValue = x;
        return randomValue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.01F);
            anim.SetInteger("Walk", 0);
        }
        
    }

   

    protected void MakeSound()
    {

    }

    protected void Eat()
    {//if near by is flower go to it
        //eat flower if its touch it
        //range of movement

    }
}
