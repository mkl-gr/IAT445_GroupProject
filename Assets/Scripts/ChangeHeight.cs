using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ChangeHeight : MonoBehaviour
{
    public GameObject OriginBaseGameObject;
    public GameObject CameraFloorOffset;
    public GameObject climbChecker;
    public GameObject groundChecker;
    public GameObject thePlayerTransform;
    public Camera camera;
    public Slider tallnessSlider;
    public float i = 0;
    public float growTimer;
    public OVRInput.Button enlargeInput;
    public OVRInput.Button shrinkInput;
    public InputActionReference enlargeButton;
    public InputActionReference shrinkButton;

    void Start(){
        CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, (float)1.36144, CameraFloorOffset.transform.position.z);
    }

    void Awake()
    {
        // tallnessSlider = GetComponent<Slider>();
    }
    void Update() {
        // Debug.Log("Camera floor offset: " + CameraFloorOffset.transform.position.y + CameraFloorOffset.transform.localPosition.y);
        InstantEnlarge();
        InstantShrink();
        // if ((CameraFloorOffset.transform.position.y + CameraFloorOffset.transform.localPosition.y) >= (float)-0.2) {
        if (gameObject.GetComponent<CharacterController>().height > 1) {
            gameObject.GetComponent<CharacterController>().radius = (float)0.3;
            /* CameraFloorOffset.transform.localScale = new Vector3((float)(0.5), 
                                                                     (float)(0.5), 
                                                                     (float)(0.5)); */
        }
        // else if ((CameraFloorOffset.transform.position.y + CameraFloorOffset.transform.localPosition.y) <= (float)-0.2) {
        else if (gameObject.GetComponent<CharacterController>().height < 1) {
            gameObject.GetComponent<CharacterController>().radius = (float)0.05;
            /* CameraFloorOffset.transform.localScale = new Vector3((float)(1), 
                                                                     (float)(1), 
                                                                     (float)(1)); */
        }
        /* if (i > 0)
        {
            i--;
            CameraFloorOffset.transform.position = new Vector3((float)(CameraFloorOffset.transform.position.x + 0.01), (float)(CameraFloorOffset.transform.position.y + 0.01), (float)(CameraFloorOffset.transform.position.z + 0.01));
        } */
    }
    
    public void ChangePlayerHeight()
    {
        

    }

    public void InstantShrink()
    {

        if (OVRInput.Get(shrinkInput) || Input.GetKey(KeyCode.N)) {
            if (gameObject.GetComponent<CharacterController>().height > 0.5) {
                CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, (float)(CameraFloorOffset.transform.position.y - 0.025), CameraFloorOffset.transform.position.z);
                /* CameraFloorOffset.transform.localScale = new Vector3((float)(CameraFloorOffset.transform.localScale.x - 0.025), 
                                                                     (float)(CameraFloorOffset.transform.localScale.y - 0.025), 
                                                                     (float)(CameraFloorOffset.transform.localScale.z - 0.025)); */
            }
            if (gameObject.GetComponent<CharacterController>().height > 1) {
                CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, (float)(CameraFloorOffset.transform.position.y - 0.025), CameraFloorOffset.transform.position.z);
                /* CameraFloorOffset.transform.localScale = new Vector3((float)(CameraFloorOffset.transform.localScale.x - 0.025), 
                                                                     (float)(CameraFloorOffset.transform.localScale.y - 0.025), 
                                                                     (float)(CameraFloorOffset.transform.localScale.z - 0.025)); */
            }
        }

    }

    public void InstantEnlarge()
    {
        if (OVRInput.Get(enlargeInput) || Input.GetKey(KeyCode.M)) {
            CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, (float)(CameraFloorOffset.transform.position.y + 0.05), CameraFloorOffset.transform.position.z);
            /* CameraFloorOffset.transform.localScale = new Vector3((float)(CameraFloorOffset.transform.localScale.x + 0.05), 
                                                                 (float)(CameraFloorOffset.transform.localScale.y + 0.05), 
                                                                 (float)(CameraFloorOffset.transform.localScale.z + 0.05)); */
        }

    }
    
    /* public void SetPlayerHeight()
    {
        
        CameraFloorOffset.transform.localScale = new Vector3(CameraFloorOffset.transform.localScale.x * 100, CameraFloorOffset.transform.localScale.y * 100, CameraFloorOffset.transform.localScale.z * 100);
    } */
}
