using UnityEngine;

public class ObjectScript : MonoBehaviour {
    [SerializeField] int id = 0;
    [SerializeField] string objectName = "";
    [SerializeField] private GameObject cauldronAnimation;
    [SerializeField] private Transform cauldronTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public int GetObjectID() {
        return id;
    }

    public string GetObjectName() {
        return objectName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cauldron")) {
            // If id is not in list, add the id to the list.
            // other.GetComponent<Cauldron>().AddToList(GetComponent<ObjectScript>());
            if (!other.GetComponent<Cauldron>().CheckListForDuplicates(id)) {
                gameObject.SetActive(false);
                other.GetComponent<Cauldron>().CauldronInsert(gameObject);
                other.GetComponent<Cauldron>().AddToCauldron(id);
                GameObject particle = Instantiate(cauldronAnimation, cauldronTransform.position, cauldronTransform.rotation);
                Destroy(particle, 2);
                other.GetComponent<Cauldron>().CheckListForRecipes();
            }
        }
        if (other.CompareTag("Player")) {
            Debug.Log("Object colliding with Player");
        }
    }
}
