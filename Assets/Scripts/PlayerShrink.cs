using UnityEngine;

public class PlayerShrink : MonoBehaviour
{
    [Header("Shrink Settings")]
    public float shrinkFactor = 0.5f; // how much smaller to make the player
    private bool isShrunk = false;

    private Rigidbody rb;
    private CapsuleCollider col;
    private Camera playerCam;

    private Vector3 originalScale;
    private float originalHeight;
    private float originalRadius;
    private float originalCamHeight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        playerCam = GetComponentInChildren<Camera>();

        // Save original sizes
        originalScale = transform.localScale;
        originalHeight = col.height;
        originalRadius = col.radius;
        originalCamHeight = playerCam.transform.localPosition.y;
    }

    public void Shrink()
    {
        if (isShrunk)
        {
            // Grow back to normal
            transform.localScale = originalScale;
            col.height = originalHeight;
            col.radius = originalRadius;

            Vector3 camPos = playerCam.transform.localPosition;
            camPos.y = originalCamHeight;
            playerCam.transform.localPosition = camPos;

            isShrunk = false;
        }
        else
        {
            // Shrink down
            rb.isKinematic = true; // turn off physics for stability

            transform.localScale = originalScale * shrinkFactor;
            col.height = originalHeight * shrinkFactor;
            col.radius = originalRadius * shrinkFactor;

            Vector3 camPos = playerCam.transform.localPosition;
            camPos.y = originalCamHeight * shrinkFactor;
            playerCam.transform.localPosition = camPos;

            rb.isKinematic = false;
            isShrunk = true;
        }
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.L))
    {
        Shrink();
    }
}
}
