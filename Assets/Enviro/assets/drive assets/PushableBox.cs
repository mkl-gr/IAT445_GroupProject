using UnityEngine;

public class PushableBox : MonoBehaviour
{

    public GameObject theXROrigin;
    public CharacterController characterControl;

    void Start() {
        
    }

    void Update() {
        if (characterControl.radius >= 0.3) {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        } else gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
