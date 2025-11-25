using UnityEngine;

public class FollowParent : MonoBehaviour
{
    public Transform parentToFollow;
    public Vector3 offset;
    public float subtractY = (float)1.36144;

    void Update() {
        if (parentToFollow != null)
        {
            /* transform.position = new Vector3((float)(parentToFollow.position.x + offset.x), 
                                             (float)(parentToFollow.position.y + offset.y), 
                                             (float)(parentToFollow.position.z + offset.z)); */
            transform.position = new Vector3((float)(parentToFollow.position.x + offset.x), 
                                             (float)(parentToFollow.position.y + offset.y - subtractY), 
                                             (float)(parentToFollow.position.z + offset.z));
            // transform.localPosition = offset;
            // Optional: If you also want to match rotation
            // transform.rotation = parentToFollow.rotation;
        }
    }
}
