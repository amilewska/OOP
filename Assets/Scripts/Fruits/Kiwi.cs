using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : Fruits
{

    [SerializeField] GameObject orangePeel;
    [SerializeField] bool isPeeled = false;


    public void Update()
    {
        if (isInteractable && !isPeeled && Input.GetKeyUp(KeyCode.E))
        {
            Peeled();
        }

        if (isInteractable && isPeeled && Input.GetKeyDown(KeyCode.E))
        {
            Eatable();
        }
    }


    private void Peeled()
    {
        orangePeel.SetActive(false);
        infosUI.text = $"{fruitName} was peeled";
        Debug.Log($"{fruitName} was peeled");
        isPeeled = true;

    }



}
