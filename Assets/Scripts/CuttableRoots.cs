using UnityEngine;

public class CuttableRoots : MonoBehaviour
{
    // Script is to be attached to each individual root object.

    // An empty gameobject that stores references to all roots and bulbs and sections them by their connections.
    public GameObject rootSystem;

    // A boolean that reveals whether the roots are active or inactive.
    private bool rootStatus;

    void Start() {
    }

    void Update() {
    }

    // Returns whether the roots are blocking the player's path or not.
    public bool GetRootStatus() {
        return rootStatus;
    }

    public void Retreat(){
        // Roots sink into the ground, causing the bridge they formed to be intraversible.
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public void Relink(){
        // Roots grow, forming a surface for the player to walk across.
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
