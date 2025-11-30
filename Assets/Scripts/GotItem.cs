using UnityEngine;

public class GotItem : MonoBehaviour {

    [SerializeField] public GameObject player;
    [SerializeField] public bool instantCollect = false;

    void Start(){
        if (player == null) player = GameObject.Find("XR Origin (XR Rig)"); 

        if (gameObject.name.Equals("Syringe") && player.GetComponent<PlayerController>().hasSyringe == 1) {
            Destroy(gameObject);
        }
        if (gameObject.name.Equals("special_root") && player.GetComponent<PlayerController>().hasRoot == 1) { 
            Destroy(gameObject);
        }
        if (gameObject.name.Equals("theBeaker") && player.GetComponent<PlayerController>().hasBeaker == 1) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (instantCollect) { 
            if (other.gameObject.name.Equals("XR Origin (XR Rig)")) {
                getItem();
            }
        }
    }

    public void getItem() {
        if (gameObject.name.Equals("Syringe") && player.GetComponent<PlayerController>().hasSyringe == 0) {
            player.GetComponent<PlayerController>().hasSyringe = 1;
            PlayerPrefs.SetInt("Syringe", player.GetComponent<PlayerController>().hasSyringe);
            Destroy(gameObject);
        }
        if (gameObject.name.Equals("special_root") && player.GetComponent<PlayerController>().hasRoot == 0) { 
            player.GetComponent<PlayerController>().hasRoot = 1;
            PlayerPrefs.SetInt("Root", player.GetComponent<PlayerController>().hasRoot);
            Destroy(gameObject);
        }
        if (gameObject.name.Equals("theBeaker") && player.GetComponent<PlayerController>().hasBeaker == 0) {
            player.GetComponent<PlayerController>().hasBeaker = 1;
            PlayerPrefs.SetInt("Beaker", player.GetComponent<PlayerController>().hasBeaker);
            Destroy(gameObject);
        }
        Debug.Log("Has syringe: " + player.GetComponent<PlayerController>().hasSyringe + ", Has beaker: " + player.GetComponent<PlayerController>().hasBeaker + ", Has root: " + player.GetComponent<PlayerController>().hasRoot);
    }
}
