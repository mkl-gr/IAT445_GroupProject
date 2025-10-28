using UnityEngine;
using UnityEngine.UI;

public class ChangeHeight : MonoBehaviour
{
    public GameObject OriginBaseGameObject;
    public GameObject CameraFloorOffset;
    public Camera camera;
    public Slider tallnessSlider;
    public float i = 0;
    public float growTimer;

    void Start(){}

    void Awake()
    {
        // tallnessSlider = GetComponent<Slider>();
    }
    void Update() {
        if (i > 0)
        {
            i--;
            CameraFloorOffset.transform.position = new Vector3((float)(CameraFloorOffset.transform.position.x + 0.01), (float)(CameraFloorOffset.transform.position.y + 0.01), (float)(CameraFloorOffset.transform.position.z + 0.01));
        }
    }
    
    public void ChangePlayerHeight()
    {
        if (tallnessSlider != null)
        {
            // Debug.Log("Tallness changed.");
            CameraFloorOffset.transform.localScale = new Vector3(tallnessSlider.value, tallnessSlider.value, tallnessSlider.value);
        }
        else Debug.Log("Slider is null.");

    }
    
    /* public void SetPlayerHeight()
    {
        
        CameraFloorOffset.transform.localScale = new Vector3(CameraFloorOffset.transform.localScale.x * 100, CameraFloorOffset.transform.localScale.y * 100, CameraFloorOffset.transform.localScale.z * 100);
    } */
}
