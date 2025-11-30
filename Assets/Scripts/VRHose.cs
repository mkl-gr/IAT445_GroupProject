using UnityEngine;

public class VRHose : MonoBehaviour
{

    public SprayHose theHose;
    public OVRInput.Button sprayInput;
    public OVRInput.Button shrinkInput;
    public OVRInput.Button enlargeInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        //original script
        if (OVRInput.Get(sprayInput) || Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("SHOOT!");
            theHose.StartSpray();
        }

        //check if the shrink input was pressed
        //makes it so that the shrink projectile is shot (called from SprayHose script)
        //using keyboard for testing purposes, want to add an input for vr specifically
        if (OVRInput.Get(shrinkInput) || Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("SHOOT!");
            theHose.StartSpray("shrink");
        }

        //check if the grow input was pressed
        //makes it so that the grow projectile is shot (called from SprayHose script)
        //using keyboard for testing purposes, want to add an input for vr specifically
        if (OVRInput.Get(enlargeInput) || Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("SHOOT!");
            theHose.StartSpray("grow");
        }
    }
    
    // https://youtu.be/vmxRjbLhmXM
}
