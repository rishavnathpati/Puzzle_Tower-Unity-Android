using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Transform[] children;

    [SerializeField]
    private bool deactivateInStart;
    // Start is called before the first frame update
    void Start()
    {
        children = transform.GetComponentsInChildren<Transform>();

        if (deactivateInStart)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        foreach (Transform c in children)
        {
            if (c.CompareTag(Tags.DOOR_TAG))
            {
                c.gameObject.GetComponent<Collider>().isTrigger = true;
            }
        }
    }

}
