using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
