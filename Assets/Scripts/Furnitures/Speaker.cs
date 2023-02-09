using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : Furnitures
{
    AudioSource audioSource;
    private bool isPlaying;
    [SerializeField]ParticleSystem particleNotes;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //particleNotes = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (isInteractable)
        {
            Interact();
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isPlaying)
            {
                TurnOn();
                
            }
            else TurnOff();
        }
        
        
    }


    private void TurnOn()
    {
        audioSource.Play();
        particleNotes.Play();
        isPlaying = true;
    }

    private void TurnOff()
    {
        audioSource.Pause();
        particleNotes.Stop();
        isPlaying =false;
    }
}
