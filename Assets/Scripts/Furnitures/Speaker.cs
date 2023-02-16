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
        if (isInteractable&& Input.GetKeyDown(KeyCode.E))
        {
            Interact();
            
        }

        if (Input.GetMouseButton(0))
        {
            Pushable();
        }
        else Stable();
    }

    private void Interact()
    {
        
            if (!isPlaying)
            {
                TurnOn();
                
            }
            else TurnOff();
        
        
        
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
