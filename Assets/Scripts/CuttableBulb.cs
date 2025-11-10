using UnityEngine;

public class CuttableBulb : MonoBehaviour
{
    // Script is to be attached to each individual root object.

    // An empty gameobject that stores references to all roots and bulbs and sections them by their connections.
    // If the bulb gets attacked, it alerts rootSystem, and then the roots properties are changed immediately.
    public RootSystem rootSystem;

    // The rootSystem will use this ID to find the roots connected to this bulb and sink them.
    // An id that corresponds to the bulb connected to these roots
    [SerializeField] int bID;

    // Counts down the amount of time before the bulb regrows.
    [SerializeField] float regrowthPeriod = 240;
    private float regrowthTimer = 0;

    // 
    private bool triggerRegrowth;

    private void OnTriggerEnter(Collider other) {
        // If the object colliding with the mushroom's hitbox the function is called that makes the mushroom shrink.
        if (other.CompareTag("Cutter") && regrowthTimer == 0){
            rootSystem.RetreatGroup(bID);
        }
    }

    public void SetRegrowthTimer() {
        regrowthTimer = regrowthTimer + regrowthPeriod;
    }

    public int GetBulbID() {
        return bID;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (triggerRegrowth == true && regrowthTimer == 0) {
            rootSystem.RegrowGroup(bID);
        }
    }
}
