using UnityEngine;

public class BloomingPlatform : MonoBehaviour
{

    // 
    [SerializeField] float bloomPeriod;
    
    float retreatTimer;
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Droplet") && retreatTimer == 0){
            retreatTimer = retreatTimer + bloomPeriod;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (retreatTimer > 0) retreatTimer--;
    }
}
