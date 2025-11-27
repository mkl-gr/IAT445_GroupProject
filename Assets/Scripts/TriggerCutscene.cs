using UnityEngine;

public class TriggerCutscene : MonoBehaviour {

    public TextCycling textCycler;
    public int theID;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Equals("XR Origin (XR Rig)")) {
            Debug.Log("Cutscene triggered");
            textCycler.textCycle(theID);
            Destroy(gameObject);
        }
    }
}
