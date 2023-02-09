using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    float x;
    float y;
    float speed = 10;
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.position += (transform.forward *y +transform.right*x)*Time.deltaTime*speed;
    }
}
