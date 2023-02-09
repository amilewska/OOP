using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Fruits
{
    public void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E)) Eatable();

    }
}
