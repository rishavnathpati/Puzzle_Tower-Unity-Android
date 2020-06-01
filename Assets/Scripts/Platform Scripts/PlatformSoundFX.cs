using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSoundFX : MonoBehaviour {

    private AudioSource audioFX;

    void Awake() {
        audioFX = GetComponent<AudioSource>();
    }

    public void PlayAudio(bool play) { 
        if(play) {
            audioFX.Play();
        } else {
            audioFX.Stop();
        }
    }



} // class
