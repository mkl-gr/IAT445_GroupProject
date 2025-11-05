using UnityEngine;


public class ShrinkMushroom : MonoBehaviour
{
    public float mushroomScale = 1;
    void Start(){
        mushroomScale = transform.localScale.x;
        gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale.x < 1)
        {
            // Debug.Log("The Mushroom is interactable");
            gameObject.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().enabled = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the object colliding with the mushroom's hitbox the function is called that makes the mushroom shrink.
        if (other.CompareTag("Projectile")) ShrinkMe();
    }
    
    public void ShrinkMe() {
        // Debug.Log("Shrunk");
        // Creates the smaller scale value of the fungi, and that value is assigned to its actual scale.
        if (mushroomScale > 1) mushroomScale -= (float)0.5;
        this.transform.localScale = new Vector3(mushroomScale, mushroomScale, mushroomScale);
    }
}
