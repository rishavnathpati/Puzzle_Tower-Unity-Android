using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromButton : MonoBehaviour
{
    private RotatingPlatform rotatingPlatform;
    private void Awake()
    {
        rotatingPlatform = GetComponentInParent<RotatingPlatform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Tags.PLAYER_TAG))
        {
            rotatingPlatform.ActivateRotation();
        }
    }

}
