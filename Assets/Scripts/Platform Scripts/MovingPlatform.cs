using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField]
    private readonly Transform movePoint;

    private Vector3 startPosition;

    [SerializeField]
    private float smoothMovement = 0.3f;
    private float initialMovement;

    private bool smoothMovementHalfed;

    private bool can_Move;
    private bool move_To_Initial;

    [SerializeField]
    private readonly float halfDistance = 15f;

    [SerializeField]
    private readonly bool activateMovementInStart;

    [SerializeField]
    private readonly float timer = 1f;

    private DoorController doorController;

    [SerializeField]
    private readonly bool deactivateDoors;

    private PlatformSoundFX soundFX;

    private RotatingPlatform rotatePlatform;

    [SerializeField]
    private readonly bool activateRotation;

    private void Awake()
    {

        startPosition = transform.position;
        initialMovement = smoothMovement;

        // activate doors
        doorController = GetComponent<DoorController>();

        // add sound
        soundFX = GetComponent<PlatformSoundFX>();

        if (activateRotation)
        {
            rotatePlatform = GetComponent<RotatingPlatform>();
        }
    }

    private void Start()
    {
        if (activateMovementInStart)
        {
            Invoke("ActivateMovement", timer);
        }
    }

    private void Update()
    {
        MovePlatform();
        MoveToInitialPosition();
    }

    private void MovePlatform()
    {

        if (can_Move)
        {

            transform.position = Vector3.MoveTowards(transform.position,
            movePoint.position, smoothMovement);

            if (Vector3.Distance(transform.position, movePoint.position) <= halfDistance)
            {

                if (!smoothMovementHalfed)
                {

                    smoothMovement /= 2f;
                    smoothMovementHalfed = true;

                }

            }

            if (Vector3.Distance(transform.position, movePoint.position) == 0f)
            {

                can_Move = false;

                if (smoothMovementHalfed)
                {
                    smoothMovement = initialMovement;
                    smoothMovementHalfed = false;
                }

                // deactivate doors
                if (deactivateDoors)
                {
                    doorController.OpenDoors();
                }

                // stop playing the sound FX
                soundFX.PlayAudio(false);

            }


        }

    } // move platform

    public void ActivateMovement()
    {
        can_Move = true;

        // play sound fx
        soundFX.PlayAudio(true);

        // rotate
        if (activateRotation)
        {
            rotatePlatform.ActivateRotation();
        }
    }

    public void ActivateMoveToInitial()
    {

        move_To_Initial = true;
        soundFX.PlayAudio(true);

    }

    private void MoveToInitialPosition()
    {

        if (move_To_Initial)
        {

            transform.position = Vector3.MoveTowards(transform.position,
                startPosition, smoothMovement);

            if (Vector3.Distance(transform.position, startPosition) <= halfDistance)
            {

                if (!smoothMovementHalfed)
                {
                    smoothMovement /= 2f;

                    smoothMovementHalfed = true;
                }

            }

            if (Vector3.Distance(transform.position, startPosition) == 0f)
            {

                move_To_Initial = false;

                if (smoothMovementHalfed)
                {
                    smoothMovementHalfed = false;
                    smoothMovement = initialMovement;
                }

                soundFX.PlayAudio(false);

            }


        } // if move to initial

    }

} //class





































