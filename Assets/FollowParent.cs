using UnityEngine;

public class FollowParent : MonoBehaviour
{
    public Transform parentToFollow;
    public Vector3 offset;

    void Update() {
        if (parentToFollow != null)
        {
            transform.position = new Vector3((float)(parentToFollow.position.x + offset.x), 
                                             (float)(parentToFollow.position.y + offset.y), 
                                             (float)(parentToFollow.position.z + offset.z));
            // transform.localPosition = offset;
            // Optional: If you also want to match rotation
            // transform.rotation = parentToFollow.rotation;
        }
    }
}
