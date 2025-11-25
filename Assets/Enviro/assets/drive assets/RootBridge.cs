using UnityEngine;

public class RootBridge : MonoBehaviour
{
    public GameObject theXROrigin;
    public CharacterController characterControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(characterControl.radius);
        if (characterControl.radius >= 0.5) {
            Debug.Log(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        } else gameObject.GetComponent<BoxCollider>().enabled = true;
    }

}
