using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        jumpForce = 200f;
        movementSpeed = 3;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
