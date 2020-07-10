using UnityEngine;

public class PlatformButton : MonoBehaviour
{

    private RotatingPlatform rotatingPlatform;

    private void Awake()
    {
        rotatingPlatform = GetComponentInParent<RotatingPlatform>();
    }

    private void OnTriggerEnter(Collider target)
    {

        if (target.CompareTag(Tags.PLAYER_TAG))
        {
            rotatingPlatform.ActivateRotation();
        }

    }

} // class




































