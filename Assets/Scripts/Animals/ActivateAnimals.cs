using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimals : MonoBehaviour
{
    [SerializeField] private GameObject animals;
    [SerializeField] private bool state;
    private void OnTriggerEnter(Collider other)
    {
        animals.SetActive(state);
    }
    
}
