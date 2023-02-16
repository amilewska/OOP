using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : Furnitures
{
    [SerializeField] private Light bulbLight;
    private bool isTurnOn=false;

    

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Pushable();
        }
        else Stable();

        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            isTurnOn = !isTurnOn;
        }

        if (!isTurnOn) bulbLight.enabled = true;
        else bulbLight.enabled = false;
    }
}
