using UnityEngine;

public class DestroySelfDroplet : MonoBehaviour
{
    [SerializeField] private float destroyDropletTimer = 300;
    int i = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        if (i >= destroyDropletTimer)
        {
            Destroy(gameObject);
            i = 0;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
