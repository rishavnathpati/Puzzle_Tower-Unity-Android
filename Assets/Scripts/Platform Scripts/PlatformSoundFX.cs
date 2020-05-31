using UnityEngine;

public class PlatformSoundFX : MonoBehaviour
{
    private AudioSource audioFX;

    private void Awake()
    {
        audioFX = GetComponent<AudioSource>();
    }

    public void PlayAudio(bool play)
    {
        if (play)
            audioFX.Play();
        else
            audioFX.Stop();
    }
}
