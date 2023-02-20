using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightining : Furnitures
{
    public Light bulbLight;
    private bool isTurnOn=true;

    private void Start()
    {
        bulbLight = GetComponentInChildren<Light>();
    }

    override protected void Update()
    {
        base.Update();

        if(isTurnOn&&isInteractable) LightIntense(Input.GetAxis("Mouse ScrollWheel"));
    }

    float LightIntense(float intensityLight)
    {
        bulbLight.intensity += intensityLight;
        return bulbLight.intensity;
    }

    override protected void Interact() //POLYMORPHISM
    {
        isTurnOn = !isTurnOn;
        

        if (isTurnOn)
        {
            bulbLight.enabled = true;

        }
        else bulbLight.enabled = false;
    }
}
