using UnityEngine;

public class VRHose : MonoBehaviour
{

    public SprayHose theHose;
    public OVRInput.Button sprayInput;
    public OVRInput.Button shrinkInput;
    public OVRInput.Button enlargeInput;
    public OVRInput.Button changeWeaponInput;
    int sprayMode = 0;
    [SerializeField] public int changeModeCooldown = 60;
    private int currChangeModeCooldown = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (currChangeModeCooldown > 0) {
            currChangeModeCooldown--;
        }

        if ( (OVRInput.Get(changeWeaponInput) || Input.GetKeyDown(KeyCode.O)) && currChangeModeCooldown == 0) {
            if (sprayMode == 0 ) sprayMode = 1;
            else if (sprayMode == 1 ) sprayMode = 2;
            else if (sprayMode == 2 ) sprayMode = 0;
            currChangeModeCooldown += changeModeCooldown;
        }

        //original script
        if ((OVRInput.Get(sprayInput) || Input.GetKeyDown(KeyCode.U)) && sprayMode == 0)
        {
            Debug.Log("SHOOT!");
            theHose.StartSpray();
        }

        //check if the shrink input was pressed
        //makes it so that the shrink projectile is shot (called from SprayHose script)
        //using keyboard for testing purposes, want to add an input for vr specifically
        if ((OVRInput.Get(sprayInput) || Input.GetKeyDown(KeyCode.U)) && sprayMode == 1)
        {
            Debug.Log("SHOOT!");
            theHose.StartSpray("shrink");
        }

        //check if the grow input was pressed
        //makes it so that the grow projectile is shot (called from SprayHose script)
        //using keyboard for testing purposes, want to add an input for vr specifically
        if ((OVRInput.Get(sprayInput) || Input.GetKeyDown(KeyCode.U)) && sprayMode == 2)
        {
            Debug.Log("SHOOT!");
            theHose.StartSpray("grow");
        }
    }
    
    // https://youtu.be/vmxRjbLhmXM
}
