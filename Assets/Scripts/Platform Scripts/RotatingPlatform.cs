﻿using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{

    [SerializeField]
    private Vector3 rotationAngles;

    private Quaternion initialRotation;

    [SerializeField]
    private readonly float smoothRotate = 1f;

    [SerializeField]
    private bool can_Rotate;

    private readonly bool back_To_Initial_Rotation;

    [SerializeField]
    private readonly float deactivateTimer = 5f;

    private PlatformSoundFX soundFX;

    private void Awake()
    {
        initialRotation = transform.rotation;
        soundFX = GetComponent<PlatformSoundFX>();
    }

    // Update is called once per frame
    private void Update()
    {
        RotatePlatform();
    }

    private void RotatePlatform()
    {
        if (can_Rotate)
        {

            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(rotationAngles.x, rotationAngles.y, rotationAngles.z),
                    smoothRotate * Time.deltaTime);

        }
    }

    public void ActivateRotation()
    {

        if (!can_Rotate)
        {

            can_Rotate = true;

            soundFX.PlayAudio(true);

            // deactivate
            Invoke("DeactivateRotation", deactivateTimer);

        }

    } // activate rotaton

    private void DeactivateRotation()
    {

        can_Rotate = false;
        soundFX.PlayAudio(false);

    } // deactivate rotation

} // class































