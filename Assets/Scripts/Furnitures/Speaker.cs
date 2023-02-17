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

    override protected void Update()
    {
        base.Update();

       
        if(isInteractable&&isPlaying) Sound(Input.GetAxis("Mouse ScrollWheel"));
    }

    override protected void Interact()
    {
        if (!isPlaying)
        {
            TurnOn();
        
        }
        else TurnOff();
        
    }
    private void Sound(float volume)
    {
        audioSource.volume += volume;
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
