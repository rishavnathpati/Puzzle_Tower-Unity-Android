using UnityEngine;

public class ColorSwitchController : MonoBehaviour
{

    [SerializeField]
    private readonly bool red_Color, white_Color;

    private void OnTriggerEnter(Collider target)
    {

        if (target.CompareTag(Tags.PLAYER_TAG))
        {

            if (red_Color)
            {
                target.GetComponent<PlayerColorController>().PLAYER_COLOR = Tags.RED_COLOR;
            }

            if (white_Color)
            {
                target.GetComponent<PlayerColorController>().PLAYER_COLOR = Tags.WHITE_COLOR;
            }

        }

    }

}
