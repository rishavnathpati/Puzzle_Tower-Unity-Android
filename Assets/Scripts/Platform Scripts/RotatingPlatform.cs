using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour {

    [SerializeField]
    private Vector3 rotationAngles;

    private Quaternion initialRotation;

    [SerializeField]
    private float smoothRotate = 1f;

    [SerializeField]
    private bool can_Rotate;

    private bool back_To_Initial_Rotation;

    [SerializeField]
    private float deactivateTimer = 5f;

    private PlatformSoundFX soundFX;

    void Awake() {
        initialRotation = transform.rotation;
        soundFX = GetComponent<PlatformSoundFX>();
    }

    // Update is called once per frame
    void Update() {
        RotatePlatform();
    }

    void RotatePlatform() { 
        if(can_Rotate) {

            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(rotationAngles.x, rotationAngles.y, rotationAngles.z),
                    smoothRotate * Time.deltaTime);

        }
    }

    public void ActivateRotation() { 

        if(!can_Rotate) {

            can_Rotate = true;

            soundFX.PlayAudio(true);

            // deactivate
            Invoke("DeactivateRotation", deactivateTimer);
             
        }

    } // activate rotaton

    void DeactivateRotation() {

        can_Rotate = false;
        soundFX.PlayAudio(false);

    } // deactivate rotation

} // class































