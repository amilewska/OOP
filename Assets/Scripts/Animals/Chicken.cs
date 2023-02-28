using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        jumpForce = 400f;
        movementSpeed = 3;
        timeBeforeNextJump = 3;
    }

}
