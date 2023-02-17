using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightining : Furnitures
{
    [SerializeField] public Light bulbLight;
    private bool isTurnOn=true;


    override protected void Update()
    {
        base.Update();

        Interact();

        if(isTurnOn&&isInteractable) LightIntense(Input.GetAxis("Mouse ScrollWheel"));
    }

    float LightIntense(float intensityLight)
    {
        bulbLight.intensity += intensityLight;
        return bulbLight.intensity;
    }

    override protected void Interact() //ABSTRACTION
    {
        isTurnOn = !isTurnOn;
        

        if (isTurnOn)
        {
            bulbLight.enabled = true;

        }
        else bulbLight.enabled = false;
    }
}
