using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // If using XR Interaction Toolkit
using Unity.XR.CoreUtils;


public class PlayerController : MonoBehaviour
{
    public XROrigin xrOrigin; // Or Transform if not using XROrigin component
    public Transform playerHead;
    
    [SerializeField] CharacterController characterController;
    bool isClimbing;
    bool canClimb;

    [Header("Climbing Settings")]
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

    void Start(){
        velocity = new Vector3(0,climbingSpeed,0);
    }

    private void FixedUpdate() {

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

        GroundCheck();
    }
    
    void Update(){
        Debug.Log("isGrounded:" + isGrounded);
    }

    void OnDrawGizmosSelected() {
        if (climbDetectionTransform == null) return;
        Gizmos.DrawWireSphere(climbDetectionTransform.position, climbingReach);
        Gizmos.DrawWireSphere(groundCheckOffset.position, groundCheckRadius);
    }

    void GroundCheck() {
        // Returns true if player is grounded.
        // More specifically it checks if the user is standing on an object
        // that is on the Obstacle layer (The obstacle layer is chosen in
        // the inspector)
        isGrounded = Physics.CheckSphere(groundCheckOffset.position, groundCheckRadius, groundLayer);
        
    }

}