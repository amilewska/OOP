using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Vehicle
{
    

    protected override void Start()
    {
        base.Start();
        speed = 10;
        speedRotation = 10;
    }

    protected override void Update()
    {
        base.Update();
    }
}
