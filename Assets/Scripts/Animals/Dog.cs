using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        jumpForce = 150f;
        movementSpeed = 1f;
        timeBeforeNextJump = 10;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
