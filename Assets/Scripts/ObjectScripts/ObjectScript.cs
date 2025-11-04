using UnityEngine;

public class ObjectScript : MonoBehaviour {
    [SerializeField] int id = 0;
    [SerializeField] string objectName = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public int GetObjectID() {
        return id;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cauldron"))
        {
            Destroy(gameObject);
            other.GetComponent<Cauldron>().AddToCauldron(id);
        }
        if (other.CompareTag("Player"))
        {
            Debug.Log("Object colliding with Player");
        }
    }
}
