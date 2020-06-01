using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorController : MonoBehaviour {

    public string PLAYER_COLOR = "";

    void Start() {
        PLAYER_COLOR = Tags.WHITE_COLOR;
    }

}
