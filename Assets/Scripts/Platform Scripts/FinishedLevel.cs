using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedLevel : MonoBehaviour
{

    [SerializeField]
    private readonly string nextLevelName;

    [SerializeField]
    private readonly float timer = 2f;

    private bool levelFinished;

    private PlatformSoundFX soundFX;

    private void Awake()
    {
        soundFX = GetComponent<PlatformSoundFX>();
    }

    private void LoadNewLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    private void OnTriggerEnter(Collider target)
    {

        if (target.CompareTag(Tags.PLAYER_TAG))
        {

            if (!levelFinished)
            {

                levelFinished = true;

                soundFX.PlayAudio(true);

                if (!nextLevelName.Equals(""))
                {
                    Invoke("LoadNewLevel", timer);
                }

            }

        }

    }



} // class






































