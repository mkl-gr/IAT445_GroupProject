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

    void Start(){}

    void Awake()
    {
        // tallnessSlider = GetComponent<Slider>();
    }
    void Update() {
        // if (!OVRInput.Get(shrinkInput) && !OVRInput.Get(shrinkInput)) Reverse();
        // Debug.Log("Camera floor offset: " + CameraFloorOffset.transform.position.y + CameraFloorOffset.transform.localPosition.y);
        InstantEnlarge();
        InstantShrink();
        if (CameraFloorOffset.transform.position.y > 0.01) {
            gameObject.GetComponent<CharacterController>().radius = (float)0.3;
        }
        else if (CameraFloorOffset.transform.position.y < 0.01) {
            gameObject.GetComponent<CharacterController>().radius = (float)0.05;
        }
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
            CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, tallnessSlider.value, CameraFloorOffset.transform.position.z);
            gameObject.GetComponent<CharacterController>().height = tallnessSlider.value*4;
            gameObject.GetComponent<CharacterController>().center = new Vector3(gameObject.GetComponent<CharacterController>().center.x, tallnessSlider.value*4, gameObject.GetComponent<CharacterController>().center.y);
            /* groundChecker.transform.position = 
            climbChecker.transform.position = 
            thePlayerTransform.transform.position = */
            // groundChecker.GetComponent<FollowParent>().offset.y = - gameObject.GetComponent<CharacterController>().height/4;
            // climbChecker.GetComponent<FollowParent>().offset.y = gameObject.GetComponent<CharacterController>().center.y;
            // thePlayerTransform.GetComponent<FollowParent>().offset = new Vector3(thePlayerTransform.transform.position.x, gameObject.GetComponent<CharacterController>().height/4, thePlayerTransform.transform.position.z);
            
            thePlayerTransform.GetComponent<FollowParent>().offset = new Vector3(0, -gameObject.GetComponent<CharacterController>().height/4, 0);
            float i = gameObject.GetComponent<CharacterController>().height*2;
            // groundChecker.GetComponent<FollowParent>().offset.y = -i;
            Debug.Log("CharacterController Center: " + gameObject.GetComponent<CharacterController>().center + "Height: " + gameObject.GetComponent<CharacterController>().height + ", The offset:" + thePlayerTransform.GetComponent<FollowParent>().offset);
            Debug.Log("PlayerTransformY: " + thePlayerTransform.transform.position.y + " PlayerLocalTransformY: " + thePlayerTransform.transform.localPosition.y);
            // CameraFloorOffset.transform.localScale = new Vector3(tallnessSlider.value, tallnessSlider.value, tallnessSlider.value);
        }
        else Debug.Log("Slider is null.");

    }

    public void Reverse()
    {
        float scaleFactor = (float)0.02;
        CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, scaleFactor, CameraFloorOffset.transform.position.z);
        gameObject.GetComponent<CharacterController>().height = scaleFactor*4;
        gameObject.GetComponent<CharacterController>().radius = (float)0.3;
        gameObject.GetComponent<CharacterController>().center = new Vector3(gameObject.GetComponent<CharacterController>().center.x, scaleFactor*4, gameObject.GetComponent<CharacterController>().center.y);
        thePlayerTransform.GetComponent<FollowParent>().offset = new Vector3(0, -gameObject.GetComponent<CharacterController>().height/4, 0);

    }

    public void InstantShrink()
    {

        if (OVRInput.Get(shrinkInput)) {
            //if (CameraFloorOffset.transform.position.y > 0) 
            if ((CameraFloorOffset.transform.position.y + CameraFloorOffset.transform.localPosition.y) >= (float)-2) 
            CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, (float)(CameraFloorOffset.transform.position.y - 0.05), CameraFloorOffset.transform.position.z);
        }
        /** if (OVRInput.Get(shrinkInput)) {
            float scaleFactor = (float)0.0001;
            CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, scaleFactor, CameraFloorOffset.transform.position.z);
            gameObject.GetComponent<CharacterController>().height = scaleFactor*4;
            gameObject.GetComponent<CharacterController>().radius = (float)0.5;
            gameObject.GetComponent<CharacterController>().center = new Vector3(gameObject.GetComponent<CharacterController>().center.x, scaleFactor*4, gameObject.GetComponent<CharacterController>().center.y);
            thePlayerTransform.GetComponent<FollowParent>().offset = new Vector3(0, -gameObject.GetComponent<CharacterController>().height/4, 0);
        } */

    }

    public void InstantEnlarge()
    {
        if (OVRInput.Get(enlargeInput)) {
            CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, (float)(CameraFloorOffset.transform.position.y + 0.05), CameraFloorOffset.transform.position.z);
            
        }
        /* if (OVRInput.Get(enlargeInput)) {
            float scaleFactor = 5;
            CameraFloorOffset.transform.position = new Vector3(CameraFloorOffset.transform.position.x, scaleFactor, CameraFloorOffset.transform.position.z);
            gameObject.GetComponent<CharacterController>().height = scaleFactor*4;
            gameObject.GetComponent<CharacterController>().radius = (float)0.5;
            gameObject.GetComponent<CharacterController>().center = new Vector3(gameObject.GetComponent<CharacterController>().center.x, scaleFactor*4, gameObject.GetComponent<CharacterController>().center.y);
            thePlayerTransform.GetComponent<FollowParent>().offset = new Vector3(0, -gameObject.GetComponent<CharacterController>().height/4, 0);
        } */

    }
    
    /* public void SetPlayerHeight()
    {
        
        CameraFloorOffset.transform.localScale = new Vector3(CameraFloorOffset.transform.localScale.x * 100, CameraFloorOffset.transform.localScale.y * 100, CameraFloorOffset.transform.localScale.z * 100);
    } */
}
