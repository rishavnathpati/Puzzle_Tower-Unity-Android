using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedLevel : MonoBehaviour {

    [SerializeField]
    private string nextLevelName;

    [SerializeField]
    private float timer = 2f;

    private bool levelFinished;

    private PlatformSoundFX soundFX;

    void Awake() {
        soundFX = GetComponent<PlatformSoundFX>();
    }

    void LoadNewLevel() {
        SceneManager.LoadScene(nextLevelName);
    }

    void OnTriggerEnter(Collider target) {

        if(target.CompareTag(Tags.PLAYER_TAG)) { 
        
            if(!levelFinished) {

                levelFinished = true;

                soundFX.PlayAudio(true);

                if(!nextLevelName.Equals("")) {
                    Invoke("LoadNewLevel", timer);
                }

            }

        }

    }



} // class






































