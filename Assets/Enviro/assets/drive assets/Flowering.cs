using UnityEngine;

public class Flowering : MonoBehaviour
{
    [SerializeField] public GameObject flowerStg1;
    [SerializeField] public GameObject flowerStg2;
    [SerializeField] public GameObject flowerStg3;
    int timer = 100;
    int currentTimer = 0;
    bool isEvolving = false;
    void Start() {
        flowerStg1.SetActive(false);
        flowerStg2.SetActive(false);
        flowerStg3.SetActive(false);
    }

    void Update() {
        if (isEvolving) {
            if (currentTimer > 0) {
                currentTimer--;
                if (currentTimer > (float)timer/2) {
                    flowerStg1.SetActive(false);
                    flowerStg2.SetActive(true);
                }
            }
            if (currentTimer == 0) {
                flowerStg2.SetActive(false);
                flowerStg3.SetActive(true);
                isEvolving = false;
            }
        }
        
    }

    public void Evolve() {
        flowerStg1.SetActive(true);
        currentTimer += timer;
        isEvolving = true;
    }

    public void Die(){
        flowerStg3.SetActive(false);
        flowerStg1.SetActive(true);
    }

    void OnEnable(){
        
    }
}
