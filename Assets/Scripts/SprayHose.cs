using UnityEngine;

public class SprayHose : MonoBehaviour
{

    // https://youtu.be/vmxRjbLhmXM
    
    [Header("Prefab References")]
    public GameObject dropletPrefab;

    [Header("Prefab References")]
    // [SerializeField] private Animator hoseAnimator;
    [SerializeField] private Transform hoseHoleLocation;
    [SerializeField] private Transform muzzleFlashPrefab;
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform leftController;

    [Header("Settings")]
    [SerializeField] private float speedOfProjectile = 150f;
    [SerializeField] private float cooldown = 150;
    float i = 0;
    float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (hoseHoleLocation == null) hoseHoleLocation = transform;
        // if (hoseAnimator == null) hoseAnimator = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0) {
            timer--;
        }

        if (i <= 0)
        {
            StartSpray();
            i += cooldown * 6;
        }
        else i--;
        
    }
    
    public void StartSpray()
    {
        if (timer <= 0) {
            Spray();
            timer += cooldown;
        }
    }

    void Spray()
    {
        if (!dropletPrefab)
        {
            return;
        }
        
        Instantiate(dropletPrefab, hoseHoleLocation.position, hoseHoleLocation.rotation)
            .GetComponent<Rigidbody>().AddForce(leftController.transform.forward * speedOfProjectile);
    }
}
