using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Grape : Fruits //INHERITANCE
{
    public void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E)) Eatable();
        
        
    }
    



}
