using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitchController : MonoBehaviour {

    [SerializeField]
    private bool red_Color, white_Color;

    void OnTriggerEnter(Collider target) {

        if(target.CompareTag(Tags.PLAYER_TAG)) { 
        
            if(red_Color) {
                target.GetComponent<PlayerColorController>().PLAYER_COLOR = Tags.RED_COLOR;
            }

            if (white_Color) {
                target.GetComponent<PlayerColorController>().PLAYER_COLOR = Tags.WHITE_COLOR;
            }

        }

    }

}
