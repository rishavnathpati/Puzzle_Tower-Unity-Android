using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed = 3f;
    private float smoothMovement = 15f;

    private Vector3 targetForward;
    private bool canMove;

    private Vector3 dPos;

    private Camera mainCam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        targetForward = transform.forward;
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        UpdateForward();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            canMove = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }
    }

    void UpdateForward()// update forward
    {
        transform.forward = Vector3.Slerp(transform.forward, targetForward, Time.deltaTime * smoothMovement);
    }

    void MovePlayer()
    {
        if(canMove)//if we can move
        {
            dPos = new Vector3(Input.GetAxisRaw(Axis.MOUSE_X), 0f, 
                Input.GetAxisRaw(Axis.MOUSE_Y));
            dPos.Normalize();
            dPos *= moveSpeed * Time.fixedDeltaTime;
            dPos = Quaternion.Euler(0f, mainCam.transform.eulerAngles.y, 0f) * dPos;
            rb.MovePosition(rb.position + dPos);

            if(dPos!=Vector3.zero)
            {
                targetForward = Vector3.ProjectOnPlane(-dPos, Vector3.up);
            }
        }
    }
}
