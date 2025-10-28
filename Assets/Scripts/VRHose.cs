using UnityEngine;

public class VRHose : MonoBehaviour
{

    public SprayHose theHose;
    public OVRInput.Button sprayInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (OVRInput.Get(sprayInput)) {
            theHose.StartSpray();
        }
    }
    
    // https://youtu.be/vmxRjbLhmXM
}
