using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("XR Origin (XR Rig)"))
            Destroy(gameObject);
    }
}
