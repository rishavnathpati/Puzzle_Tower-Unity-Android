using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;

    public float moveSpeed = 3f;
    private float smoothMovement = 15f;

    private Vector3 targetForward;

    private bool canMove;

    private Vector3 dPos;

    private Camera mainCam;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        targetForward = transform.forward;

        mainCam = Camera.main;
    }

    void Update() {

        GetInput();

        UpdateForward();
    }

    void FixedUpdate() {
        MovePlayer();
    }

    void GetInput() { 

        if(Input.GetMouseButtonDown(0)) {

            canMove = true;
            
        } else if(Input.GetMouseButtonUp(0)) {

            canMove = false;

        }

    } // get input

    void UpdateForward() {
        transform.forward = Vector3.Slerp(
            transform.forward, targetForward, Time.deltaTime * smoothMovement);
    } // update forward

    void MovePlayer() { 
    
        if(canMove) {

            dPos = new Vector3(Input.GetAxisRaw(Axis.MOUSE_X), 0f, 
                    Input.GetAxisRaw(Axis.MOUSE_Y));

            dPos.Normalize();

            dPos *= moveSpeed * Time.fixedDeltaTime;
            dPos = Quaternion.Euler(0f, mainCam.transform.eulerAngles.y, 0f) * dPos;
            rb.MovePosition(rb.position + dPos);

            if(dPos != Vector3.zero) {
                targetForward = Vector3.ProjectOnPlane(-dPos, Vector3.up);
            }


        } // if we can move

    } // move player



} // class

































