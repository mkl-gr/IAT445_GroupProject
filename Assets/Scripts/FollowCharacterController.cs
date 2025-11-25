using UnityEngine;

public class FollowCharacterController : MonoBehaviour
{
    public Transform parentToFollow;
    public Vector3 offset;

    void Update() {
        if (parentToFollow != null)
        {
            transform.position = new Vector3((float)(parentToFollow.GetComponent<CharacterController>().center.x + offset.x), 
                                             (float)(parentToFollow.transform.position.y + offset.y), 
                                             (float)(parentToFollow.GetComponent<CharacterController>().center.z + offset.z));
            // transform.localPosition = offset;
            // Optional: If you also want to match rotation
            // transform.rotation = parentToFollow.rotation;
        }
    }
}
