using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit; // If using XR Interaction Toolkit
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;


public class PlayerController : MonoBehaviour
{
    public XROrigin xrOrigin; // Or Transform if not using XROrigin component
    public Transform playerHead;
    
    [SerializeField] CharacterController characterController;

    [Header("Climbing Settings")]
    bool isClimbing;
    bool canClimb;
    [SerializeField] Vector3 climbDetectionVector;
    public Transform climbDetectionTransform;
    [SerializeField] float climbingSpeed = 1.5f;
    [SerializeField] float climbingReach = 1.5f;
    public GameObject gravityProvider;
    public LayerMask climbLayers;
    public OVRInput.Button climbInput;
    Vector3 velocity;
    float ySpeed;

    [Header("Ground Check Settings")]
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] Transform groundCheckOffset;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;
    [SerializeField] UnityEngine.XR.Interaction.Toolkit.Locomotion.Jump.JumpProvider theJumpProvider;
    [SerializeField] UnityEngine.XR.Interaction.Toolkit.Locomotion.Gravity.GravityProvider theGravityProvider;

    public XRSimpleInteractable interactable;
    public GameObject hammer;
    public GameObject diamond;
    public GameObject stone;
    public Transform cameraOffset;
    public TeleportationProvider teleportProvider;
    private int mode = 0;
    public InputActionReference Button;
    public NearFarInteractor rightHand;

    void Start(){
        velocity = new Vector3(0,climbingSpeed,0);
        rightHand.selectEntered.AddListener(SelectStone);
    }

    private void FixedUpdate() {

        GroundCheck();
    }
    
    void Update(){
        canClimb = false;
        Collider[] theClimbables = Physics.OverlapSphere(climbDetectionTransform.position, climbingReach, climbLayers);
        foreach(Collider climbable in theClimbables) {
            // Debug.Log("Colliding with the climbable");
            canClimb = true;
        }

        isClimbing = false;
        //if (OVRInput.Get(climbInput) && canClimb) isClimbing = true;
        if (canClimb) isClimbing = true;

        if (isClimbing) {
            gravityProvider.SetActive(false);
            if (!isGrounded) characterController.Move(velocity);
        } else gravityProvider.SetActive(true);

        // Debug.Log("isGrounded:" + isGrounded);
        // Debug.Log("CharacterController's isGrounded:" + characterController.isGrounded);
        // Debug.Log("Gravity Provider's isGrounded:" + theGravityProvider.isGrounded);
    }

    void OnDrawGizmosSelected() {
        // if (climbDetectionTransform != null) Gizmos.DrawWireSphere(climbDetectionTransform.position, climbingReach);
        // if (groundCheckOffset != null) Gizmos.DrawWireSphere(groundCheckOffset.position, groundCheckRadius);
    }

    void GroundCheck() {
        // Returns true if player is grounded.
        // More specifically it checks if the user is standing on an object
        // that is on the Obstacle layer (The obstacle layer is chosen in
        // the inspector)
        // if (groundCheckOffset != null) isGrounded = Physics.CheckSphere(groundCheckOffset.position, groundCheckRadius, groundLayer);
    }

    private void ReleaseStone(InputAction.CallbackContext obj) {
        if (stone.activeSelf) {
            var clone = GameObject.Instantiate(stone);
            if (mode == 0) clone.transform.localScale = Vector3.one/6f;
            else if (mode == 1) clone.transform.localScale = Vector3.one;
            else if (mode == 2) clone.transform.localScale = Vector3.one / 320;
            clone.transform.SetParent(null);
            clone.transform.position = stone.transform.position;
            clone.GetComponent<Rigidbody>().isKinematic = false;
            clone.GetComponent<XRGrabInteractable>();
            stone.SetActive(false);
        }
    }

    private void SelectStone(SelectEnterEventArgs arg0) {
        if (arg0.interactableObject.transform.tag == "Stone") {
            arg0.interactableObject.transform.gameObject.SetActive(false);
            stone.SetActive(true);
        }
        if (arg0.interactableObject.transform.tag == "Table") {
            stone.SetActive(false);
            diamond.SetActive(true);
        }
    }

    /*private void OnTriggerEnter(Collider other) {
        if (other.tag == "Large") {
            if (mode == 0) {
                cameraOffset.localPosition = new Vector3(0, 3f, 0);
                mode = 1;
            }
            else {
                cameraOffset.localPosition = new Vector3(0, 0.5f, 0);
                mode = 0;
            }
        }
        if (other.tag == "Small") {
            if (mode == 0) {
                XROrigin.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                cameraOffset.localPosition = new Vector3(0, 3f, 0);
                TeleportTo(other.transform.position);
                mode = 2;
            }
            else {
                XROrigin.localScale = new Vector3(4, 4, 4);
                cameraOffset.localPosition = new Vector3(0, 0.5f, 0);
                TeleportTo(other.transform.position);
                mode = 0;
            }
        }
    } */

    public void ShowHammer() {
        hammer.SetActive(true);
    }

    public void HideHammer() {
        hammer.SetActive(false); diamond.SetActive(false);
    }

}