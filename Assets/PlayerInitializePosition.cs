using UnityEngine;

public class PlayerInitializePosition : MonoBehaviour
{
    [SerializeField] public Transform initialTransform;
    [SerializeField] public GameObject player;

    void Start(){
        if (player == null) player = GameObject.Find("XR Origin (XR Rig)"); 
    }

    void Awake()
    {
        if (initialTransform != null) player.transform.position = initialTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
