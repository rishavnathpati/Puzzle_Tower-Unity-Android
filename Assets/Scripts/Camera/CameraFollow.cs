using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        targetForward = transform.forward;
        targetForward.y = 0f;
        Snap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Snap()
    {
        if(target!=null)
        {
            transform.position = target.position;
        }

        Vector3 forward = targetForward;
        forward.y = transform.forward.y;
        transform.forward = forward;
    }
}
