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
            characterController.Move(velocity);
        } else gravityProvider.SetActive(true);
    }

    void OnDrawGizmosSelected() {
        if (climbDetectionTransform == null) return;
        Gizmos.DrawWireSphere(climbDetectionTransform.position, climbingReach);
    }

    

}