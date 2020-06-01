using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour {

    private RotatingPlatform rotatingPlatform;

    void Awake() {
        rotatingPlatform = GetComponentInParent<RotatingPlatform>();
    }

    void OnTriggerEnter(Collider target) {

        if(target.CompareTag(Tags.PLAYER_TAG)) {
            rotatingPlatform.ActivateRotation();
        }

    }

} // class




































