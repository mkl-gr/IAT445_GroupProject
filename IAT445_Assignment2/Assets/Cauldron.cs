using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Great Potion"))
        {
            Debug.Log("Great Potion Cauldron Effect Triggered");
            Destroy(other);
            player.GetComponent<ChangeHeight>().i += player.GetComponent<ChangeHeight>().growTimer;
        }
    }
}
