using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedLevel : MonoBehaviour
{

    [SerializeField]
    private string nextLevelField;

    [SerializeField]
    private float timer=2f;

    private bool levelFinished;
    private PlatformSoundFX soundFX;

    private void Awake()
    {
        soundFX = GetComponent<PlatformSoundFX>();
    }

    void LoadNewLevel()
    {
        SceneManager.LoadScene(nextLevelField);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.PLAYER_TAG))
        {
            if(!levelFinished)
            {
                levelFinished = true;
                soundFX.PlayAudio(true);
                if(!nextLevelField.Equals(""))
                {
                    Invoke("LoadNewLevel", timer);
                }
            }
        }
    }
}
