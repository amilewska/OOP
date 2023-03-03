using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    
    protected float movementSpeed = 3;
    protected float jumpForce = 300f;
    protected float timeBeforeNextJump = 5f;
    protected float canJump = 0;
    protected Vector3 randomDirection;

    protected bool makeSound = false;
    protected AudioSource audioSource;

    protected float timeInterval = 2;
    protected float timeBeforeNextMove = 2f;
    protected bool flowerIsNear;
    protected GameObject flowerTarget;
    Animator anim;
    Rigidbody rb;


    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        randomDirection = RandomVector();
        audioSource = GetComponent<AudioSource>();

    }

    protected virtual void Update()
    {
        Move();
        if (flowerIsNear) Eat(flowerTarget);
        //Jump(jumpForce);
    }


    protected void Move()
    {
        timeInterval -= Time.deltaTime;

        if (timeInterval > 2 && timeInterval < 5 && !flowerIsNear)
        {
            Walk(movementSpeed);
            Jump(jumpForce);
        }

        if (timeInterval > 0 && timeInterval < 2 && !flowerIsNear)
        {
            //transform.Rotate(Vector3.up * Time.deltaTime * 30);
            Rotate(30);
        }

        if (timeInterval < 0)
        {
            timeInterval = 5;
            randomDirection = RandomVector();
        }


    }

    protected void Walk(float _movementSpeed)
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
        anim.SetInteger("Walk", 1);
    }

    protected void Rotate(float _speedRotation)
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _speedRotation);
        //transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), 0.001f);
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

    protected Vector3 RandomVector()
    {
        int x = Random.Range(0, 2) * 2 - 1;
        int y = Random.Range(1, 180);
        Vector3 randoVector = new Vector3(x,0,x);
        randoVector.Normalize();
        return randoVector;
    }

    protected float RandomAngle()
    {
        int x = Random.Range(0, 2)*2-1;
        int y = Random.Range(1, 180);
        float randomValue = x*y;
        return randomValue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.01F);
            anim.SetInteger("Walk", 0);
        }

        if (collision.gameObject.CompareTag("Flower"))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            flowerIsNear = false;
        }

        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Obstacle"))
        {
            MakeSound();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {
            flowerIsNear = true;
            flowerTarget = other.gameObject;
            // Vector3 target =  (other.gameObject.transform.position - transform.position).normalized;
            //transform.LookAt(target);
        }
        
    }


    protected void Eat(GameObject target)
    {
        Vector3 lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation =  Quaternion.LookRotation(lookPos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime*1f);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 1f);



    }

    protected void MakeSound()
    {
        audioSource.Play();
    }
}
