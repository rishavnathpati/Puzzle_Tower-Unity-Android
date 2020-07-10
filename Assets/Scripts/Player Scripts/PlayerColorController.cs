using UnityEngine;

public class PlayerColorController : MonoBehaviour
{

    public string PLAYER_COLOR = "";

    private void Start()
    {
        PLAYER_COLOR = Tags.WHITE_COLOR;
    }

}
