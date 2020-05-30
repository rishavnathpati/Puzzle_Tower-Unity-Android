using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform movePoint;

    private Vector3 startPosition;

    [SerializeField]
    private float smoothMovement;
    private float initalMoveent;

    private bool smoothMovementHalfed;
    private bool can_Move;
    private bool move_To_Initial;

    [SerializeField]
    private float halfDistance = 15f;

    [SerializeField]
    private bool activateMovementInStart;

    [SerializeField]
    private float timer = 1f;

    private void Awake()
    {
        startPosition = transform.position;
        initalMoveent = smoothMovement;
        //activate doors
        //add sound
    }

    // Start is called before the first frame update
    void Start()
    {
        if (activateMovementInStart)
        {
            Invoke("ActivateMovement", timer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        if (can_Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, smoothMovement);
            if (Vector3.Distance(transform.position, movePoint.position) <= halfDistance)
            {
                if(!smoothMovementHalfed)
                {
                    smoothMovement /= 2f;
                }
            }
        }

        if(Vector3.Distance(transform.position,movePoint.position)==0f)
        {
            can_Move = false;
            if(smoothMovementHalfed)
            {
                smoothMovement = initalMoveent;
                smoothMovementHalfed = false;
            }

            // deactivate door

            // stop playing sound
        }
    }

    void MovePlatform()
    {

    }

    public void ActivateMovement()
    {
        can_Move = true;
        //play sound
    }
}