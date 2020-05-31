using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform movePoint;

    private Vector3 startPosition;

    [SerializeField]
    private float smoothMovement = 0.3f;
    private float initialMovement;

    private bool smoothMovementHalfed;

    private bool can_Move;
    private bool move_To_Initial;

    [SerializeField]
    private float halfDistance = 15f;

    [SerializeField]
    private bool activateMovementInStart;

    [SerializeField]
    private float timer = 1f;

    private DoorController doorController;

    [SerializeField]
    private bool deactivateDoors;

    private PlatformSoundFX soundFX;

    //private RotatingPlatform rotatePlatform;

    [SerializeField]
    private bool activateRotation;

    void Awake()
    {
        startPosition = transform.position;
        initialMovement = smoothMovement;
        //activate doors
        doorController = GetComponent<DoorController>();
        //add sound
        soundFX = GetComponent<PlatformSoundFX>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (activateMovementInStart)
        {
            Invoke("ActivateMovement", timer);
            soundFX.PlayAudio(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (can_Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, smoothMovement);
            if (Vector3.Distance(transform.position, movePoint.position) <= halfDistance)
            {
                if (!smoothMovementHalfed)
                {
                    smoothMovement /= 2f;
                    smoothMovementHalfed = true;
                }
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

            // deactivate door
            if (deactivateDoors)
            {
                doorController.OpenDoor();
            }

            // stop playing sound
            soundFX.PlayAudio(false);
        }
    }

    public void ActivateMovement()
    {
        can_Move = true;
        //play sound
    }
}