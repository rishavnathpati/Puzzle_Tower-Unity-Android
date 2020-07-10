using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float moveSmoothing = 10f;
    public float rotationSmoothing = 15f;

    private Transform target;

    private Vector3 targetForward;

    private void Awake()
    {
        target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    private void Start()
    {
        targetForward = transform.forward;
        targetForward.y = 0f;
        Snap();
    }

    // Update is called once per frame
    private void Update()
    {
        FollowPlayer();
    }

    private void Snap()
    {
        if (target != null)
        {
            transform.position = target.position;
        }

        Vector3 forward = targetForward;
        forward.y = transform.forward.y;
        transform.forward = forward;

    } // snap

    private void FollowPlayer()
    {

        if (target != null)
        {
            transform.position =
                Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSmoothing);
        }

        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward = Vector3.Slerp(forward, targetForward, Time.deltaTime * rotationSmoothing);
        forward.y = transform.forward.y;
        transform.forward = forward;

    } // follow player


} // class

//unity collab........ekdom kaaaj korche, puro changa////yo boi....





































