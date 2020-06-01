using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButtonController : MonoBehaviour {

    public MovingPlatform[] movingPlatforms;

    [SerializeField]
    private bool movedPlatformsToPoint;

    [SerializeField]
    private bool is_White_Button, is_Red_Button;

    void OnTriggerEnter(Collider target) {

        if(target.CompareTag(Tags.PLAYER_TAG)) { 

            if(is_White_Button) { 

                if(!target.GetComponent<PlayerColorController>().PLAYER_COLOR
                        .Equals(Tags.WHITE_COLOR)) {
                            return;

                    }
            } // if is white color

            if(is_Red_Button) { 
            
                if(!target.GetComponent<PlayerColorController>().PLAYER_COLOR
                            .Equals(Tags.RED_COLOR)) {
                            return;
                            
                            }

            } // if is red color

            if(!movedPlatformsToPoint) {

                movedPlatformsToPoint = true;

                for(int i = 0; i < movingPlatforms.Length; i++) {
                    movingPlatforms[i].ActivateMovement();
                }

            } else {

                movedPlatformsToPoint = false;

                for(int i = 0; i < movingPlatforms.Length; i++) {
                    movingPlatforms[i].ActivateMoveToInitial();
                }

            }

        } // if we collided with the player

    }



} // class



























